namespace FolderSizeTracer
{
    partial class FST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FST));
            this.btnAnalize = new System.Windows.Forms.Button();
            this.panUnits = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.dgwFolders = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwFolders)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnalize
            // 
            this.btnAnalize.Location = new System.Drawing.Point(430, 110);
            this.btnAnalize.Name = "btnAnalize";
            this.btnAnalize.Size = new System.Drawing.Size(164, 23);
            this.btnAnalize.TabIndex = 0;
            this.btnAnalize.Text = "Analizar";
            this.btnAnalize.UseVisualStyleBackColor = true;
            this.btnAnalize.Click += new System.EventHandler(this.btnAnalize_Click);
            // 
            // panUnits
            // 
            this.panUnits.AutoScroll = true;
            this.panUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panUnits.Location = new System.Drawing.Point(33, 33);
            this.panUnits.MaximumSize = new System.Drawing.Size(3000, 100);
            this.panUnits.Name = "panUnits";
            this.panUnits.Size = new System.Drawing.Size(356, 100);
            this.panUnits.TabIndex = 2;
            this.panUnits.Tag = " ";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(33, 14);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(160, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Seleccione la unidad a analizar: ";
            // 
            // dgwFolders
            // 
            this.dgwFolders.AllowUserToAddRows = false;
            this.dgwFolders.AllowUserToDeleteRows = false;
            this.dgwFolders.AllowUserToResizeRows = false;
            this.dgwFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.Size,
            this.NumFiles,
            this.Bytes});
            this.dgwFolders.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgwFolders.Location = new System.Drawing.Point(33, 142);
            this.dgwFolders.Name = "dgwFolders";
            this.dgwFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwFolders.Size = new System.Drawing.Size(1081, 388);
            this.dgwFolders.TabIndex = 4;
            this.dgwFolders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwFolders_CellDoubleClick);
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.HeaderText = "Carpeta";
            this.Path.Name = "Path";
            // 
            // Size
            // 
            this.Size.HeaderText = "Tamaño";
            this.Size.Name = "Size";
            // 
            // NumFiles
            // 
            this.NumFiles.HeaderText = "Archivos";
            this.NumFiles.Name = "NumFiles";
            // 
            // Bytes
            // 
            this.Bytes.HeaderText = "Bytes";
            this.Bytes.Name = "Bytes";
            // 
            // FST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 592);
            this.Controls.Add(this.dgwFolders);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.panUnits);
            this.Controls.Add(this.btnAnalize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FST";
            this.Text = "Localizador de carpetas más ocupadas";
            this.Load += new System.EventHandler(this.FST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwFolders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnalize;
        private System.Windows.Forms.Panel panUnits;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataGridView dgwFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bytes;
    }
}

