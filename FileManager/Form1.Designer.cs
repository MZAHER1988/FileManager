namespace FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.newFolderButton = new System.Windows.Forms.Button();
            this.newFileButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.Btn_copy = new System.Windows.Forms.Button();
            this.Btn_cut = new System.Windows.Forms.Button();
            this.Btn_paste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backButton.Location = new System.Drawing.Point(14, 16);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(88, 30);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.iconList;
            this.listView1.Location = new System.Drawing.Point(3, 141);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(926, 444);
            this.listView1.SmallImageList = this.iconList;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView1_ItemSelectionChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "txt-file.png");
            this.iconList.Images.SetKeyName(1, "zip.png");
            this.iconList.Images.SetKeyName(2, "file.png.png");
            this.iconList.Images.SetKeyName(3, "doc.png");
            this.iconList.Images.SetKeyName(4, "pdf.png.png");
            this.iconList.Images.SetKeyName(5, "mp3.png");
            this.iconList.Images.SetKeyName(6, "mp4.png.png");
            this.iconList.Images.SetKeyName(7, "exe,png.png");
            this.iconList.Images.SetKeyName(8, "image.png");
            this.iconList.Images.SetKeyName(9, "extension.png");
            this.iconList.Images.SetKeyName(10, "xlsx.png");
            this.iconList.Images.SetKeyName(11, "csv.png");
            this.iconList.Images.SetKeyName(12, "ppt.png");
            this.iconList.Images.SetKeyName(13, "html.png");
            this.iconList.Images.SetKeyName(14, "css.png");
            this.iconList.Images.SetKeyName(15, "js-file.png");
            this.iconList.Images.SetKeyName(16, "json-file.png");
            this.iconList.Images.SetKeyName(17, "xml.png");
            this.iconList.Images.SetKeyName(18, "py.png");
            this.iconList.Images.SetKeyName(19, "rar (1).png");
            this.iconList.Images.SetKeyName(20, "folder.png.png");
            this.iconList.Images.SetKeyName(21, "unknown.png.png");
            this.iconList.Images.SetKeyName(22, "hard-drive.png");
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.Location = new System.Drawing.Point(108, 18);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(716, 25);
            this.filePathTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Name";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoEllipsis = true;
            this.FileNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(80, 69);
            this.FileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(250, 17);
            this.FileNameLabel.TabIndex = 5;
            this.FileNameLabel.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Type";
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.AutoEllipsis = true;
            this.FileTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileTypeLabel.Location = new System.Drawing.Point(80, 99);
            this.FileTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(250, 17);
            this.FileTypeLabel.TabIndex = 7;
            this.FileTypeLabel.Text = "--";
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.BackColor = System.Drawing.SystemColors.HighlightText;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.goButton.Location = new System.Drawing.Point(832, 16);
            this.goButton.Margin = new System.Windows.Forms.Padding(4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(88, 30);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // newFolderButton
            // 
            this.newFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFolderButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.newFolderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newFolderButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFolderButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.newFolderButton.Location = new System.Drawing.Point(366, 103);
            this.newFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.newFolderButton.Name = "newFolderButton";
            this.newFolderButton.Size = new System.Drawing.Size(133, 30);
            this.newFolderButton.TabIndex = 8;
            this.newFolderButton.Text = "New Folder";
            this.newFolderButton.UseVisualStyleBackColor = false;
            this.newFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
            // 
            // newFileButton
            // 
            this.newFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFileButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.newFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.newFileButton.Location = new System.Drawing.Point(506, 103);
            this.newFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(133, 30);
            this.newFileButton.TabIndex = 9;
            this.newFileButton.Text = "New File";
            this.newFileButton.UseVisualStyleBackColor = false;
            this.newFileButton.Click += new System.EventHandler(this.NewFileButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.renameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.renameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.renameButton.Location = new System.Drawing.Point(646, 103);
            this.renameButton.Margin = new System.Windows.Forms.Padding(4);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(133, 30);
            this.renameButton.TabIndex = 10;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = false;
            this.renameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.deleteButton.Location = new System.Drawing.Point(786, 103);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(133, 30);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Btn_copy
            // 
            this.Btn_copy.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_copy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_copy.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Btn_copy.Location = new System.Drawing.Point(366, 65);
            this.Btn_copy.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_copy.Name = "Btn_copy";
            this.Btn_copy.Size = new System.Drawing.Size(133, 30);
            this.Btn_copy.TabIndex = 12;
            this.Btn_copy.Text = "Copy";
            this.Btn_copy.UseVisualStyleBackColor = false;
            this.Btn_copy.Click += new System.EventHandler(this.Btn_copy_Click);
            // 
            // Btn_cut
            // 
            this.Btn_cut.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_cut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cut.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Btn_cut.Location = new System.Drawing.Point(506, 64);
            this.Btn_cut.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cut.Name = "Btn_cut";
            this.Btn_cut.Size = new System.Drawing.Size(133, 30);
            this.Btn_cut.TabIndex = 13;
            this.Btn_cut.Text = "Cut";
            this.Btn_cut.UseVisualStyleBackColor = false;
            this.Btn_cut.Click += new System.EventHandler(this.Btn_cut_Click);
            // 
            // Btn_paste
            // 
            this.Btn_paste.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_paste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_paste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_paste.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_paste.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Btn_paste.Location = new System.Drawing.Point(646, 65);
            this.Btn_paste.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_paste.Name = "Btn_paste";
            this.Btn_paste.Size = new System.Drawing.Size(133, 30);
            this.Btn_paste.TabIndex = 14;
            this.Btn_paste.Text = "Paste";
            this.Btn_paste.UseVisualStyleBackColor = false;
            this.Btn_paste.Click += new System.EventHandler(this.Btn_paste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(933, 588);
            this.Controls.Add(this.Btn_paste);
            this.Controls.Add(this.Btn_cut);
            this.Controls.Add(this.Btn_copy);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.newFileButton);
            this.Controls.Add(this.newFolderButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.FileTypeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FileTypeLabel;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button Btn_copy;
        private System.Windows.Forms.Button Btn_cut;
        private System.Windows.Forms.Button Btn_paste;
    }
}

