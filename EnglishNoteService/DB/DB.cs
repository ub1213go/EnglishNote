using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace EnglishNote.DB
{
    public class DBManager
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public ConnectionConfig config { get; set; }
        public List<DB> dbs { get; set; }
        public DBManager()
        {
            Database = "EnglishNote";
            config = GetConfig();
            dbs = new List<DB>();
        }
        public DB Connect(string database)
        {
            Database = database;
            
            return new DB(GetConfig());
        }
        private ConnectionConfig GetConfig()
        {
            ConnectionString = $"Persist Security Info=False;Trusted_Connection=True; database={Database}; server=(local)";

            return new ConnectionConfig()
            {
                DbType = DbType.SqlServer,
                ConnectionString = ConnectionString,
                IsAutoCloseConnection = true
            };
        }
    }
    public class DB : SqlSugarClient
    {
        public DB(ConnectionConfig config) : base(config)
        {

        }

        public object GetEnglishList()
        {
            return Queryable<English>()
                .LeftJoin<EnglishTranslate>((e, et) => e.EnglishId == et.EnglishId)
                .LeftJoin<EnglishPronounce>((e, et, ep) => e.EnglishId == ep.EnglishId)
                .OrderBy((e, et, ep) => e.EnglishId, OrderByType.Desc)
                .Select((e, et, ep) => new
                {
                    EnglishId = e.EnglishId,
                    EnglishName = e.EnglishName,
                    Translate = et.Translate,
                    Pronounce = ep.Pronounce
                })
                .ToList();
        }
    }
    
    public interface IDBSet
    {
        void Insert(DB db);
        void Delete(DB db);
        void Update(DB db);
        T Select<T>(DB db);
    }

    public class DBException : Exception
    {
        public DBException() : base()
        {

        }
    }
}
