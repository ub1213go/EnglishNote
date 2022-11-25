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

        public enum EEnglishDataMapping
        {
            englishId,
            englishName,
            translate,
            pronounce
        }

        public Dictionary<EEnglishDataMapping, string> englishDataMapping = new Dictionary<EEnglishDataMapping, string>()
        {
            { EEnglishDataMapping.englishId, "englishId" },
            { EEnglishDataMapping.englishName, "englishName" },
            { EEnglishDataMapping.translate, "translate" },
            { EEnglishDataMapping.pronounce, "pronounce" }
        };

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
            List<EnglishData> list = englishDataViewModel.getAll().ToList();
            for (int i = 0; i < colsName.Length; i++)
            {
                if (colsName[i].Name == "englishId")
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

            inp_english.CustomDataBindings = new Binding("Text", bindingSource, EEnglishDataMapping.englishName.ToString());
            inp_translate.CustomDataBindings = new Binding("Text", bindingSource, EEnglishDataMapping.translate.ToString());
            inp_pronounce.CustomDataBindings = new Binding("Text", bindingSource, EEnglishDataMapping.pronounce.ToString());
        }

        private void enter_Click(object sender, EventArgs e)
        {
            var eng = inp_english.TextBoxText?.Trim().ToLower() ?? "";
            var trn = inp_translate.TextBoxText?.Trim() ?? "";
            var pro = inp_pronounce.TextBoxText?.Trim() ?? "";
            
            var cur = (DataRowView)bindingSource.Current;

            cur[EEnglishDataMapping.englishName.ToString()] = eng;
            cur[EEnglishDataMapping.translate.ToString()] = trn;
            cur[EEnglishDataMapping.pronounce.ToString()] = pro;
            if (UIStatus == EUIStatus.Add)
            {
                bindingSource.EndEdit();
                var newData = englishDataViewModel.add(new EnglishData() { 
                    englishName = eng, 
                    translate = trn, 
                    pronounce = pro
                });
                cur[EEnglishDataMapping.englishId.ToString()] = newData.englishId;
                
                btn_add.Focus();
            }
            else if(UIStatus == EUIStatus.Edit)
            {
                bindingSource.EndEdit();
                englishDataViewModel.update(new EnglishData()
                {
                    englishId = Convert.ToInt32(cur[EEnglishDataMapping.englishId.ToString()]),
                    englishName = eng,
                    translate = trn,
                    pronounce = pro
                });
                btn_edit.Focus();
            }
            bindingSource.ResetCurrentItem();
            UIStatus = EUIStatus.Read;
            btn_add.Focus();
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
                englishDataViewModel.delete((int)grid.CurrentRow.Cells[0].Value);
                bindingSource.RemoveCurrent();
            }
        }

        public void refreshUI()
        {
            if (UIStatus == EUIStatus.Read)
            {
                inp_translate.CustomReadOnly = true;
                inp_pronounce.CustomReadOnly = true;
                inp_english.CustomReadOnly = true;
                btn_cancel.Enabled = false;
                btn_enter.Enabled = false;
                btn_add.Enabled = true;
                btn_edit.Enabled = true;
                btn_delete.Enabled = true;
            }
            else if(UIStatus == EUIStatus.Add || UIStatus == EUIStatus.Edit)
            {
                inp_english.CustomReadOnly = false;
                inp_translate.CustomReadOnly = false;
                inp_pronounce.CustomReadOnly = false;
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