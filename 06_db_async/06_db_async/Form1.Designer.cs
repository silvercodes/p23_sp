namespace _06_db_async
{
    partial class Form1
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
            txtQuery = new TextBox();
            btnExec = new Button();
            dgvMain = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // txtQuery
            // 
            txtQuery.Location = new Point(75, 35);
            txtQuery.Name = "txtQuery";
            txtQuery.Size = new Size(1247, 57);
            txtQuery.TabIndex = 0;
            // 
            // btnExec
            // 
            btnExec.Location = new Point(1105, 118);
            btnExec.Name = "btnExec";
            btnExec.Size = new Size(217, 63);
            btnExec.TabIndex = 1;
            btnExec.Text = "Execute";
            btnExec.UseVisualStyleBackColor = true;
            btnExec.Click += btnExec_Click;
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Location = new Point(86, 226);
            dgvMain.Name = "dgvMain";
            dgvMain.RowHeadersWidth = 82;
            dgvMain.Size = new Size(1243, 750);
            dgvMain.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(20F, 50F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 1050);
            Controls.Add(dgvMain);
            Controls.Add(btnExec);
            Controls.Add(txtQuery);
            Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuery;
        private Button btnExec;
        private DataGridView dgvMain;
    }
}
