using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab12
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<Entry> Entries { get; set; } = new();
    }

    public class Entry
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AttachmentPath { get; set; } = string.Empty;

        public int SessionId { get; set; }
        public Session? Session { get; set; }
    }

    public class BioInfoDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bioinfo_notebook.db");
        }
    }
}