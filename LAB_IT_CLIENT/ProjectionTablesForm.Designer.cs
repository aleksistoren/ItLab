namespace LAB_IT_CLIENT
{
    partial class ProjectionTablesForm
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
            this.Table1Label = new System.Windows.Forms.Label();
            this.Table2Label = new System.Windows.Forms.Label();
            this.Table1ComboBox = new System.Windows.Forms.ComboBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.IndexOfProjectionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Table1Label
            // 
            this.Table1Label.AutoSize = true;
            this.Table1Label.Location = new System.Drawing.Point(17, 11);
            this.Table1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Table1Label.Name = "Table1Label";
            this.Table1Label.Size = new System.Drawing.Size(50, 13);
            this.Table1Label.TabIndex = 0;
            this.Table1Label.Text = "Таблица";
            // 
            // Table2Label
            // 
            this.Table2Label.AutoSize = true;
            this.Table2Label.Location = new System.Drawing.Point(17, 58);
            this.Table2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Table2Label.Name = "Table2Label";
            this.Table2Label.Size = new System.Drawing.Size(233, 13);
            this.Table2Label.TabIndex = 1;
            this.Table2Label.Text = "Поля (номера, через пробел: нумерация с 1)";
            // 
            // Table1ComboBox
            // 
            this.Table1ComboBox.FormattingEnabled = true;
            this.Table1ComboBox.Location = new System.Drawing.Point(20, 27);
            this.Table1ComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.Table1ComboBox.Name = "Table1ComboBox";
            this.Table1ComboBox.Size = new System.Drawing.Size(136, 21);
            this.Table1ComboBox.TabIndex = 2;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(185, 14);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(130, 45);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "Показать проекцию";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(185, 72);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(130, 45);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // IndexOfProjectionTextBox
            // 
            this.IndexOfProjectionTextBox.Location = new System.Drawing.Point(20, 85);
            this.IndexOfProjectionTextBox.Name = "IndexOfProjectionTextBox";
            this.IndexOfProjectionTextBox.Size = new System.Drawing.Size(136, 20);
            this.IndexOfProjectionTextBox.TabIndex = 6;
            // 
            // ProjectionTablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 127);
            this.Controls.Add(this.IndexOfProjectionTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.Table1ComboBox);
            this.Controls.Add(this.Table2Label);
            this.Controls.Add(this.Table1Label);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProjectionTablesForm";
            this.Text = "UnionTablesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Table1Label;
        private System.Windows.Forms.Label Table2Label;
        private System.Windows.Forms.ComboBox Table1ComboBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox IndexOfProjectionTextBox;
    }
}