namespace GraphGen
{
    partial class Form1
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
            lstPoints = new ListBox();
            btnImportCsv = new Button();
            btnImporterApi = new Button();
            SuspendLayout();
            // 
            // lstPoints
            // 
            lstPoints.FormattingEnabled = true;
            lstPoints.ItemHeight = 15;
            lstPoints.Location = new Point(200, 38);
            lstPoints.Name = "lstPoints";
            lstPoints.Size = new Size(393, 94);
            lstPoints.TabIndex = 0;
            // 
            // btnImportCsv
            // 
            btnImportCsv.Location = new Point(305, 188);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(176, 23);
            btnImportCsv.TabIndex = 1;
            btnImportCsv.Text = "Importer CSV";
            btnImportCsv.UseVisualStyleBackColor = true;
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // btnImporterApi
            // 
            btnImporterApi.Location = new Point(305, 262);
            btnImporterApi.Name = "btnImporterApi";
            btnImporterApi.Size = new Size(176, 23);
            btnImporterApi.TabIndex = 2;
            btnImporterApi.Text = "Importer API (EUR/USD)";
            btnImporterApi.UseVisualStyleBackColor = true;
            btnImporterApi.Click += btnImportApi_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnImporterApi);
            Controls.Add(btnImportCsv);
            Controls.Add(lstPoints);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstPoints;
        private Button btnImportCsv;
        private Button btnImporterApi;
    }
}
