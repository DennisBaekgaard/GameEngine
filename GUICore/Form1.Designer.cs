namespace GUICore
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
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.loadCharacters_btn = new System.Windows.Forms.Button();
            this.loadRules_btn = new System.Windows.Forms.Button();
            this.startMatch_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.Control;
            this.logBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.logBox.Location = new System.Drawing.Point(12, 12);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.ShortcutsEnabled = false;
            this.logBox.Size = new System.Drawing.Size(769, 356);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // loadCharacters_btn
            // 
            this.loadCharacters_btn.Location = new System.Drawing.Point(12, 399);
            this.loadCharacters_btn.Name = "loadCharacters_btn";
            this.loadCharacters_btn.Size = new System.Drawing.Size(121, 56);
            this.loadCharacters_btn.TabIndex = 1;
            this.loadCharacters_btn.Text = "Load Characters";
            this.loadCharacters_btn.UseVisualStyleBackColor = true;
            this.loadCharacters_btn.Click += new System.EventHandler(this.loadCharacters_btn_Click);
            // 
            // loadRules_btn
            // 
            this.loadRules_btn.Location = new System.Drawing.Point(660, 399);
            this.loadRules_btn.Name = "loadRules_btn";
            this.loadRules_btn.Size = new System.Drawing.Size(121, 56);
            this.loadRules_btn.TabIndex = 2;
            this.loadRules_btn.Text = "Load Rules";
            this.loadRules_btn.UseVisualStyleBackColor = true;
            this.loadRules_btn.Click += new System.EventHandler(this.loadRules_btn_Click);
            // 
            // startMatch_btn
            // 
            this.startMatch_btn.Location = new System.Drawing.Point(331, 399);
            this.startMatch_btn.Name = "startMatch_btn";
            this.startMatch_btn.Size = new System.Drawing.Size(121, 56);
            this.startMatch_btn.TabIndex = 3;
            this.startMatch_btn.Text = "Start Match";
            this.startMatch_btn.UseVisualStyleBackColor = true;
            this.startMatch_btn.Click += new System.EventHandler(this.startMatch_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 462);
            this.Controls.Add(this.startMatch_btn);
            this.Controls.Add(this.loadRules_btn);
            this.Controls.Add(this.loadCharacters_btn);
            this.Controls.Add(this.logBox);
            this.Name = "Form1";
            this.Text = "GameEngine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button loadCharacters_btn;
        private System.Windows.Forms.Button loadRules_btn;
        private System.Windows.Forms.Button startMatch_btn;
    }
}

