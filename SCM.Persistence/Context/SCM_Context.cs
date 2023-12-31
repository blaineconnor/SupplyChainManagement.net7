﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SCM.Domain.Common;
using SCM.Domain.Entities;
using SCM.Domain.Services.Abstractions;
using SCM.Persistence.Mappings;

namespace SCM.Persistence.Context
{
    public class SCM_Context : DbContext
    {
        private readonly ILoggedUserService _loggedUserService;

        public SCM_Context(DbContextOptions<SCM_Context> options, ILoggedUserService loggedUserService) : base(options)
        {
            _loggedUserService = loggedUserService;
        }

        #region DbSet

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Approves> Approves { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Offer> Offers { get; set; }





        #endregion

        #region Model Builder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new RequestMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ApproveMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new InvoiceMapping());
            modelBuilder.ApplyConfiguration(new OfferMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());




            modelBuilder.Entity<Account>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Employee>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Category>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Request>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Approves>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Offer>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
            modelBuilder.Entity<Supplier>().HasQueryFilter(x => x.IsDeleted == null || !(!x.IsDeleted.HasValue || x.IsDeleted.Value));
        }

        #endregion


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }

                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            auditableEntity.UpdatedTime = DateTime.Now;
                            auditableEntity.By = _loggedUserService.UserName ?? "admin";
                            break;
                        //insert
                        case EntityState.Added:
                            auditableEntity.AddedTime = DateTime.Now;
                            auditableEntity.By = _loggedUserService.UserName ?? "admin";
                            break;
                        //delete
                        case EntityState.Deleted:
                            auditableEntity.UpdatedTime = DateTime.Now;
                            auditableEntity.By = _loggedUserService.UserName ?? "admin";
                            break;
                        default:
                            break;
                    }
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
