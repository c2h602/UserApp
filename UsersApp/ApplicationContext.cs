﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public ApplicationContext() => Database.EnsureCreated();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=\"C:\\Users\\User\\source\\repos\\UsersApp\\UsersApp\\baza.db\"");
		}
	}
}
