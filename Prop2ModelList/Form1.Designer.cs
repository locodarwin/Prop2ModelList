namespace Prop2ModelList
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
            this.label1 = new System.Windows.Forms.Label();
            this.textFileIn = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butGo = new System.Windows.Forms.Button();
            this.richStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Propdump File:";
            // 
            // textFileIn
            // 
            this.textFileIn.Location = new System.Drawing.Point(93, 21);
            this.textFileIn.Name = "textFileIn";
            this.textFileIn.Size = new System.Drawing.Size(346, 20);
            this.textFileIn.TabIndex = 1;
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(445, 20);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(79, 23);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butGo
            // 
            this.butGo.Location = new System.Drawing.Point(12, 55);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(111, 23);
            this.butGo.TabIndex = 3;
            this.butGo.Text = "Create Model List";
            this.butGo.UseVisualStyleBackColor = true;
            this.butGo.Click += new System.EventHandler(this.butGo_Click);
            // 
            // richStatus
            // 
            this.richStatus.Location = new System.Drawing.Point(6, 91);
            this.richStatus.Name = "richStatus";
            this.richStatus.Size = new System.Drawing.Size(518, 118);
            this.richStatus.TabIndex = 4;
            this.richStatus.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 215);
            this.Controls.Add(this.richStatus);
            this.Controls.Add(this.butGo);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.textFileIn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Prop2ModelList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFileIn;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.RichTextBox richStatus;
    }
}

