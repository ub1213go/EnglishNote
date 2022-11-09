namespace EnglishNoteUI
{
    partial class FrmNote
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inp_english = new EnglishNoteUI.Component.GroupInput();
            this.inp_translate = new EnglishNoteUI.Component.GroupInput();
            this.inp_pronounce = new EnglishNoteUI.Component.GroupInput();
            this.single = new System.Windows.Forms.CheckBox();
            this.sentence = new System.Windows.Forms.CheckBox();
            this.btn_enter = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // inp_english
            // 
            this.inp_english.CustomDataBindings = null;
            this.inp_english.CustomEnabled = false;
            this.inp_english.LabelName = "English";
            this.inp_english.Location = new System.Drawing.Point(8, 8);
            this.inp_english.Margin = new System.Windows.Forms.Padding(1);
            this.inp_english.Name = "inp_english";
            this.inp_english.Size = new System.Drawing.Size(231, 28);
            this.inp_english.TabIndex = 1;
            this.inp_english.TextBoxText = null;
            // 
            // inp_translate
            // 
            this.inp_translate.CustomDataBindings = null;
            this.inp_translate.CustomEnabled = false;
            this.inp_translate.LabelName = "Translate";
            this.inp_translate.Location = new System.Drawing.Point(8, 40);
            this.inp_translate.Margin = new System.Windows.Forms.Padding(1);
            this.inp_translate.Name = "inp_translate";
            this.inp_translate.Size = new System.Drawing.Size(231, 28);
            this.inp_translate.TabIndex = 2;
            this.inp_translate.TextBoxText = null;
            // 
            // inp_pronounce
            // 
            this.inp_pronounce.CustomDataBindings = null;
            this.inp_pronounce.CustomEnabled = false;
            this.inp_pronounce.LabelName = "Pronuounce";
            this.inp_pronounce.Location = new System.Drawing.Point(8, 72);
            this.inp_pronounce.Margin = new System.Windows.Forms.Padding(1);
            this.inp_pronounce.Name = "inp_pronounce";
            this.inp_pronounce.Size = new System.Drawing.Size(231, 28);
            this.inp_pronounce.TabIndex = 3;
            this.inp_pronounce.TextBoxText = null;
            // 
            // single
            // 
            this.single.AutoSize = true;
            this.single.Location = new System.Drawing.Point(8, 112);
            this.single.Margin = new System.Windows.Forms.Padding(2);
            this.single.Name = "single";
            this.single.Size = new System.Drawing.Size(61, 19);
            this.single.TabIndex = 99;
            this.single.Text = "Single";
            this.single.UseVisualStyleBackColor = true;
            // 
            // sentence
            // 
            this.sentence.AutoSize = true;
            this.sentence.Location = new System.Drawing.Point(67, 112);
            this.sentence.Margin = new System.Windows.Forms.Padding(2);
            this.sentence.Name = "sentence";
            this.sentence.Size = new System.Drawing.Size(78, 19);
            this.sentence.TabIndex = 99;
            this.sentence.Text = "Sentence";
            this.sentence.UseVisualStyleBackColor = true;
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(149, 109);
            this.btn_enter.Margin = new System.Windows.Forms.Padding(2);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(71, 22);
            this.btn_enter.TabIndex = 4;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(8, 139);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 62;
            this.grid.RowTemplate.Height = 32;
            this.grid.Size = new System.Drawing.Size(494, 147);
            this.grid.StandardTab = true;
            this.grid.TabIndex = 99;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(403, 8);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(71, 22);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(327, 8);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(71, 22);
            this.btn_edit.TabIndex = 7;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(252, 8);
            this.btn_add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(71, 22);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(224, 109);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(71, 22);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 293);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.sentence);
            this.Controls.Add(this.single);
            this.Controls.Add(this.inp_pronounce);
            this.Controls.Add(this.inp_translate);
            this.Controls.Add(this.inp_english);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmNote";
            this.Text = "Note";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Component.GroupInput english;
        private Component.GroupInput translate;
        private Component.GroupInput pronounce;
        private CheckBox single;
        private CheckBox sentence;
        private Button enter;
        private DataGridView grid;
        private Button btn_delete;
        private Component.GroupInput inp_english;
        private Component.GroupInput inp_translate;
        private Component.GroupInput inp_pronounce;
        private Button btn_enter;
        private Button btn_edit;
        private Button btn_add;
        private Button btn_cancel;
    }
}