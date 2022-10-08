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
            this.english = new EnglishNoteUI.Component.GroupInput();
            this.translate = new EnglishNoteUI.Component.GroupInput();
            this.pronounce = new EnglishNoteUI.Component.GroupInput();
            this.single = new System.Windows.Forms.CheckBox();
            this.sentence = new System.Windows.Forms.CheckBox();
            this.enter = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // english
            // 
            this.english.LabelName = "English";
            this.english.Location = new System.Drawing.Point(12, 12);
            this.english.Name = "english";
            this.english.Size = new System.Drawing.Size(363, 43);
            this.english.TabIndex = 0;
            this.english.TextBoxText = null;
            // 
            // translate
            // 
            this.translate.LabelName = "Translate";
            this.translate.Location = new System.Drawing.Point(12, 61);
            this.translate.Name = "translate";
            this.translate.Size = new System.Drawing.Size(363, 43);
            this.translate.TabIndex = 1;
            this.translate.TextBoxText = null;
            // 
            // pronounce
            // 
            this.pronounce.LabelName = "Pronuounce";
            this.pronounce.Location = new System.Drawing.Point(12, 110);
            this.pronounce.Name = "pronounce";
            this.pronounce.Size = new System.Drawing.Size(363, 43);
            this.pronounce.TabIndex = 2;
            this.pronounce.TextBoxText = null;
            // 
            // single
            // 
            this.single.AutoSize = true;
            this.single.Location = new System.Drawing.Point(12, 172);
            this.single.Name = "single";
            this.single.Size = new System.Drawing.Size(88, 27);
            this.single.TabIndex = 3;
            this.single.Text = "Single";
            this.single.UseVisualStyleBackColor = true;
            // 
            // sentence
            // 
            this.sentence.AutoSize = true;
            this.sentence.Location = new System.Drawing.Point(106, 172);
            this.sentence.Name = "sentence";
            this.sentence.Size = new System.Drawing.Size(114, 27);
            this.sentence.TabIndex = 4;
            this.sentence.Text = "Sentence";
            this.sentence.UseVisualStyleBackColor = true;
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(263, 167);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(112, 34);
            this.enter.TabIndex = 5;
            this.enter.Text = "Enter";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(776, 225);
            this.dataGridView1.TabIndex = 6;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(676, 165);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(112, 34);
            this.delete.TabIndex = 7;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.sentence);
            this.Controls.Add(this.single);
            this.Controls.Add(this.pronounce);
            this.Controls.Add(this.translate);
            this.Controls.Add(this.english);
            this.Name = "FrmNote";
            this.Text = "Note";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private DataGridView dataGridView1;
        private Button delete;
    }
}