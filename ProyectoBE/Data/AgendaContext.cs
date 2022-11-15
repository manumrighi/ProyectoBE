using Microsoft.EntityFrameworkCore;
using ProyectoBE.Entities;

namespace ProyectoBE.Data
{
    public class AgendaContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User karen = new User()
            {
                Id = 1,
                Name = "Karen",
                Password = "Pa$$w0rd",
                Email = "karenbailapiola@gmail.com",
                UserName = "karenpiola"
            };
            User luis = new User()
            {
                Id = 2,
                Name = "Luis Gonzalez",
                Password = "lamismadesiempre",
                Email = "elluismidetotoras@gmail.com",
                UserName = "luismitoto"
            };

            Contact jaimitoC = new Contact()
            {
                Id = 1,
                Name = "Jaimito",
                Number = 341457896,
                UserId = karen.Id,
                Favorite = true,
            };

            Contact pepeC = new Contact()
            {
                Id = 2,
                Name = "Pepe",
                Number = 34156978,
                UserId = luis.Id,
                Favorite=false,
            };

            Contact mariaC = new Contact()
            {
                Id = 3,
                Name = "Maria",
                Number = 011425789,
                UserId = karen.Id,
                Favorite=true,
            };

            modelBuilder.Entity<User>().HasData(
                karen, luis);

            modelBuilder.Entity<Contact>().HasData(
                 jaimitoC, pepeC, mariaC
                 );

            modelBuilder.Entity<User>()
              .HasMany<Contact>(u => u.Contacts)
              .WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
