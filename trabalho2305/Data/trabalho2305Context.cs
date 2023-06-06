using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trabalho2305.Models;

namespace trabalho2305.Data
{
    public class trabalho2305Context : DbContext
    {
        public trabalho2305Context (DbContextOptions<trabalho2305Context> options)
            : base(options)
        {
        }

        public DbSet<trabalho2305.Models.Cidade> Cidade { get; set; }

        public DbSet<trabalho2305.Models.FormaPgto> FormaPgto { get; set; }

        public DbSet<trabalho2305.Models.Pedido> Pedido { get; set; }

        public DbSet<trabalho2305.Models.Cliente> Cliente { get; set; }
    }
}
