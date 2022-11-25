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

        public object getEnglishList()
        {
            return Queryable<English>()
                .LeftJoin<EnglishTranslate>((e, et) => e.englishId == et.englishId)
                .LeftJoin<EnglishPronounce>((e, et, ep) => e.englishId == ep.englishId)
                .OrderBy((e, et, ep) => e.englishId, OrderByType.Desc)
                .Select((e, et, ep) => new
                {
                    englishId = e.englishId,
                    englishName = e.englishName,
                    translate = et.translate,
                    pronounce = ep.pronounce,
                    appearTimes = e.appearTimes,
                    finishTimes = e.finishTimes
                })
                .ToList();
        }
    }
    
    public interface IDBSet
    {
        void insert(DB db);
        void delete(DB db);
        void update(DB db);
        T select<T>(DB db);
    }

    public class DBException : Exception
    {
        public DBException() : base()
        {

        }
    }
}
