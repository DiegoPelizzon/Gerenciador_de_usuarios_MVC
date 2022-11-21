using Microsoft.EntityFrameworkCore;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Banco
{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options)
        {

        }
        public DbSet<UsuarioModel> usuarios { get; set; }
    }
}
