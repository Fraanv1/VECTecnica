using System;
using VEC.Domain;
using VEC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VEC.Infrastructure.Extensions;

namespace VEC.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties

        public DbSet<Vehiculo> Vehiculo { get; set; } = null!;

        #endregion

        #region Constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            setOnDeleteBehavior(modelBuilder, DeleteBehavior.Restrict);

            addSoftDeleteQueryFilter(modelBuilder);
        }

        #region SoftDelete Implementation

        private static void addSoftDeleteQueryFilter(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes().Where(e => e.BaseType == null && typeof(ISoftDelete).IsAssignableFrom(e.ClrType) && e.ClrType != null))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }

        public override int SaveChanges()
        {
            entryStateHandler();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            entryStateHandler();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void entryStateHandler()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                bool hasSoftDelete = entry.Entity is ISoftDelete;

                switch (entry.State)
                {
                    case EntityState.Added:
                        addSoftDeleteEntity(entry, hasSoftDelete);
                        break;

                    case EntityState.Modified:
                        modifySoftDeleteEntity(entry, hasSoftDelete);
                        break;

                    case EntityState.Deleted:
                        deleteSoftDeleteEntity(entry, hasSoftDelete);
                        break;
                }
            }
        }

        private static void deleteSoftDeleteEntity(EntityEntry entry, bool hasSoftDelete)
        {
            if (hasSoftDelete)
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["Activo"] = false;
            }
        }

        private static void modifySoftDeleteEntity(EntityEntry entry, bool hasSoftDelete)
        {
            if (hasSoftDelete)
                entry.CurrentValues["Activo"] = true;
        }

        private static void addSoftDeleteEntity(EntityEntry entry, bool hasSoftDelete)
        {
            if (hasSoftDelete)
                entry.CurrentValues["Activo"] = true;
        }

        private static void setOnDeleteBehavior(ModelBuilder builder, DeleteBehavior deleteBehavior)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = deleteBehavior;
            }
        }

        #endregion

        #region Data Seeding

    

        #endregion
    }
}

