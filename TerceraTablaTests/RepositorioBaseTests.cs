using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            articulos.ArticuloId = 0;
            articulos.Descripcion = "perfecto";
            articulos.Exixtencia = 0;
            articulos.Precio = 0;

            Assert.AreEqual(true, db.Guardar(articulos));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            articulos.ArticuloId = 1;
            articulos.Descripcion = "excelente";
            articulos.Exixtencia = 1;
            articulos.Precio = 1;

            Assert.AreEqual(true, db.Modificar(articulos));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            Assert.IsNotNull(db.Buscar(1));

        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();

            Assert.IsNotNull(db.GetList(t => true));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Assert.IsTrue(db.Eliminar(1));
        }


        [TestMethod()]
        public void GuardarTest1()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Pedidos pedidos = new Pedidos();

            pedidos.Pedidoid = 0;            
            pedidos.Fecha = DateTime.Now;
            pedidos.Monto = 0;

            Assert.AreEqual(true, db.Guardar(pedidos));
        }

        [TestMethod()]
        public void ModificarTest1()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Pedidos pedidos = new Pedidos();

            pedidos.Pedidoid = 1;
            pedidos.Fecha = DateTime.Now;
            pedidos.Monto = 1;

            Assert.AreEqual(true, db.Modificar(pedidos));
        }

        [TestMethod()]
        public void BuscarTest1()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Pedidos pedidos = new Pedidos();

            Assert.IsNotNull(db.Buscar(1));

        }

        [TestMethod()]
        public void GetListTest1()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Pedidos pedidos = new Pedidos();

            Assert.IsNotNull(db.GetList(t => true));
        }

        [TestMethod()]
        public void EliminarTest1()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Assert.IsTrue(db.Eliminar(1));
        }


    }
}