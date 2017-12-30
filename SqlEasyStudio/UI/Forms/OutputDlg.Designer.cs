namespace SqlEasyStudio.UI.Forms
{
    partial class OutputDlg
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
            this._tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._panel = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._textBox = new System.Windows.Forms.RichTextBox();
            this._tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tab
            // 
            this._tab.Controls.Add(this.tabPage1);
            this._tab.Controls.Add(this.tabPage2);
            this._tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tab.Location = new System.Drawing.Point(0, 0);
            this._tab.Name = "_tab";
            this._tab.SelectedIndex = 0;
            this._tab.Size = new System.Drawing.Size(284, 261);
            this._tab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._panel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 1, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(276, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _panel
            // 
            this._panel.AutoScroll = true;
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(2, 1);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(271, 231);
            this._panel.TabIndex = 1;            
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._textBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(276, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Messages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _textBox
            // 
            this._textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox.Location = new System.Drawing.Point(15, 3);
            this._textBox.Margin = new System.Windows.Forms.Padding(15);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(258, 229);
            this._textBox.TabIndex = 2;
            this._textBox.Text = "";
            // 
            // OutputDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._tab);
            this.Name = "OutputDlg";
            this.Text = "OutputDlg";
            this._tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox _textBox;
        private System.Windows.Forms.Panel _panel;
    }
}