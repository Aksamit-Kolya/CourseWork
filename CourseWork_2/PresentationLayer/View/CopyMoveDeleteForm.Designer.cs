
namespace CourseWork_2.PresentationLayer.View
{
    partial class CopyMoveDeleteForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.coutnLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(70, 160);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(307, 42);
            this.progressBar.TabIndex = 11;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(67, 92);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(153, 17);
            this.textLabel.TabIndex = 10;
            this.textLabel.Text = "Number of copied files:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileNameTextBox.Location = new System.Drawing.Point(70, 139);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(307, 15);
            this.fileNameTextBox.TabIndex = 9;
            this.fileNameTextBox.Text = "c:\\adsfa\\asdfa";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.Location = new System.Drawing.Point(187, 28);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(63, 25);
            this.Label.TabIndex = 8;
            this.Label.Text = "Copy";
            // 
            // coutnLabel
            // 
            this.coutnLabel.AutoSize = true;
            this.coutnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coutnLabel.Location = new System.Drawing.Point(241, 92);
            this.coutnLabel.Name = "coutnLabel";
            this.coutnLabel.Size = new System.Drawing.Size(28, 18);
            this.coutnLabel.TabIndex = 12;
            this.coutnLabel.Text = "4/5";
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentLabel.Location = new System.Drawing.Point(383, 170);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(33, 20);
            this.percentLabel.TabIndex = 13;
            this.percentLabel.Text = "0%";
            // 
            // CopyMoveDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 244);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.coutnLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.Label);
            this.Name = "CopyMoveDeleteForm";
            this.Text = "CopyMoveDeleteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label coutnLabel;
        private System.Windows.Forms.Label percentLabel;
    }
}