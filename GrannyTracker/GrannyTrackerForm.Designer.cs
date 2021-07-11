
namespace GrannyTracker
{
    partial class GrannyTrackerForm
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
            this.grannyMap = new System.Windows.Forms.PictureBox();
            this.debugTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grannyMap)).BeginInit();
            this.SuspendLayout();
            // 
            // grannyMap
            // 
            this.grannyMap.Image = global::GrannyTracker.Properties.Resources.floor1;
            this.grannyMap.Location = new System.Drawing.Point(0, -1);
            this.grannyMap.Name = "grannyMap";
            this.grannyMap.Size = new System.Drawing.Size(747, 406);
            this.grannyMap.TabIndex = 0;
            this.grannyMap.TabStop = false;
            this.grannyMap.Paint += new System.Windows.Forms.PaintEventHandler(this.grannyMap_Paint);
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(0, 411);
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.Size = new System.Drawing.Size(747, 226);
            this.debugTextBox.TabIndex = 1;
            this.debugTextBox.Text = "Test";
            // 
            // GrannyTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 633);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.grannyMap);
            this.Name = "GrannyTrackerForm";
            this.Text = "Granny Tracker by Sychotix";
            ((System.ComponentModel.ISupportInitialize)(this.grannyMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox grannyMap;
        private System.Windows.Forms.RichTextBox debugTextBox;
    }
}

