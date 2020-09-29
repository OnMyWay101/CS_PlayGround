namespace ListViewCombo
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
            this.cbListViewCombo = new System.Windows.Forms.ComboBox();
            this.myListView1 = new InheritedListView.MyListView();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.cbListViewCombo.FormattingEnabled = true;
            this.cbListViewCombo.Location = new System.Drawing.Point(12, 318);
            this.cbListViewCombo.Name = "comboBox1";
            this.cbListViewCombo.Size = new System.Drawing.Size(121, 20);
            this.cbListViewCombo.TabIndex = 1;
            this.cbListViewCombo.Visible = false;
            // 
            // myListView1
            // 
            this.myListView1.Location = new System.Drawing.Point(22, 13);
            this.myListView1.Name = "myListView1";
            this.myListView1.Size = new System.Drawing.Size(643, 287);
            this.myListView1.TabIndex = 2;
            this.myListView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 484);
            this.Controls.Add(this.myListView1);
            this.Controls.Add(this.cbListViewCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbListViewCombo;
        private InheritedListView.MyListView myListView1;
    }
}

