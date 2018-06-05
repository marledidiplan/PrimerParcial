using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Parcial1.Entidades;
using Parcial1.DALL;
using System.Linq.Expressions;

namespace Parcial1.BLL
{
    public class GruposBLL
    {
        public static bool Guardar(Grupos grupos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.gruposs.Add(grupos) !=null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Modificar(Grupos grupos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(grupos).State = EntityState.Modified;
                if(contexto.SaveChanges()>0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public static Grupos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Grupos grupos = new Grupos();
            try
            {
                grupos = contexto.gruposs.Find(id);
                contexto.Dispose();

            }
            catch(Exception)
            {
                throw;
            }
            return grupos;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Grupos grupos = new Grupos();
            try
            {
                contexto.gruposs.Remove(grupos);
                if(contexto.SaveChanges()>0)
                {
                    paso = true;
                }
                
                
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public static List<Grupos> GetList(Expression<Func<Grupos, bool>> expression)
        {
            List<Grupos> grupos =new  List<Grupos>();
            Contexto contexto = new Contexto();
            try
            {
                grupos = contexto.gruposs.Where(expression).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return grupos;

        }
    }
}
