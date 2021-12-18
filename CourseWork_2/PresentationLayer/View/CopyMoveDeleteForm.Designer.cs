
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
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(137, 207);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(307, 42);
            this.progressBar.TabIndex = 11;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(170, 138);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(227, 17);
            this.textLabel.TabIndex = 10;
            this.textLabel.Text = "The name of the file being copyed:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileNameTextBox.Location = new System.Drawing.Point(173, 158);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(221, 15);
            this.fileNameTextBox.TabIndex = 9;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.Location = new System.Drawing.Point(245, 84);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(63, 25);
            this.Label.TabIndex = 8;
            this.Label.Text = "Copy";
            // 
            // CopyMoveDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 333);
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
    }
}