using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoologicos.Modelos;

    public class ZoologicoAPIContext : DbContext //puente entre C# y la base de datos
{
        public ZoologicoAPIContext (DbContextOptions<ZoologicoAPIContext> options)
            : base(options)
        {
        }

        //cada DbSet representa una Tabla en la BD
        public DbSet<Zoologicos.Modelos.Raza> Razas { get; set; } = default!;

        public DbSet<Zoologicos.Modelos.Especie> Especies { get; set; } = default!;

        public DbSet<Zoologicos.Modelos.Animal> Animales { get; set; } = default!;
    }
