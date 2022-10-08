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
        public int? EnglishId { get; set; }
        [SugarColumn(ColumnName = "english_name")]
        public string? EnglishName { get; set; }
        [SugarColumn(ColumnName = "english_type")]
        public string? EnglishType { get; set; }
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
            this.EnglishId = db.Insertable(this).ExecuteReturnIdentity();
        }

        public void Selete(DB db)
        {
        }

        public void Update(DB db)
        {
            db.Updateable(this).ExecuteCommand();
        }
    }
}
