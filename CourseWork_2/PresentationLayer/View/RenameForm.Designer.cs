
namespace CourseWork_2.PresentationLayer.View
{
    partial class RenameForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.channelButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(29, 80);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(126, 37);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Rename";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // channelButton
            // 
            this.channelButton.Location = new System.Drawing.Point(312, 80);
            this.channelButton.Name = "channelButton";
            this.channelButton.Size = new System.Drawing.Size(126, 37);
            this.channelButton.TabIndex = 1;
            this.channelButton.Text = "Channel";
            this.channelButton.UseVisualStyleBackColor = true;
            this.channelButton.Click += new System.EventHandler(this.channelButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(125, 29);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(313, 22);
            this.textBox.TabIndex = 4;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "New name";
            // 
            // errorlabel
            // 
            this.errorlabel.AutoSize = true;
            this.errorlabel.ForeColor = System.Drawing.Color.Red;
            this.errorlabel.Location = new System.Drawing.Point(122, 60);
            this.errorlabel.Name = "errorlabel";
            this.errorlabel.Size = new System.Drawing.Size(182, 17);
            this.errorlabel.TabIndex = 6;
            this.errorlabel.Text = "*This name is already used!";
            this.errorlabel.Visible = false;
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 134);
            this.Controls.Add(this.errorlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.channelButton);
            this.Controls.Add(this.okButton);
            this.Name = "RenameForm";
            this.Text = "RenameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RenameForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button channelButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorlabel;
    }
}