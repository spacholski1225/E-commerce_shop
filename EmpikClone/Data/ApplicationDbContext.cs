using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EmpikClone.Models;

namespace EmpikClone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmpikClone.Models.Book> Book { get; set; }
        public DbSet<EmpikClone.Models.Album> Album { get; set; }
    }
}
