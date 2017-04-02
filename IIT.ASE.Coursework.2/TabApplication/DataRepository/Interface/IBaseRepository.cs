using System.Data.SQLite;
using Dapper;

namespace TabApplication.DataRepository.Interface
{
    interface IBaseRepository
    {
        SQLiteConnection GetDbContextLocal();
        void CreateTables();
    }
}
