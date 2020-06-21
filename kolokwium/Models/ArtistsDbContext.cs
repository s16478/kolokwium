using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Models
{
    public class ArtistsDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<ArtistEvent> ArtistsEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventOrganiser> EventsOrganisers { get; set; }

        public DbSet<Organiser> Organisers { get; set; }

        public ArtistsDbContext() { }







        public ArtistsDbContext(DbContextOptions options)
            : base(options)
        { 

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().HasKey(key => new { key.IdArtist });
            modelBuilder.Entity<Event>().HasKey(key => new { key.IdEvent });
            modelBuilder.Entity<ArtistEvent>().HasKey(key => new { key.IdArtist, key.IdEvent });
            modelBuilder.Entity<Organiser>().HasKey(key => new { key.IdOrganiser });
            modelBuilder.Entity<EventOrganiser>().HasKey(key => new { key.IdEvent, key.IdOrganiser });






            modelBuilder.Entity<ArtistEvent>()
             .HasOne<Artist>(ae => ae.Artist)
             .WithMany(ar => ar.ArtistEvent)
             .HasForeignKey(ar => ar.IdArtist);

            modelBuilder.Entity<ArtistEvent>()
                .HasOne<Event>(ae => ae.Event)
                .WithMany(ev => ev.ArtistEvents)
                .HasForeignKey(ev => ev.IdEvent);






            modelBuilder.Entity<EventOrganiser>()
             .HasOne<Event>(eo => eo.Event)
             .WithMany(ev => ev.EventOrganisers)
             .HasForeignKey(ev => ev.IdEvent);

            modelBuilder.Entity<EventOrganiser>()
                .HasOne<Organiser>(ae => ae.Organiser)
                .WithMany(or => or.EventOrganisers)
                .HasForeignKey(or => or.IdOrganiser);


  




            modelBuilder.Entity<Artist>()
            .Property(s => s.Nickname)
            .HasMaxLength(30);

            modelBuilder.Entity<Event>()
            .Property(s => s.Name)
            .HasMaxLength(100);

            modelBuilder.Entity<Organiser>()
            .Property(s => s.Name)
            .HasMaxLength(30);


        }

    }
}
