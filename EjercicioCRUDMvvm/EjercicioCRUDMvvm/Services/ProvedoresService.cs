using EjercicioCRUDMvvm.Models;
using SQLite;

namespace EjercicioCRUDMvvm.Services
{
    public class ProvedoresService
    {
        private readonly SQLiteConnection DbConnection;

        public ProvedoresService()
        {
            string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Provedores.db3");

            DbConnection = new SQLiteConnection(DbPath);
            DbConnection.CreateTable<Provedores>();
        }

        public List<Provedores> GetAll()
        {
            var res = DbConnection.Table<Provedores>().ToList();
            return res;
        }

        public int Insert(Provedores Provedores)
        {
            return DbConnection.Insert(Provedores);
        }

        public int Update(Provedores Provedores)
        {
            return DbConnection.Update(Provedores);
        }

        public int Delete(Provedores Provedores)
        {
            return DbConnection.Delete(Provedores);
        }

    }
}
