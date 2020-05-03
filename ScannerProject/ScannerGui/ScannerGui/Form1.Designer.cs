// Form1.designer.cs

namespace Scanner
{
    partial class Form1
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
            this.codeLinesTextBox = new System.Windows.Forms.TextBox();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TokenType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokenValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codeLinesTextBox
            // 
            this.codeLinesTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.codeLinesTextBox.Location = new System.Drawing.Point(27, 13);
            this.codeLinesTextBox.Multiline = true;
            this.codeLinesTextBox.Name = "codeLinesTextBox";
            this.codeLinesTextBox.Size = new System.Drawing.Size(247, 369);
            this.codeLinesTextBox.TabIndex = 0;
            this.codeLinesTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TokenType,
            this.TokenValue});
            this.DataGridView.Location = new System.Drawing.Point(301, 12);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.Size = new System.Drawing.Size(396, 408);
            this.DataGridView.TabIndex = 2;
            // 
            // TokenType
            // 
            this.TokenType.HeaderText = "Token Type";
            this.TokenType.Name = "TokenType";
            this.TokenType.ReadOnly = true;
            // 
            // TokenValue
            // 
            this.TokenValue.HeaderText = "Token Value";
            this.TokenValue.Name = "TokenValue";
            this.TokenValue.ReadOnly = true;
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.Location = new System.Drawing.Point(73, 388);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(137, 32);
            this.ScanButton.TabIndex = 3;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.codeLinesTextBox);
            this.Name = "Form1";
            this.Text = "Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeLinesTextBox;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenValue;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Label label1;
    }
}