﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bağlantı adresinin tanıtılması - Bağlantı Class'ının tanımlanması

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Adres İsmi (Bağlantı Adresi) - Oluşturulacak Database İsmi 
            optionsBuilder.UseSqlServer(@"Server=KAGANCANSIT; Database=CoreBlogDB; Integrated Security=True; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam).WithMany(y => y.HomeMatches).HasForeignKey(z => z.HomeTeamID).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>().HasOne(x => x.GuestTeam).WithMany(y => y.AwayMatches).HasForeignKey(z => z.GuestTeamID).OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }    
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Comment> Comments { get; set; }    
        public DbSet<Contact> Contacts { get; set; }    
        public DbSet<Writer> Writers { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> blogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message>   Messages { get; set; }
        public DbSet<Team>   Teams { get; set; }
        public DbSet<Match>   Matches { get; set; }
    }
}
