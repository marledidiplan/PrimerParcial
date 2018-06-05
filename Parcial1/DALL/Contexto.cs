using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Parcial1.Entidades;

namespace Parcial1.DALL
{
   public class Contexto : DbContext
    {
        public DbSet<Grupos> gruposs { get; set; }

        public Contexto() : base("ConStr")
        {

        }


    }
}
