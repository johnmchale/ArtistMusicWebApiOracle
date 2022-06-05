using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Data.Configurations;

namespace MyMusic.Data
{
    public class MyMusicDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // Replace table names
                entityType.SetTableName(entityType.GetTableName().ToUpper());

                // Replace column names
                foreach (var property in entityType.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToUpper());
                }

                // Replace key names
                foreach (var key in entityType.GetKeys())
                {
                    key.SetName(key.GetName().ToUpper());
                }

                // Replace foreign key names
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToUpper());
                }

                // Replace index names
                foreach (var index in entityType.GetIndexes())
                {
                    index.SetName(index.GetName().ToUpper());
                }
            }

            builder.HasDefaultSchema("JOHNMC");

            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
