using Microsoft.EntityFrameworkCore;
using Karmaplusplus.Models;

namespace Karmaplusplus.Models
{
  public class KarmaplusplusContext : DbContext
  {
    public DbSet<Volunteering> Volunteerings { get; set; }

    public KarmaplusplusContext(DbContextOptions<KarmaplusplusContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Volunteering>()
        .HasData(
          new Volunteering { VolunteeringId = 1, UserId = "f9eb9311-a088-4b39-8c27-d92990b37433", VolunteeringName = "Beach clean up", Description = "Alki beach cleanup, no tools necessary, dress accordingly", Email = "clean.beaches@gmail.com", Location = "Alki Beach", ZipCode = "98116", Date = "06/01/2023", Time = "10:00 AM - 2 PM"  },
          new Volunteering { VolunteeringId = 2, UserId = "f9eb9311-a088-4b39-8c27-d92990b37433", VolunteeringName = "Free hot meals", Description = "Need help with cooking and distributing free hot meals", Email = "free.meals@gmail.com", Location = "9050 16th Avenue SW, Seattle", ZipCode = "98106", Date = "every Saturday", Time = "11 AM - 3 PM" },
          new Volunteering { VolunteeringId = 3, UserId = "f9eb9311-a088-4b39-8c27-d92990b37433", VolunteeringName = "English lessons", Description = "Need English language teachers to organize classes for recent immigrants from the Ukraine", Email = "free.english@gmail.com", Location = "Lucky Pen, Redmond", ZipCode = "98052", Date = "every Wednesday and Friday", Time = "11 AM - 12:30 PM" }
        );
    }
  }
}