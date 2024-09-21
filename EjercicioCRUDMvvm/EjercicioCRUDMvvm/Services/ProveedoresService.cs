using EjercicioCRUDMvvm.Models;
using SQLite;

namespace EjercicioCRUDMvvm.Services
{
    public class ProveedoresService
    {
        private readonly SQLiteConnection DbConnection;

        public ProveedoresService()
        {
            string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");

            DbConnection = new SQLiteConnection(DbPath);
            DbConnection.CreateTable<Proveedores>();
        }

        public List<Proveedores> GetAll()
        {
            var res = DbConnection.Table<Proveedores>().ToList();
            return res;
        }

        public int Insert(Proveedores Proveedores)
        {
            return DbConnection.Insert(Proveedores);
        }

        public int Update(Proveedores Proveedores)
        {
            return DbConnection.Update(Proveedores);
        }

        public int Delete(Proveedores Proveedores)
        {
            return DbConnection.Delete(Proveedores);
        }

    }
}
