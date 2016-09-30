using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IssuesManager.DL;
using IssuesManager.DL.Interfaces;
using IssuesManager.APIControllers;
using Microsoft.EntityFrameworkCore;

namespace IssuesManager.Test
{
    public class UserControllerTests
    {
        private IssuesContext db;

        public UserControllerTests()
        {

        }

        private void Initialize()
        {
            var dboptions = new DbContextOptionsBuilder<IssuesContext>();
            dboptions.UseInMemoryDatabase();

            db = new IssuesContext(dboptions.Options);
        }

        [Fact]
        public async void Login_Test_Valid()
        {
            Initialize();

            #region Arrange 
            db.Users.Add(new Models.User() { DecPassword = "123123aa", Name = "Ariel", Password = "123123aa", Surname = "Amor", UserName = "Django" });
            db.SaveChanges();

            IUserRepository userRepo = new UserRepository(db);
            UserController UserCtrl = new UserController(userRepo);
            #endregion

            #region Act
            var res = await UserCtrl.Login(new ViewModels.LoginViewModel() { UserName = "Django", Password = "123123aa" });
            #endregion

            #region Assert
            Assert.True(res);
            #endregion
        }

        [Fact]
        public async void Login_Test_Invalid()
        {
            Initialize();

            #region Arrange 
            db.Users.Add(new Models.User() { DecPassword = "123123aa", Name = "Ariel", Password = "123123aa", Surname = "Amor", UserName = "Django" });
            db.SaveChanges();

            IUserRepository userRepo = new UserRepository(db);
            UserController UserCtrl = new UserController(userRepo);
            #endregion

            #region Act
            var res = await UserCtrl.Login(new ViewModels.LoginViewModel() { UserName = "NOT THE CORRECT USER", Password = "NOT THE CORRECT PASSWORD" });
            #endregion

            #region Assert
            Assert.False(res);
            #endregion
        }
    }
}