namespace TheatreAssessment.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreAssessment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheatreAssessment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            user.UserName = "user@test.com";
            user.Email = "user@test.com";

            string userPass = "Test123$";

            UserManager.Create(user, userPass);

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            var adminuser = new ApplicationUser();
            adminuser.UserName = "admin@test.com";
            adminuser.Email = "admin@test.com";

            userPass = "Pass123$";

            var checkUser = UserManager.Create(adminuser, userPass);

            if (checkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(adminuser.Id, "Admin");

            }

            if (!roleManager.RoleExists("Restricted"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Restricted";
                roleManager.Create(role);


            }

            var post1 = new Post();
            post1.PostID = 1;
            post1.UserName = user.UserName;
            post1.PostTitle = "Post Test 1";
            post1.PostDesc = "Post Desc 1";
            post1.PostDate = DateTime.Now;

            try
            {
                context.Posts.Add(post1);
            }
            catch (SqlException ex)
            {

                var error = ex.InnerException;
            }

            var comment1 = new Comment();
            comment1.CommentID = 1;
            comment1.PostID = 1;
            comment1.CommentBody = "Comment 1";
            comment1.UserName = user.UserName;
            comment1.CommentDate = DateTime.Now;

            try
            {
                context.Comments.Add(comment1);
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
            }

            var Comment2 = new Comment();
            Comment2.CommentID = 2;
            Comment2.PostID = 1;
            Comment2.CommentBody = "Comment 2";
            Comment2.UserName = user.UserName;
            Comment2.CommentDate = DateTime.Now;

            try
            {
                context.Comments.Add(Comment2);
            }
            catch (SqlException ex)
            {
                var error = ex.InnerException;
            }

            var post2 = new Post();
            post2.PostID = 2;
            post2.UserName = user.UserName;
            post2.PostTitle = "Post Test 2";
            post2.PostDesc = "Post Desc 2";
            post2.PostDate = DateTime.Now;

            try
            {

                context.Posts.Add(post2);
            }
            catch (SqlException ex)
            {
                var error = ex.InnerException;
            }
            var restricted = new IdentityRole();
            restricted.Name = "restricted";
            roleManager.Create(restricted);


        }
    }
}
