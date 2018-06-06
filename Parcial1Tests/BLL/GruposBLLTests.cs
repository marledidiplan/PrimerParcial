using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial1.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parcial1.Entidades;
using Parcial1.DALL;

namespace Parcial1.BLL.Tests
{
    [TestClass()]
    public class GruposBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            grupos.GrupoId = 20;
            grupos.Descripcion = "Hola!";
            grupos.Fecha = DateTime.Now;
            grupos.Cantidad = 30;
            grupos.Grupo = 6;
            paso = BLL.GruposBLL.Guardar(grupos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            grupos.GrupoId = 20;
            grupos.Descripcion = "Hola Grupo!";
            grupos.Fecha = DateTime.Now;
            grupos.Cantidad = 30;
            grupos.Grupo = 6;
            paso = BLL.GruposBLL.Modificar(grupos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            
            Grupos grupos = new Grupos();
            Contexto contexto = new Contexto();
            int id = 1;
            grupos = contexto.gruposs.Find(id);
            Assert.IsNotNull(id);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Grupos grupos = new Grupos();
            grupos.GrupoId = 20;
            grupos.Descripcion = "Hola";
            grupos.Fecha = DateTime.Now;
            grupos.Cantidad = 30;
            grupos.Grupo = 6;
            int id = grupos.GrupoId; 
            paso = BLL.GruposBLL.Eliminar(id);


            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var list = GruposBLL.GetList(m => true);
            
            Assert.IsNotNull(list);
        }
    }
}