using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Psico.Models;

namespace Psico.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Psico.Models.TipoProfissional> TipoProfissional { get; set; }
        public DbSet<Psico.Models.Profissional> Profissional { get; set; }
        public DbSet<Psico.Models.Escala> Escala { get; set; }
        public DbSet<Psico.Models.Consulta> Consulta { get; set; }
    }
}
