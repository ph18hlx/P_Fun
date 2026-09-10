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
            btnImportCsv = new Button();
            btnImporterApi = new Button();
            clbSeries = new CheckedListBox();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            chkNormaliser = new CheckBox();
            SuspendLayout();
            // 
            // btnImportCsv
            // 
            btnImportCsv.Location = new Point(12, 112);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(120, 23);
            btnImportCsv.TabIndex = 1;
            btnImportCsv.Text = "Importer CSV";
            btnImportCsv.UseVisualStyleBackColor = true;
            btnImportCsv.Click += btnImportCsv_Click;
            // 
            // btnImporterApi
            // 
            btnImporterApi.Location = new Point(12, 141);
            btnImporterApi.Name = "btnImporterApi";
            btnImporterApi.Size = new Size(120, 23);
            btnImporterApi.TabIndex = 2;
            btnImporterApi.Text = "Importer API (EUR/USD)";
            btnImporterApi.UseVisualStyleBackColor = true;
            btnImporterApi.Click += btnImportApi_Click;
            // 
            // clbSeries
            // 
            clbSeries.FormattingEnabled = true;
            clbSeries.Location = new Point(12, 12);
            clbSeries.Name = "clbSeries";
            clbSeries.Size = new Size(120, 94);
            clbSeries.TabIndex = 3;
            clbSeries.ItemCheck += clbSeries_ItemCheck;
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(138, 48);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(798, 489);
            formsPlot1.TabIndex = 4;
            // 
            // chkNormaliser
            // 
            chkNormaliser.AutoSize = true;
            chkNormaliser.Location = new Point(12, 170);
            chkNormaliser.Name = "chkNormaliser";
            chkNormaliser.Size = new Size(105, 19);
            chkNormaliser.TabIndex = 5;
            chkNormaliser.Text = "Normaliser (%)";
            chkNormaliser.UseVisualStyleBackColor = true;
            chkNormaliser.CheckedChanged += chkNormaliser_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(chkNormaliser);
            Controls.Add(formsPlot1);
            Controls.Add(clbSeries);
            Controls.Add(btnImporterApi);
            Controls.Add(btnImportCsv);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnImportCsv;
        private Button btnImporterApi;
        private CheckedListBox clbSeries;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private CheckBox chkNormaliser;
    }
}
