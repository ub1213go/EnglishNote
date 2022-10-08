using EnglishNote.DB;
using System.Data;
using System.Collections;
using EnglishNoteUI.Models;
using NpgsqlTypes;

namespace EnglishNoteUI
{
    public partial class FrmNote : Form
    {
        public DataTable dt { get; set; }
        public EnglishModel englishModel { get; set; }
        public FrmNote(EnglishModel _englishModel)
        {
            englishModel = _englishModel;

            InitializeComponent();

            InitGrid();
        }

        private void InitGrid()
        {
            dt = englishModel.GetTable();

            dataGridView1.DataSource = dt;

            var list = englishModel.GetAll();
            foreach (var item in list)
            {
                var tp = item.GetType();
                var tplv = new List<object>();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    tplv.Add(tp.GetProperty(dt.Columns[i].ColumnName).GetValue(item));
                }
                dt.Rows.Add(tplv.ToArray());
            }

            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 200;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void enter_Click(object sender, EventArgs e)
        {
            var eng = english.TextBoxText?.Trim();
            var trn = translate.TextBoxText?.Trim();
            var pro = pronounce.TextBoxText?.Trim();
            english.TextBoxText = "";
            translate.TextBoxText = "";
            pronounce.TextBoxText = "";

            var data = englishModel.Add(new EnglishData() { EnglishName = eng, Translate = trn, Pronounce = pro });

            DataRow dr = dt.NewRow();

            dr.ItemArray = new string[] { data.EnglishId.ToString(), data.EnglishName, data.Translate, data.Pronounce };

            dt.Rows.InsertAt(dr, 0);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            englishModel.Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
            dt.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}