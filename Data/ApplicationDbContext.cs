using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Crossways.Data.Domain;
using Crossways.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crossways.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<PublisherSubscriber> PublisherSubscribers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<SeriesPost> SeriesPosts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendee> MeetingAttendees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ProductCategory>(item =>
            {
                item.HasKey(pc => new { pc.ProductId, pc.CategoryId });

                item.HasOne(pc => pc.Product)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(pc => pc.ProductId)
                    .IsRequired();

                item.HasOne(pc => pc.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(pc => pc.CategoryId)
                    .IsRequired();
            });
            
            builder.Entity<PostCategory>(ac =>
            {
                ac.HasKey(o => new { o.PostId, o.CategoryId });

                ac.HasOne(a => a.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(a => a.CategoryId)
                    .IsRequired();

                ac.HasOne(c => c.Post)
                    .WithMany(a => a.Categories)
                    .HasForeignKey(c => c.PostId)
                    .IsRequired();
            });

            builder.Entity<SeriesPost>(sa =>
            {
                sa.HasKey(o => new { o.PostId, o.SeriesId });

                sa.HasOne(a => a.Series)
                    .WithMany(s => s.Posts)
                    .HasForeignKey(a => a.SeriesId)
                    .IsRequired();

                sa.HasOne(s => s.Post)
                    .WithMany(a => a.Series)
                    .HasForeignKey(s => s.PostId)
                    .IsRequired();
            });

            builder.Entity<MeetingAttendee>(ma =>
            {
                ma.HasKey(m => new { m.AttendeeId, m.MeetingId });

                ma.HasOne(m => m.Meeting)
                    .WithMany(m => m.Attendees)
                    .HasForeignKey(m => m.MeetingId)
                    .IsRequired();

                ma.HasOne(m => m.Attendee)
                    .WithMany(m => m.Meetings)
                    .HasForeignKey(m => m.AttendeeId)
                    .IsRequired();
            });

            builder.Entity<PublisherSubscriber>(ps =>
            {
                ps.HasKey(p => new { p.PublisherId, p.MemberId });

                ps.HasOne(m => m.Member)
                    .WithMany(m => m.Subscriptions)
                    .HasForeignKey(m => m.MemberId)
                    .IsRequired();

                ps.HasOne(p => p.Publisher)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(p => p.PublisherId)
                    .IsRequired();
            });
            builder.SeedAdmin();
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;
                        
                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }

            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is Entity)
                {
                    var entity = changedEntity.Entity as Entity;
                    if (changedEntity.State == EntityState.Added)
                    {
                        entity.Created = DateTime.Now;
                        entity.Updated = DateTime.Now;
                        
                    }
                    else if (changedEntity.State == EntityState.Modified)
                    {
                        entity.Updated = DateTime.Now;
                    }
                }
            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
        

    }
}