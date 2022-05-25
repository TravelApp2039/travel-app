namespace proje
{
    partial class frmVeriAktarimi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linklblJSON = new System.Windows.Forms.LinkLabel();
            this.linklblXML = new System.Windows.Forms.LinkLabel();
            this.linklblHTML = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // linklblJSON
            // 
            this.linklblJSON.AutoSize = true;
            this.linklblJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklblJSON.Location = new System.Drawing.Point(90, 378);
            this.linklblJSON.Name = "linklblJSON";
            this.linklblJSON.Size = new System.Drawing.Size(139, 18);
            this.linklblJSON.TabIndex = 1;
            this.linklblJSON.TabStop = true;
            this.linklblJSON.Text = "JSON ile Raporla";
            this.linklblJSON.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblJSON_LinkClicked);
            // 
            // linklblXML
            // 
            this.linklblXML.AutoSize = true;
            this.linklblXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklblXML.Location = new System.Drawing.Point(345, 378);
            this.linklblXML.Name = "linklblXML";
            this.linklblXML.Size = new System.Drawing.Size(128, 18);
            this.linklblXML.TabIndex = 2;
            this.linklblXML.TabStop = true;
            this.linklblXML.Text = "XML ile Raporla";
            this.linklblXML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblXML_LinkClicked);
            // 
            // linklblHTML
            // 
            this.linklblHTML.AutoSize = true;
            this.linklblHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklblHTML.Location = new System.Drawing.Point(554, 378);
            this.linklblHTML.Name = "linklblHTML";
            this.linklblHTML.Size = new System.Drawing.Size(139, 18);
            this.linklblHTML.TabIndex = 3;
            this.linklblHTML.TabStop = true;
            this.linklblHTML.Text = "HTML ile Raporla";
            this.linklblHTML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblHTML_LinkClicked);
            // 
            // frmVeriAktarimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proje.Properties.Resources._5630974;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linklblHTML);
            this.Controls.Add(this.linklblXML);
            this.Controls.Add(this.linklblJSON);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmVeriAktarimi";
            this.Text = "frmVeriAktarimi";
            this.Load += new System.EventHandler(this.frmVeriAktarimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel linklblJSON;
        private System.Windows.Forms.LinkLabel linklblXML;
        private System.Windows.Forms.LinkLabel linklblHTML;
    }
}