using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{

    public class CollectorContext : DbContext
    {
        public DbSet<Mount> Mount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=collector.db");
        }
    }
    public class Mount
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

public static class DbSetExtensions
{
    public static T AddOrUpdate<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
    {
        var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
        
        return !exists ? dbSet.Add(entity).Entity : dbSet.Update(entity).Entity;
    }
}
