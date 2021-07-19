using ColaboradoresWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresWebApi.DataBaseContext
{
    public class AgexportDbContext : DbContext
    {
        public AgexportDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
