using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookApplication.Models
{
    public class BookDB : DbContext
    {
        public BookDB()
            : base("DefaultConnection")
        { }

        public DbSet<Book> Books { get; set; }
    }
}