using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using SqlSugar;

namespace EnglishNote.DB
{
    [SugarTable("english_translate")]
    public class EnglishTranslate : IDBSet
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int? Id { get; set; }
        [SugarColumn(ColumnName = "english_id")]
        public int? EnglishId { get; set; }
        [SugarColumn(ColumnName = "translate")]
        public string? Translate { get; set; }
        [SugarColumn(ColumnName = "create_datetime")]
        public DateTime? CreateDatetime { get; set; }
        [SugarColumn(ColumnName = "is_visible")]
        public bool? IsVisible { get; set; }


        public void Delete(DB db)
        {
            db.Deleteable(this).ExecuteCommand();
        }

        public void Insert(DB db)
        {
            this.Id = db.Insertable(this).ExecuteReturnIdentity();
        }

        public T Select<T>(DB db)
        {
            return default(T);
        }

        public void Update(DB db)
        {
            db.Updateable(this).ExecuteCommand();
        }
    }
}
