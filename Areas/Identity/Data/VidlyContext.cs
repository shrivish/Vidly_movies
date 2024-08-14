﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Vidly.Areas.Identity.Data;
using Vidly.Models;


namespace Vidly.Data;

public class VidlyContext : IdentityDbContext<VidlyUser>
{
    public VidlyContext(DbContextOptions<VidlyContext> options)
        : base(options)
    {
    }
    // Define DbSets for your entities
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<MembershipType> MembershipType { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany()
            .HasForeignKey(m => m.GenreId);
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
