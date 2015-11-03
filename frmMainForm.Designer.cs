namespace Backup_Creator
{
    partial class frmMainForm
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
            this.lstAllBackupFiles = new System.Windows.Forms.ListView();
            this.chFileRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSourceFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDestinationFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScheduled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBackupTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBackupDays = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOverwriteIfExists = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.grpNewBackup = new System.Windows.Forms.GroupBox();
            this.chkIncludeInRun = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveBackupDetails = new System.Windows.Forms.Button();
            this.chkCompressFile = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFileFomat = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkSU = new System.Windows.Forms.CheckBox();
            this.chkST = new System.Windows.Forms.CheckBox();
            this.chF = new System.Windows.Forms.CheckBox();
            this.chkTH = new System.Windows.Forms.CheckBox();
            this.chkW = new System.Windows.Forms.CheckBox();
            this.chkT = new System.Windows.Forms.CheckBox();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtBackupTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ckScheduled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkFile = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrRunUpdate = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.grpNewBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAllBackupFiles
            // 
            this.lstAllBackupFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileRemarks,
            this.chSourceFile,
            this.chDestinationFolder,
            this.chScheduled,
            this.chBackupTime,
            this.chBackupDays,
            this.chOverwriteIfExists,
            this.chID});
            this.lstAllBackupFiles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAllBackupFiles.FullRowSelect = true;
            this.lstAllBackupFiles.GridLines = true;
            this.lstAllBackupFiles.Location = new System.Drawing.Point(12, 35);
            this.lstAllBackupFiles.Name = "lstAllBackupFiles";
            this.lstAllBackupFiles.Size = new System.Drawing.Size(934, 269);
            this.lstAllBackupFiles.TabIndex = 0;
            this.lstAllBackupFiles.UseCompatibleStateImageBehavior = false;
            this.lstAllBackupFiles.View = System.Windows.Forms.View.Details;
            this.lstAllBackupFiles.DoubleClick += new System.EventHandler(this.lstAllBackupFiles_DoubleClick);
            // 
            // chFileRemarks
            // 
            this.chFileRemarks.Text = "File Remarks";
            this.chFileRemarks.Width = 170;
            // 
            // chSourceFile
            // 
            this.chSourceFile.Text = "Source File/Folder";
            this.chSourceFile.Width = 200;
            // 
            // chDestinationFolder
            // 
            this.chDestinationFolder.Text = "Destination Folder";
            this.chDestinationFolder.Width = 200;
            // 
            // chScheduled
            // 
            this.chScheduled.Text = "Scheduled?";
            this.chScheduled.Width = 80;
            // 
            // chBackupTime
            // 
            this.chBackupTime.Text = "Backup Time";
            this.chBackupTime.Width = 85;
            // 
            // chBackupDays
            // 
            this.chBackupDays.Text = "Backup Days";
            this.chBackupDays.Width = 85;
            // 
            // chOverwriteIfExists
            // 
            this.chOverwriteIfExists.Text = "Overwrite if Exists";
            this.chOverwriteIfExists.Width = 105;
            // 
            // chID
            // 
            this.chID.Text = "FileID";
            this.chID.Width = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files to Backup";
            // 
            // grpNewBackup
            // 
            this.grpNewBackup.Controls.Add(this.chkIncludeInRun);
            this.grpNewBackup.Controls.Add(this.label12);
            this.grpNewBackup.Controls.Add(this.btnSaveBackupDetails);
            this.grpNewBackup.Controls.Add(this.chkCompressFile);
            this.grpNewBackup.Controls.Add(this.label11);
            this.grpNewBackup.Controls.Add(this.cmbFileFomat);
            this.grpNewBackup.Controls.Add(this.label10);
            this.grpNewBackup.Controls.Add(this.chkOverwrite);
            this.grpNewBackup.Controls.Add(this.label9);
            this.grpNewBackup.Controls.Add(this.chkSU);
            this.grpNewBackup.Controls.Add(this.chkST);
            this.grpNewBackup.Controls.Add(this.chF);
            this.grpNewBackup.Controls.Add(this.chkTH);
            this.grpNewBackup.Controls.Add(this.chkW);
            this.grpNewBackup.Controls.Add(this.chkT);
            this.grpNewBackup.Controls.Add(this.chkM);
            this.grpNewBackup.Controls.Add(this.label8);
            this.grpNewBackup.Controls.Add(this.dtBackupTime);
            this.grpNewBackup.Controls.Add(this.label7);
            this.grpNewBackup.Controls.Add(this.ckScheduled);
            this.grpNewBackup.Controls.Add(this.label6);
            this.grpNewBackup.Controls.Add(this.btnBrowseDestination);
            this.grpNewBackup.Controls.Add(this.btnBrowseSource);
            this.grpNewBackup.Controls.Add(this.txtDestinationFolder);
            this.grpNewBackup.Controls.Add(this.txtSourceFile);
            this.grpNewBackup.Controls.Add(this.label5);
            this.grpNewBackup.Controls.Add(this.label4);
            this.grpNewBackup.Controls.Add(this.chkFile);
            this.grpNewBackup.Controls.Add(this.label3);
            this.grpNewBackup.Controls.Add(this.txtFileRemarks);
            this.grpNewBackup.Controls.Add(this.label2);
            this.grpNewBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNewBackup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpNewBackup.Location = new System.Drawing.Point(12, 327);
            this.grpNewBackup.Name = "grpNewBackup";
            this.grpNewBackup.Size = new System.Drawing.Size(934, 181);
            this.grpNewBackup.TabIndex = 2;
            this.grpNewBackup.TabStop = false;
            this.grpNewBackup.Text = "New Backup Details";
            // 
            // chkIncludeInRun
            // 
            this.chkIncludeInRun.AutoSize = true;
            this.chkIncludeInRun.Checked = true;
            this.chkIncludeInRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeInRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIncludeInRun.Location = new System.Drawing.Point(772, 30);
            this.chkIncludeInRun.Name = "chkIncludeInRun";
            this.chkIncludeInRun.Size = new System.Drawing.Size(12, 11);
            this.chkIncludeInRun.TabIndex = 3;
            this.chkIncludeInRun.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label12.Location = new System.Drawing.Point(684, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Include to Run";
            // 
            // btnSaveBackupDetails
            // 
            this.btnSaveBackupDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBackupDetails.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSaveBackupDetails.Location = new System.Drawing.Point(829, 121);
            this.btnSaveBackupDetails.Name = "btnSaveBackupDetails";
            this.btnSaveBackupDetails.Size = new System.Drawing.Size(95, 40);
            this.btnSaveBackupDetails.TabIndex = 20;
            this.btnSaveBackupDetails.Text = "Save Backup Details";
            this.btnSaveBackupDetails.UseVisualStyleBackColor = true;
            this.btnSaveBackupDetails.Click += new System.EventHandler(this.btnSaveBackupDetails_Click);
            // 
            // chkCompressFile
            // 
            this.chkCompressFile.AutoSize = true;
            this.chkCompressFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCompressFile.Location = new System.Drawing.Point(772, 143);
            this.chkCompressFile.Name = "chkCompressFile";
            this.chkCompressFile.Size = new System.Drawing.Size(12, 11);
            this.chkCompressFile.TabIndex = 19;
            this.chkCompressFile.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label11.Location = new System.Drawing.Point(684, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Compress File?";
            // 
            // cmbFileFomat
            // 
            this.cmbFileFomat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileFomat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFileFomat.FormattingEnabled = true;
            this.cmbFileFomat.Items.AddRange(new object[] {
            "FILENAME_YYYYDDMM_HHMMSS",
            "FILENAME_YYYYDDMM"});
            this.cmbFileFomat.Location = new System.Drawing.Point(456, 138);
            this.cmbFileFomat.Name = "cmbFileFomat";
            this.cmbFileFomat.Size = new System.Drawing.Size(202, 23);
            this.cmbFileFomat.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(311, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "File/Folder Name Format";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOverwrite.Location = new System.Drawing.Point(209, 148);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(12, 11);
            this.chkOverwrite.TabIndex = 17;
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(6, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Overwrite if the File or Folder exists?";
            // 
            // chkSU
            // 
            this.chkSU.AutoSize = true;
            this.chkSU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSU.Location = new System.Drawing.Point(655, 105);
            this.chkSU.Name = "chkSU";
            this.chkSU.Size = new System.Drawing.Size(38, 19);
            this.chkSU.TabIndex = 16;
            this.chkSU.Text = "SU";
            this.chkSU.UseVisualStyleBackColor = true;
            // 
            // chkST
            // 
            this.chkST.AutoSize = true;
            this.chkST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkST.Location = new System.Drawing.Point(612, 105);
            this.chkST.Name = "chkST";
            this.chkST.Size = new System.Drawing.Size(37, 19);
            this.chkST.TabIndex = 15;
            this.chkST.Text = "ST";
            this.chkST.UseVisualStyleBackColor = true;
            // 
            // chF
            // 
            this.chF.AutoSize = true;
            this.chF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chF.Location = new System.Drawing.Point(571, 105);
            this.chF.Name = "chF";
            this.chF.Size = new System.Drawing.Size(29, 19);
            this.chF.TabIndex = 14;
            this.chF.Text = "F";
            this.chF.UseVisualStyleBackColor = true;
            // 
            // chkTH
            // 
            this.chkTH.AutoSize = true;
            this.chkTH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTH.Location = new System.Drawing.Point(527, 105);
            this.chkTH.Name = "chkTH";
            this.chkTH.Size = new System.Drawing.Size(39, 19);
            this.chkTH.TabIndex = 13;
            this.chkTH.Text = "TH";
            this.chkTH.UseVisualStyleBackColor = true;
            // 
            // chkW
            // 
            this.chkW.AutoSize = true;
            this.chkW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkW.Location = new System.Drawing.Point(487, 105);
            this.chkW.Name = "chkW";
            this.chkW.Size = new System.Drawing.Size(35, 19);
            this.chkW.TabIndex = 12;
            this.chkW.Text = "W";
            this.chkW.UseVisualStyleBackColor = true;
            // 
            // chkT
            // 
            this.chkT.AutoSize = true;
            this.chkT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkT.Location = new System.Drawing.Point(457, 105);
            this.chkT.Name = "chkT";
            this.chkT.Size = new System.Drawing.Size(30, 19);
            this.chkT.TabIndex = 11;
            this.chkT.Text = "T";
            this.chkT.UseVisualStyleBackColor = true;
            // 
            // chkM
            // 
            this.chkM.AutoSize = true;
            this.chkM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkM.Location = new System.Drawing.Point(417, 105);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(34, 19);
            this.chkM.TabIndex = 10;
            this.chkM.Text = "M";
            this.chkM.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(312, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Backup Days :";
            // 
            // dtBackupTime
            // 
            this.dtBackupTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtBackupTime.Location = new System.Drawing.Point(209, 104);
            this.dtBackupTime.MinDate = new System.DateTime(2015, 10, 20, 0, 0, 0, 0);
            this.dtBackupTime.Name = "dtBackupTime";
            this.dtBackupTime.Size = new System.Drawing.Size(96, 23);
            this.dtBackupTime.TabIndex = 9;
            this.dtBackupTime.Value = new System.DateTime(2015, 10, 21, 11, 45, 32, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(126, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Backup Time";
            // 
            // ckScheduled
            // 
            this.ckScheduled.AutoSize = true;
            this.ckScheduled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckScheduled.Location = new System.Drawing.Point(76, 111);
            this.ckScheduled.Name = "ckScheduled";
            this.ckScheduled.Size = new System.Drawing.Size(12, 11);
            this.ckScheduled.TabIndex = 8;
            this.ckScheduled.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(6, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Scheduled?";
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(900, 77);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(24, 19);
            this.btnBrowseDestination.TabIndex = 7;
            this.btnBrowseDestination.Text = "...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(900, 45);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(24, 19);
            this.btnBrowseSource.TabIndex = 6;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDestinationFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestinationFolder.Location = new System.Drawing.Point(393, 77);
            this.txtDestinationFolder.Multiline = true;
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(501, 19);
            this.txtDestinationFolder.TabIndex = 5;
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceFile.Location = new System.Drawing.Point(393, 46);
            this.txtSourceFile.Multiline = true;
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.ReadOnly = true;
            this.txtSourceFile.Size = new System.Drawing.Size(501, 19);
            this.txtSourceFile.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(311, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Destination    :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(311, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Source            :";
            // 
            // chkFile
            // 
            this.chkFile.AutoSize = true;
            this.chkFile.Checked = true;
            this.chkFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFile.Location = new System.Drawing.Point(393, 30);
            this.chkFile.Name = "chkFile";
            this.chkFile.Size = new System.Drawing.Size(12, 11);
            this.chkFile.TabIndex = 2;
            this.chkFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(312, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "File?";
            // 
            // txtFileRemarks
            // 
            this.txtFileRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileRemarks.Location = new System.Drawing.Point(9, 46);
            this.txtFileRemarks.Multiline = true;
            this.txtFileRemarks.Name = "txtFileRemarks";
            this.txtFileRemarks.Size = new System.Drawing.Size(296, 48);
            this.txtFileRemarks.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "File/Folder Remarks";
            // 
            // tmrRunUpdate
            // 
            this.tmrRunUpdate.Enabled = true;
            this.tmrRunUpdate.Interval = 1000;
            this.tmrRunUpdate.Tick += new System.EventHandler(this.tmrRunUpdate_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(873, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Force Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpNewBackup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstAllBackupFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Creator - v.1.0";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.grpNewBackup.ResumeLayout(false);
            this.grpNewBackup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstAllBackupFiles;
        private System.Windows.Forms.ColumnHeader chFileRemarks;
        private System.Windows.Forms.ColumnHeader chSourceFile;
        private System.Windows.Forms.ColumnHeader chDestinationFolder;
        private System.Windows.Forms.ColumnHeader chScheduled;
        private System.Windows.Forms.ColumnHeader chBackupTime;
        private System.Windows.Forms.ColumnHeader chBackupDays;
        private System.Windows.Forms.ColumnHeader chOverwriteIfExists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpNewBackup;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSU;
        private System.Windows.Forms.CheckBox chkST;
        private System.Windows.Forms.CheckBox chF;
        private System.Windows.Forms.CheckBox chkTH;
        private System.Windows.Forms.CheckBox chkW;
        private System.Windows.Forms.CheckBox chkT;
        private System.Windows.Forms.CheckBox chkM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtBackupTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckScheduled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.Button btnSaveBackupDetails;
        private System.Windows.Forms.CheckBox chkCompressFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbFileFomat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkIncludeInRun;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer tmrRunUpdate;
        private System.Windows.Forms.Button button1;
    }
}

