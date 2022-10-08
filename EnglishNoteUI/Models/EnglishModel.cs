using EnglishNote.DB;
using SqlSugar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteUI.Models
{
    public class EnglishModel
    {
        public DB db { get; set; }
        public string TableName { get; set; }

        private DataTable dt;

        public EnglishModel()
        {
            TableName = "EnglishNote";

            db = new DBManager().Connect(TableName);
        }
        public List<EnglishData> GetAll()
        {
            // object 複製到 list
            var list = db.GetEnglishList();
            List<EnglishData> result = new List<EnglishData>();
            for (int i = 0; i < Convert.ToInt32(list.GetType()?.GetProperty("Count")?.GetValue(list) ?? 0); i++)
            {
                var item = list.GetType()?.GetProperty("Item")?.GetValue(list, new object[] { i });
                var englishData = new EnglishData();
                var itemProps = item?.GetType()?.GetProperties();
                var engProps = englishData.GetType().GetProperties();
                for(int j = 0; j < itemProps?.Length; j++)
                {
                    for(int k = 0; k < engProps.Length; k++)
                    {
                        var prop = itemProps[j];
                        if(prop.Name == engProps[k].Name)
                        {
                            engProps[k].SetValue(englishData, prop.GetValue(item));
                            break;
                        }
                    }
                }
                result.Add(englishData);
            }

            return result;
        }

        public DataTable GetTable()
        {
            dt = new DataTable();
            dt.TableName = TableName;

            var columns = typeof(EnglishData).GetProperties().Select(p=>p.Name).ToArray();

            if (columns.Length == 0) return null;

            for (int i = 0; i < columns.Length; i++)
            {
                var n = columns[i];
                if (n.ToLower().Contains("id"))
                {
                    dt.Columns.Add(n, typeof(int));
                }
                else
                {
                    dt.Columns.Add(n, typeof(string));
                }
            }
            
            return dt;
        }

        public EnglishData Get(int id)
        {

            return null;
        }

        public EnglishData Delete(int id)
        {
            db.Ado.ExecuteCommand(
                "DELETE english WHERE english_id=@id;" +
                "DELETE english_translate WHERE english_id=@id;" +
                "DELETE english_pronounce WHERE english_id=@id"
                , new List<SugarParameter>(){
              new SugarParameter("@id",id),
            });

            return null;
        }

        public EnglishData Add(EnglishData data)
        {
            var oeng = new English()
            {
                CreateDatetime = DateTime.Now,
                EnglishName = data.EnglishName,
                EnglishType = "single",
                IsVisible = true
            };
            oeng.Insert(db);

            var otrn = new EnglishTranslate()
            {
                CreateDatetime = DateTime.Now,
                Translate = data.Translate,
                EnglishId = oeng.EnglishId,
                IsVisible = true
            };
            otrn.Insert(db);

            var opro = new EnglishPronounce()
            {
                CreateDatetime = DateTime.Now,
                Pronounce = data.Pronounce,
                EnglishId = oeng.EnglishId,
                IsVisible = true
            };
            opro.Insert(db);

            data.EnglishId = (int)oeng.EnglishId;

            return data;
        }
    }

    public class EnglishData
    {
        public int EnglishId { get; set; }
        public string EnglishName { get; set; }
        public string Translate { get; set; }
        public string Pronounce { get; set; }
    }
}
