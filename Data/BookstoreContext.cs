using System;
using Microsoft.EntityFrameworkCore;
using Fisher.GroceryApi.Models;

namespace Fisher.GroceryApi.Data
{

    public class BookstoreContext : DbContext
    {
        
        public BookstoreContext (DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        public DbSet<Item> GroceryItems {get; set;}
        
    }
}