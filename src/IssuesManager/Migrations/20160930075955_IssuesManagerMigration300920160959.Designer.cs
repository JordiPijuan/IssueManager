using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IssuesManager.DL;

namespace IssuesManager.Migrations
{
    [DbContext(typeof(IssuesContext))]
    [Migration("20160930075955_IssuesManagerMigration300920160959")]
    partial class IssuesManagerMigration300920160959
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IssuesManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DecPassword")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Surname")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
        }
    }
}
