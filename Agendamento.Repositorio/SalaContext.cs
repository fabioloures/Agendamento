using System;
using System.Collections.Generic;
using System.Text;

namespace Agendamento.Repositorio
{
    public class SalaContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Evento> Eventos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = @"Data Source=SERENITY\EXPRESS2014;Initial Catalog=TicketSystem;Integrated Security=True";
            var connectionString = @"Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB\SQLEXPRESS";
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB\SQLEXPRESS");
            //optionsBuilder.UseSqlServer("Password=master;Persist Security Info=True;User ID=sa;Initial Catalog=AgendamentoApp;Data Source=DESKTOP-C54G0EB");
        }


    }


}
