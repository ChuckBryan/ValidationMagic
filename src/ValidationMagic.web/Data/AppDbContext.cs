namespace ValidationMagic.web.Data
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // note: instead of running migrations for this example, this will
            // create the database as is and will add the record seeded below.
            this.Database.EnsureCreated();
        }

        public DbSet<Registration> Registrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // note: data can be seeded as part of the model creation.
            modelBuilder.Entity<Registration>().HasData(new Registration
                {Email = "test@abc.com", HowDidYouHear = "Other", HowDidYouHearOther = "From a Friend"});

            
        }
    }
}