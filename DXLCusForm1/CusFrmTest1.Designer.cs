namespace DXLog.net
{
    partial class ExtraInfoMulti
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
            this.textBoxEdiLogFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowseEdiLogs = new System.Windows.Forms.Button();
            this.labelEdiEntryCount = new System.Windows.Forms.Label();
            this.dataGridViewFoundCalls = new System.Windows.Forms.DataGridView();
            this.buttonPasteEdiLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoundCalls)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEdiLogFolder
            // 
            this.textBoxEdiLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEdiLogFolder.Location = new System.Drawing.Point(135, 15);
            this.textBoxEdiLogFolder.Name = "textBoxEdiLogFolder";
            this.textBoxEdiLogFolder.Size = new System.Drawing.Size(407, 26);
            this.textBoxEdiLogFolder.TabIndex = 2;
            this.textBoxEdiLogFolder.TextChanged += new System.EventHandler(this.textBoxEdiLogFolder_TextChanged);
            this.textBoxEdiLogFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxEdiLogFolder_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "EDI Log Folder: ";
            // 
            // buttonBrowseEdiLogs
            // 
            this.buttonBrowseEdiLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseEdiLogs.Location = new System.Drawing.Point(548, 6);
            this.buttonBrowseEdiLogs.Name = "buttonBrowseEdiLogs";
            this.buttonBrowseEdiLogs.Size = new System.Drawing.Size(75, 42);
            this.buttonBrowseEdiLogs.TabIndex = 4;
            this.buttonBrowseEdiLogs.Text = "Browse";
            this.buttonBrowseEdiLogs.UseVisualStyleBackColor = true;
            this.buttonBrowseEdiLogs.Click += new System.EventHandler(this.buttonBrowseEdiLogs_Click);
            this.buttonBrowseEdiLogs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonBrowseEdiLogs_MouseDown);
            // 
            // labelEdiEntryCount
            // 
            this.labelEdiEntryCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEdiEntryCount.AutoSize = true;
            this.labelEdiEntryCount.Location = new System.Drawing.Point(715, 17);
            this.labelEdiEntryCount.Name = "labelEdiEntryCount";
            this.labelEdiEntryCount.Size = new System.Drawing.Size(76, 20);
            this.labelEdiEntryCount.TabIndex = 5;
            this.labelEdiEntryCount.Text = "Entries: 0";
            // 
            // dataGridViewFoundCalls
            // 
            this.dataGridViewFoundCalls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFoundCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFoundCalls.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewFoundCalls.Name = "dataGridViewFoundCalls";
            this.dataGridViewFoundCalls.RowHeadersWidth = 62;
            this.dataGridViewFoundCalls.RowTemplate.Height = 15;
            this.dataGridViewFoundCalls.Size = new System.Drawing.Size(814, 128);
            this.dataGridViewFoundCalls.TabIndex = 6;
            // 
            // buttonPasteEdiLogs
            // 
            this.buttonPasteEdiLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPasteEdiLogs.Location = new System.Drawing.Point(629, 6);
            this.buttonPasteEdiLogs.Name = "buttonPasteEdiLogs";
            this.buttonPasteEdiLogs.Size = new System.Drawing.Size(80, 42);
            this.buttonPasteEdiLogs.TabIndex = 7;
            this.buttonPasteEdiLogs.Text = "Paste";
            this.buttonPasteEdiLogs.UseVisualStyleBackColor = true;
            this.buttonPasteEdiLogs.Click += new System.EventHandler(this.buttonPasteEdiLogs_Click);
            this.buttonPasteEdiLogs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPasteEdiLogs_MouseDown);
            this.buttonPasteEdiLogs.MouseHover += new System.EventHandler(this.buttonPasteEdiLogs_MouseHover);
            // 
            // ExtraInfoMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 195);
            this.Controls.Add(this.buttonPasteEdiLogs);
            this.Controls.Add(this.dataGridViewFoundCalls);
            this.Controls.Add(this.labelEdiEntryCount);
            this.Controls.Add(this.buttonBrowseEdiLogs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEdiLogFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.FormID = 1000;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraInfoMulti";
            this.Text = "Extra Info Multi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoundCalls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEdiLogFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowseEdiLogs;
        private System.Windows.Forms.Label labelEdiEntryCount;
        private System.Windows.Forms.DataGridView dataGridViewFoundCalls;
        private System.Windows.Forms.Button buttonPasteEdiLogs;
    }
}