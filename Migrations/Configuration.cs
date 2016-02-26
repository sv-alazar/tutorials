namespace MVC2.Migrations
{
    using MVC2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC2.Models.MVCdb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC2.Models.MVCdb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
            new Restaurant { Name = "A", City = "cj", Country = "ro" },
             new Restaurant { Name = "B", City = "gg", Country = "cc" },
             new Restaurant
             {
                 Name = "C",
                 City = "AA",
                 Country = "Sw",
                 Reviews =
                     new List<RestaurantReview> {
                     new RestaurantReview { Rating=9,Body="Gud!", ReviewerName="Scott"}
                 }
             });

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" });
            }

            SeedMembership();
        }

        private void SeedMembership()
        {
            DatabaseConnection.Init();

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if(!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("andrei",false)==null)
            {
                membership.CreateUserAndAccount("andrei","Adminis");
            }
            if (!roles.GetRolesForUser("andrei").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "andrei" }, new[] { "admin" });
            }
        }
    }
}
