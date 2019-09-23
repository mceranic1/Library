using Library_DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Library.Test
{
    public class TestContext : LibContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=admin;Server=localhost;Port=5432;Database=libtest;Integrated Security=true;Pooling=true;"
                );
        }
    }
}
