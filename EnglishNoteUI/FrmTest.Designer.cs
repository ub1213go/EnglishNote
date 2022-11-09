namespace EnglishNoteUI
{
    partial class FrmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_quizsBoard = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.tb_inputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_quizsBoard
            // 
            this.tb_quizsBoard.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_quizsBoard.Location = new System.Drawing.Point(8, 8);
            this.tb_quizsBoard.Margin = new System.Windows.Forms.Padding(2);
            this.tb_quizsBoard.Multiline = true;
            this.tb_quizsBoard.Name = "tb_quizsBoard";
            this.tb_quizsBoard.ReadOnly = true;
            this.tb_quizsBoard.Size = new System.Drawing.Size(495, 230);
            this.tb_quizsBoard.TabIndex = 0;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(430, 263);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(71, 22);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // tb_inputBox
            // 
            this.tb_inputBox.Location = new System.Drawing.Point(406, 240);
            this.tb_inputBox.Margin = new System.Windows.Forms.Padding(2);
            this.tb_inputBox.Name = "tb_inputBox";
            this.tb_inputBox.Size = new System.Drawing.Size(97, 23);
            this.tb_inputBox.TabIndex = 1;
            this.tb_inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_inputBox_KeyDown);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 293);
            this.Controls.Add(this.tb_inputBox);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.tb_quizsBoard);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_quizsBoard;
        private Button btn_Submit;
        private TextBox tb_inputBox;
    }
}