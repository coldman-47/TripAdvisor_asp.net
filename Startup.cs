using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TripAdvisory_.Models;

[assembly: OwinStartupAttribute(typeof(TripAdvisory_.Startup))]
namespace TripAdvisory_
{
    public partial class Startup
    {
        TripAdvisorEntities db = new TripAdvisorEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void createUsersAndRoles() {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin")) {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                Role r = new Role();
                r.libelle = role.Name;
                db.Roles.Add(r);
                db.SaveChanges();

                var user = new ApplicationUser();
                user.UserName = "coldman";
                user.Email = "coldman@isi.sn";

                string pwd = "P@sser123";
                var checkUser = userManager.Create(user, pwd);
                Utilisateur u = new Utilisateur();
                u.id_asp_user = user.Id;
                u.telephone = "777007070";
                db.Utilisateurs.Add(u);
                db.SaveChanges();

                if (checkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Proprio"))
            {
                var role = new IdentityRole();
                role.Name = "Proprio";
                roleManager.Create(role);
                Role r = new Role();
                r.libelle = role.Name;
                db.Roles.Add(r);
                db.SaveChanges();
            }

            if (!roleManager.RoleExists("Invite"))
            {
                var role = new IdentityRole();
                role.Name = "Invite";
                roleManager.Create(role);
                Role r = new Role();
                r.libelle = role.Name;
                db.Roles.Add(r);
                db.SaveChanges();
            }
        }
    }
}
