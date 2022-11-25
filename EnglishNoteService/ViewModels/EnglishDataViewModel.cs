using EnglishNote.DB;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public class EnglishDataViewModel
    {
        public DB db { get; set; }
        public string TableName { get; set; }

        public List<EnglishData> englishDatas { get; set; }

        private DataTable dt;

        public EnglishDataViewModel()
        {
            TableName = "EnglishNote";

            db = new DBManager().Connect(TableName);
            englishDatas = new List<EnglishData>();
        }

        public List<EnglishData> getAll()
        {
            // object 複製到 list
            var list = db.getEnglishList();
            englishDatas = new List<EnglishData>();

            var count = Convert.ToInt32(
                list.GetType()?
                    .GetProperty("Count")?
                    .GetValue(list)
                ?? 0);

            for (int i = 0; i < count; i++)
            {
                var item = list.GetType()?
                    .GetProperty("Item")?
                    .GetValue(list, new object[] { i });

                var englishData = new EnglishData();
                var itemProps = item?.GetType()?.GetProperties();
                var engProps = englishData.GetType().GetProperties();

                for (int j = 0; j < itemProps?.Length; j++)
                {
                    for (int k = 0; k < engProps.Length; k++)
                    {
                        var prop = itemProps[j];
                        if (prop.Name == engProps[k].Name)
                        {
                            engProps[k].SetValue(englishData, prop.GetValue(item));
                            break;
                        }
                    }
                }
                englishDatas.Add(englishData);
            }

            return englishDatas;
        }

        public DataTable getTable()
        {
            dt = new DataTable();
            dt.TableName = TableName;

            var columns = typeof(EnglishData).GetProperties().Select(p => p.Name).ToArray();

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

        public EnglishData get(int id)
        {

            return null;
        }

        public bool delete(int id)
        {
            int step = 0;
            try
            {
                db.BeginTran();
                step = db.Deleteable<English>()
                    .Where(p => p.englishId == id)
                    .ExecuteCommand();
                if (step == 0) return false;
                step = db.Deleteable<EnglishTranslate>()
                    .Where(p => p.englishId == id)
                    .ExecuteCommand();
                if (step == 0) return false;
                step = db.Deleteable<EnglishPronounce>()
                    .Where(p => p.englishId == id)
                    .ExecuteCommand();
                db.CommitTran();
            }
            catch(Exception err)
            {
                db.RollbackTran();
            }
            finally
            {
                if(step == 0)
                {
                    db.RollbackTran();
                }
            }

            return true;
        }

        public EnglishData add(EnglishData data)
        {
            var oeng = new English()
            {
                createDatetime = DateTime.Now,
                englishName = data.englishName,
                englishType = "single",
                appearTimes = 0,
                finishTimes = 0,
                isVisible = true
            };
            oeng.insert(db);

            var otrn = new EnglishTranslate()
            {
                createDatetime = DateTime.Now,
                translate = data.translate,
                englishId = oeng.englishId,
                isVisible = true
            };
            otrn.insert(db);

            var opro = new EnglishPronounce()
            {
                createDatetime = DateTime.Now,
                pronounce = data.pronounce,
                englishId = oeng.englishId,
                isVisible = true
            };
            opro.insert(db);

            data.englishId = (int)oeng.englishId;

            return data;
        }
    
        public EnglishData update(EnglishData data)
        {
            var oeng = new English()
            {
                englishId = data.englishId,
                createDatetime = DateTime.Now,
                englishName = data.englishName,
                englishType = "single",
                isVisible = true
            };
            oeng.update(db);

            var otrn = db.Queryable<EnglishTranslate>().Where(p => p.englishId == oeng.englishId).First();
             
            otrn.update(db);

            var opro = db.Queryable<EnglishPronounce>().Where(p => p.englishId == oeng.englishId).First();

            opro.update(db);

            return data;
        }

        public void addAppearTimes(EnglishData english)
        {
            try
            {
                var q = db.Queryable<English>()
                    .Where(p => p.englishId == english.englishId)
                    .First();

                if (q == null) throw new Exception($"Key值錯誤, {english.englishId}");

                q.appearTimes += 1;
                q.update(db);
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
        }

        public void addFinishTimes(EnglishData english)
        {
            try
            {
                var q = db.Queryable<English>()
                    .Where(p => p.englishId == english.englishId)
                    .First();

                if (q == null) throw new Exception($"Key值錯誤, {english.englishId}");

                q.finishTimes += 1;
                q.update(db);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
            }
        }
    }

}
