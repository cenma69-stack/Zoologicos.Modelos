using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoologicos.Modelos;

    public class ZoologicoAPIContext : DbContext
    {
        public ZoologicoAPIContext (DbContextOptions<ZoologicoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Zoologicos.Modelos.Animal> Animal { get; set; } = default!;

        public DbSet<Zoologicos.Modelos.Especie> Especie { get; set; } = default!;

        public DbSet<Zoologicos.Modelos.Raza> Raza { get; set; } = default!;
    }
