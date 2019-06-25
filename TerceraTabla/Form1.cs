using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.BLL;

namespace TerceraTabla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public double Exixtencia { get; set; }
        public double Precio { get; set; }


        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Exixtencia = 0;
            Precio = 0;
        }

    }
    public class Pedidos
    {
        [Key]
        public int Pedidoid { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        [ForeignKey("ArticuloId")]

        public virtual List<PedidosDetalles> Detalles { get; set; }

        public Pedidos()
        {
            Pedidoid = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }

    }

    public class PedidosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }

        public PedidosDetalles()
        {
            Id = 0;
            PedidoId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Precio = 0;
        }


    }


}
namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public Contexto() : base(@"Data Source=DESKTOP-B6P5QMH; Initial Catalog = TestDb;Integrated Security =true")
        {
        }
    }
}


namespace Test.BLL
{
    public interface IRepositorio<T> where T : class
    {
        bool Guardar(T entity);
        bool Modificar(T entity);
        T Buscar(int Id);
        List<T> GetList(Expression<Func<T, bool>> expression);
        bool Eliminar(int Id);
    }

    public class RepositorioBase<T> : IDisposable, IRepositorio<T> where T : class
    {
        internal Contexto db;
        public RepositorioBase()
        {
            db = new Contexto();
        }
        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if (db.Set<T>().Add(entity) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;

            try
            {

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            return paso;
        }

        public T Buscar(int Id)
        {
            T entity;
            try
            {
                entity = db.Set<T>().Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }


        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> lista;
            try
            {
                lista = db.Set<T>().Where(expression).ToList();


            }
            catch (Exception)
            {
                throw;

            }
            return lista;
        }

        public bool Eliminar(int Id)
        {
            bool paso = false;
            T entity;
            try
            {
                entity = db.Set<T>().Find(Id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

public class RepositorioVistas : RepositorioBase<Pedidos>

{



}