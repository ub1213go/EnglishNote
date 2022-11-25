using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using SqlSugar;

namespace EnglishNote.DB
{
    [SugarTable("english_pronounce")]
    public class EnglishPronounce : IDBSet
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int? id { get; set; }
        [SugarColumn(ColumnName = "english_id")]
        public int? englishId { get; set; }
        [SugarColumn(ColumnName = "pronounce")]
        public string? pronounce { get; set; }
        [SugarColumn(ColumnName = "create_datetime")]
        public DateTime? createDatetime { get; set; }
        [SugarColumn(ColumnName = "is_visible")]
        public bool? isVisible { get; set; }


        public void delete(DB db)
        {
            db.Deleteable(this).ExecuteCommand();
        }

        public void insert(DB db)
        {
            this.id = db.Insertable(this).ExecuteReturnIdentity();
        }

        public T select<T>(DB db)
        {
            return default(T);
        }

        public void update(DB db)
        {
            db.Updateable(this).ExecuteCommand();
        }
    }
}
