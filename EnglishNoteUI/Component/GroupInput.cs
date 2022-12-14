using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EnglishNoteUI.Component
{
    public partial class GroupInput : UserControl
    {
        private string? _LabelName;
        public string? LabelName {
            get { return _LabelName; }
            set
            {
                _LabelName = value;
                label1.Text = _LabelName;
            }
        }

        private string? _TextBoxText;
        public string? TextBoxText
        {
            get { return _TextBoxText; }
            set
            {
                _TextBoxText = value;
                textBox1.Text = Text;
            }
        }

        private Binding _CustomDataBindings;
        public Binding CustomDataBindings
        {
            get { return _CustomDataBindings; }
            set
            {
                _CustomDataBindings = value;
                if(value is Binding b)
                {
                    textBox1.DataBindings.Add(b);
                }
            }
        }

        private bool _CustomEnabled;
        public bool CustomEnabled
        {
            get { return _CustomEnabled; }
            set
            {
                _CustomEnabled = value;
                textBox1.Enabled = value;
            }
        }

        private bool _CustomReadOnly;
        public bool CustomReadOnly
        {
            get { return _CustomReadOnly; }
            set
            {
                _CustomReadOnly = value;
                textBox1.ReadOnly = value;
            }
        }

        public GroupInput()
        {
            InitializeComponent();

            textBox1.TextChanged += TextChangedHandler;
        }

        public void TextChangedHandler(object? sender, EventArgs args)
        {
            _TextBoxText = (sender as TextBox)?.Text;
        }

    }
}
