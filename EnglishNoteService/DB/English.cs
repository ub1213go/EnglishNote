using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace EnglishNote.DB
{
    [SugarTable("english")]
    public class English : IDBSet
    {
        [SugarColumn(ColumnName = "english_id", IsPrimaryKey = true, IsIdentity = true)]
        public int? englishId { get; set; }
        [SugarColumn(ColumnName = "english_name")]
        public string? englishName { get; set; }
        [SugarColumn(ColumnName = "english_type")]
        public string? englishType { get; set; }
        [SugarColumn(ColumnName = "create_datetime")]
        public DateTime? createDatetime { get; set; }
        [SugarColumn(ColumnName = "finish_times")]
        public int? finishTimes { get; set; }
        [SugarColumn(ColumnName = "appear_times")]
        public int? appearTimes { get; set; }
        [SugarColumn(ColumnName = "is_visible")]
        public bool? isVisible { get; set; }

        public void delete(DB db)
        {
            db.Deleteable(this).ExecuteCommand();
        }

        public void insert(DB db)
        {
            this.englishId = db.Insertable(this).ExecuteReturnIdentity();
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
