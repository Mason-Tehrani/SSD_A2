using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SSD_A1.Data
{
    public class DataBaseInit
    {

        public static AppsSecrets appSecrets { get; set; }
        public static async Task<int> SeedUsersAndRoles(IServiceProvider serviceProvider)
        {
            // create the database if it doesn't exist
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Check if roles already exist and exit if there are
            if (roleManager.Roles.Count() > 0)
                return 1;  // should log an error message here

            // Seed roles
            int result = await SeedRoles(roleManager);
            if (result != 0)
                return 2;  // should log an error message here

            // Check if users already exist and exit if there are
            if (userManager.Users.Count() > 0)
                return 3;  // should log an error message here

            // Seed users
            result = await SeedUsers(userManager);
            if (result != 0)
                return 4;  // should log an error message here





            return 0;
        }

        private static async Task<int> SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Create Admin Role
            var result = await roleManager.CreateAsync(new IdentityRole("Supervisor"));
            if (!result.Succeeded)
                return 1;  // should log an error message here

            // Create Member Role
            result = await roleManager.CreateAsync(new IdentityRole("Employee"));
            if (!result.Succeeded)
                return 2;  // should log an error message here

            return 0;
        }
        private static async Task<int> SeedUsers(UserManager<ApplicationUser> userManager)
        {
     

            // Create Supervisor
            string supervisorEmail = "supervisor@mohawkcollege.ca";

            if (await userManager.FindByEmailAsync(supervisorEmail) == null)
            {
                var supervisor = new ApplicationUser
                {
                    UserName = supervisorEmail,
                    Email = supervisorEmail,
                    FirstName = "mike",
                    LastName = "oxemall",
                    City = "Hamilton",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(supervisor, appSecrets.MemberPassword);

                if (!result.Succeeded)
                    return 1;  // should log an error message here

                // Assign user to Admin role
                result = await userManager.AddToRoleAsync(supervisor, "SuperVisor");
                if (!result.Succeeded)
                    return 2;  // should log an error message here
            }

            // Create Employee
            string employeeEmail = "employee@mohawkcollege.ca";

            if (await userManager.FindByEmailAsync(employeeEmail) == null)
            {
                var employee = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    FirstName = "ben",
                    LastName = "dover",
                    City = "Hamilton",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(employee, appSecrets.MemberPassword);

                if (!result.Succeeded)
                    return 3;  // should log an error message here

                // Assign user to Member role
                result = await userManager.AddToRoleAsync(employee, "Employee");
                if (!result.Succeeded)
                    return 4;  // should log an error message here

            }

            return 0;
        }
    }
}
