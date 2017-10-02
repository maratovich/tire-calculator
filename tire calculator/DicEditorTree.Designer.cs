namespace TyreCalculator
{
    partial class DicEditorTree
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.brandComboBoxEd = new System.Windows.Forms.ComboBox();
            this.modelComboBoxEd = new System.Windows.Forms.ComboBox();
            this.yearComboBoxEd = new System.Windows.Forms.ComboBox();
            this.engineComboBoxEd = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(268, 328);
            this.treeView1.TabIndex = 0;
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(12, 346);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 1;
            this.openFileBtn.Text = "Открыть";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.engineComboBoxEd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.yearComboBoxEd, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.modelComboBoxEd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.brandComboBoxEd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(303, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(279, 109);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Бренд";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Модель";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Двигатель";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Год выпуска";
            // 
            // brandComboBoxEd
            // 
            this.brandComboBoxEd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.brandComboBoxEd.FormattingEnabled = true;
            this.brandComboBoxEd.Location = new System.Drawing.Point(148, 3);
            this.brandComboBoxEd.Name = "brandComboBoxEd";
            this.brandComboBoxEd.Size = new System.Drawing.Size(121, 21);
            this.brandComboBoxEd.TabIndex = 3;
            this.brandComboBoxEd.SelectedIndexChanged += new System.EventHandler(this.brandComboBoxEd_SelectedIndexChanged);
            // 
            // modelComboBoxEd
            // 
            this.modelComboBoxEd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modelComboBoxEd.FormattingEnabled = true;
            this.modelComboBoxEd.Location = new System.Drawing.Point(148, 30);
            this.modelComboBoxEd.Name = "modelComboBoxEd";
            this.modelComboBoxEd.Size = new System.Drawing.Size(121, 21);
            this.modelComboBoxEd.TabIndex = 4;
            // 
            // yearComboBoxEd
            // 
            this.yearComboBoxEd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yearComboBoxEd.FormattingEnabled = true;
            this.yearComboBoxEd.Location = new System.Drawing.Point(148, 57);
            this.yearComboBoxEd.Name = "yearComboBoxEd";
            this.yearComboBoxEd.Size = new System.Drawing.Size(121, 21);
            this.yearComboBoxEd.TabIndex = 5;
            // 
            // engineComboBoxEd
            // 
            this.engineComboBoxEd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.engineComboBoxEd.FormattingEnabled = true;
            this.engineComboBoxEd.Location = new System.Drawing.Point(148, 84);
            this.engineComboBoxEd.Name = "engineComboBoxEd";
            this.engineComboBoxEd.Size = new System.Drawing.Size(121, 21);
            this.engineComboBoxEd.TabIndex = 6;
            // 
            // DicEditorTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 390);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DicEditorTree";
            this.Text = "Редактор справочников (Древо)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox engineComboBoxEd;
        private System.Windows.Forms.ComboBox yearComboBoxEd;
        private System.Windows.Forms.ComboBox modelComboBoxEd;
        private System.Windows.Forms.ComboBox brandComboBoxEd;
        private System.Windows.Forms.Label label4;
    }
}