//using Agendamento.Dominio;
using Agendamento.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agendamento.reposit
{
    public class SalaContext : DbContext
    {
        /*public SalaContext()
        {

        }*/
        
        public SalaContext(DbContextOptions<SalaContext> options) : base(options)        {   }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB\\SQLEXPRESS");
        }*/

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //var connectionString = @"Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB\SQLEXPRESS";
        //optionsBuilder.UseSqlServer(connectionString);
        //}


    }

}
