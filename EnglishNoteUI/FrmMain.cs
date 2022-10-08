using EnglishNoteUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishNoteUI
{
    public partial class FrmMain : Form
    {
        private int childFormNumber = 0;
        private EnglishModel _englishModel;

        public FrmMain()
        {
            InitializeComponent();
            _englishModel = new EnglishModel();
        }

        private void 英文輸入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if(form is FrmNote frmNote)
                {
                    frmNote.WindowState = FormWindowState.Normal;
                    frmNote.Focus();
                    return;
                }
                
            }

            var frm = new FrmNote(_englishModel);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void 英文測驗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is FrmTest frmNote)
                {
                    frmNote.WindowState = FormWindowState.Normal;
                    frmNote.Focus();
                    return;
                }

            }

            var frm = new FrmTest(_englishModel);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }
    }
}
