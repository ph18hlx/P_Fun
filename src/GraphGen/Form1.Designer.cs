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
            dtpDebut = new DateTimePicker();
            dtpFin = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnImportJson = new Button();
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
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.Location = new Point(255, 38);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(700, 489);
            formsPlot1.TabIndex = 4;
            // 
            // chkNormaliser
            // 
            chkNormaliser.AutoSize = true;
            chkNormaliser.Location = new Point(12, 204);
            chkNormaliser.Name = "chkNormaliser";
            chkNormaliser.Size = new Size(105, 19);
            chkNormaliser.TabIndex = 5;
            chkNormaliser.Text = "Normaliser (%)";
            chkNormaliser.UseVisualStyleBackColor = true;
            chkNormaliser.CheckedChanged += chkNormaliser_CheckedChanged;
            // 
            // dtpDebut
            // 
            dtpDebut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpDebut.CustomFormat = "dd.MM.yyyy";
            dtpDebut.Format = DateTimePickerFormat.Custom;
            dtpDebut.Location = new Point(56, 537);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(200, 23);
            dtpDebut.TabIndex = 6;
            dtpDebut.ValueChanged += dtp_ValueChanged;
            // 
            // dtpFin
            // 
            dtpFin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFin.CustomFormat = "dd.MM.yyyy";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.Location = new Point(322, 537);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 7;
            dtpFin.ValueChanged += dtp_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 537);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 8;
            label1.Text = "Du :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 541);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 9;
            label2.Text = "au :";
            // 
            // btnImportJson
            // 
            btnImportJson.Location = new Point(12, 170);
            btnImportJson.Name = "btnImportJson";
            btnImportJson.Size = new Size(120, 23);
            btnImportJson.TabIndex = 10;
            btnImportJson.Text = "Importer JSON";
            btnImportJson.UseVisualStyleBackColor = true;
            btnImportJson.Click += btnImportJson_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(btnImportJson);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFin);
            Controls.Add(dtpDebut);
            Controls.Add(chkNormaliser);
            Controls.Add(formsPlot1);
            Controls.Add(clbSeries);
            Controls.Add(btnImporterApi);
            Controls.Add(btnImportCsv);
            MinimumSize = new Size(900, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PTL - Plot Those Lines";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnImportCsv;
        private Button btnImporterApi;
        private CheckedListBox clbSeries;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private CheckBox chkNormaliser;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private Label label1;
        private Label label2;
        private Button btnImportJson;
    }
}
