using Azure.Core.Pipeline;
using GestionPretRetour.Domain.OrderAggregate;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.Users;
using GestionPretRetour.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GestionPretRetour.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { 
        
    }


    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Penalty> UserPenalties { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }
    
}
