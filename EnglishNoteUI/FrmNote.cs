using EnglishNote.DB;
using System.Data;
using System.Collections;
using EnglishNoteService;
using NpgsqlTypes;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace EnglishNoteUI
{
    public partial class FrmNote : Form
    {
        public enum EUIStatus { 
            None = 0,
            Read = 1,
            Edit = 2,
            Add = 3,
            Delete = 4
        }

        //public DataTable dt { get; set; }

        public EUIStatus UIStatus { get; set; }

        public EnglishDataViewModel englishDataViewModel { get; set; }

        public BindingSource bindingSource { get; set; }

        public FrmNote(EnglishDataViewModel _EnglishDataViewModel)
        {
            if (_EnglishDataViewModel == null)
            {
                throw new ArgumentNullException(nameof(_EnglishDataViewModel));
            }
            englishDataViewModel = _EnglishDataViewModel;

            bindingSource = new BindingSource();

            InitializeComponent();

            UIStatus = EUIStatus.Read;

            refreshUI();

            InitGrid();
        }

        private void InitGrid()
        {
            DataTable table = new DataTable();
            var colsName = typeof(EnglishData).GetProperties();
            List<EnglishData> list = englishDataViewModel.GetAll().ToList();
            for (int i = 0; i < colsName.Length; i++)
            {
                if (colsName[i].Name == "EnglishId")
                {
                    table.Columns.Add(colsName[i].Name, typeof(int));
                }
                else
                {
                    table.Columns.Add(colsName[i].Name);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                var row = table.NewRow();
                for (int j = 0; j < colsName.Length; j++)
                {
                    row[colsName[j].Name] = typeof(EnglishData).GetProperty(colsName[j].Name).GetValue(list[i]);
                }
                table.Rows.Add(row);
            }

            bindingSource.DataSource = table;

            grid.DataSource = bindingSource;
            grid.AllowUserToAddRows = false;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = 180;
            }
            grid.Columns[0].Width = 70;
            grid.Columns[grid.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            inp_english.CustomDataBindings = new Binding("Text", bindingSource,"EnglishName");
            inp_translate.CustomDataBindings = new Binding("Text", bindingSource,"Translate");
            inp_pronounce.CustomDataBindings = new Binding("Text", bindingSource, "Pronounce");
        }

        private void enter_Click(object sender, EventArgs e)
        {
            var eng = inp_english.TextBoxText?.Trim().ToLower() ?? "";
            var trn = inp_translate.TextBoxText?.Trim() ?? "";
            var pro = inp_pronounce.TextBoxText?.Trim() ?? "";
            
            var cur = (EnglishData)bindingSource.Current;
            cur.EnglishName = eng;
            cur.Translate = trn;
            cur.Pronounce = pro;
            if (UIStatus == EUIStatus.Add)
            {
                bindingSource.EndEdit();
                var newData = englishDataViewModel.Add(new EnglishData() { 
                    EnglishName = cur.EnglishName, 
                    Translate = cur.Translate, 
                    Pronounce = cur.Pronounce
                });
                cur.EnglishId = newData.EnglishId;
                
                btn_add.Focus();
            }
            else if(UIStatus == EUIStatus.Edit)
            {
                bindingSource.EndEdit();
                var editData = englishDataViewModel.Update(cur);
                btn_edit.Focus();
            }
            bindingSource.ResetCurrentItem();
            UIStatus = EUIStatus.Read;
            refreshUI();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if(UIStatus == EUIStatus.Add)
            {
                bindingSource.RemoveCurrent();
            }
            else if(UIStatus == EUIStatus.Edit)
            {
                bindingSource.CancelEdit();
            }
            UIStatus = EUIStatus.Read;
            refreshUI();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("確定要刪除？", "是否刪除", MessageBoxButtons.YesNo);
            if(confirm == DialogResult.Yes)
            {
                englishDataViewModel.Delete((int)grid.CurrentRow.Cells[0].Value);
                bindingSource.RemoveCurrent();
            }
        }

        public void refreshUI()
        {
            if(UIStatus == EUIStatus.Read)
            {
                inp_translate.CustomEnabled = false;
                inp_pronounce.CustomEnabled = false;
                inp_english.CustomEnabled = false;
                btn_cancel.Enabled = false;
                btn_enter.Enabled = false;
                btn_add.Enabled = true;
                btn_edit.Enabled = true;
                btn_delete.Enabled = true;
            }
            else if(UIStatus == EUIStatus.Add || UIStatus == EUIStatus.Edit)
            {
                inp_english.CustomEnabled = true;
                inp_translate.CustomEnabled = true;
                inp_pronounce.CustomEnabled = true;
                btn_cancel.Enabled = true;
                btn_enter.Enabled = true;
                btn_add.Enabled = false;
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            UIStatus = EUIStatus.Add;
            bindingSource.AddNew();
            refreshUI();
            inp_english.Focus();
         }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            UIStatus = EUIStatus.Edit;
            refreshUI();
            inp_english.Focus();
        }
    }
}