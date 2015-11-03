using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using CompressionHelper;
using Utilities;
using FileBackup;

namespace Backup_Creator
{
    public partial class frmMainForm : Form
    {
        OleDbCommand maincommand;
        OleDbConnection mainConnection;
        OleDbDataReader mainReader;
        //Connection String Comment -earlsan
        private static string connectionString;
        private static string OleDBProvider = "Microsoft.ACE.OLEDB.12.0";
        private static string OleDBDataSource = Application.StartupPath + @"\\db_backup.accdb";

        private bool isUpdate = false;
        private string selectedFileID = "";

        private List<FileBackupDetails> filesToBackup = new List<FileBackupDetails>();

        public frmMainForm()
        {
            InitializeComponent();
            InitializeConnection();

            //BackupFile(new FileInfo(@"C:\Spectral\test.xls"), "test_00000.xls", true);
            //CopyFile(new FileInfo(@"C:\Spectral\test.xls"), "test_asdasd.xls", false);
            //this.ZipFile(new FileInfo(@"C:\Spectral\test.xls"), @"C:\Spectral\test.zip");
            //CopyFolder(new DirectoryInfo(@"C:\Spectral\DB"), @"C:\Spectral\DB_BAK", false);
            //BackupFolder(new DirectoryInfo(@"C:\Spectral\DB"), @"C:\Spectral\DB_BAK");
            //ZipFolder(new DirectoryInfo(@"C:\Spectral\DB"), @"C:\Spectral\DB.zip");
        }
        private bool CompressFile(string fileToBeCompressed, string zipFileName)
        {
            try
            {
                using (FileStream target = new FileStream(zipFileName, FileMode.Create, FileAccess.Write))
                using (GZipStream alg = new GZipStream(target, CompressionMode.Compress))
                {
                    byte[] data = File.ReadAllBytes(fileToBeCompressed);
                    alg.Write(data, 0, data.Length);
                    alg.Flush();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void RunMainProcess()
        {
            if (filesToBackup.Count <= 0) return;
            for (int i = 0; i < filesToBackup.Count; i++)
            {
                if (filesToBackup[i].GetScheduleDays().Contains(GetCurrentDayAbbreviated()) &&
                    filesToBackup[i].GetIncludeInRun().Equals("YES") &&
                    filesToBackup[i].GetScheduleTime().Equals(DateTime.Now.ToShortTimeString())){

                    //If it is time to run the backup.
                    FileBackupDetails file = filesToBackup[i];
                    if (file.GetIsFile().Equals("YES")) //For files.
                    {
                        FileInfo fileInfo = new FileInfo(file.GetSourceFileName());
                        if (File.Exists(file.GetDestinationFolder() + "\\" + fileInfo.Name))
                        {
                            if (file.GetOverwriteIfExists().Equals("YES"))
                                CopyFile(fileInfo, file.GetDestinationFolder(), fileInfo.Name, true);
                            else
                            {
                                string fileNameFormatted = GenerateFileNameFormat(fileInfo.Name, file.GetFileNameFormat(), false, false);
                                BackupFile(new FileInfo(file.GetDestinationFolder() + "\\" + fileInfo.Name), fileNameFormatted, false);
                                CopyFile(fileInfo, file.GetDestinationFolder(), fileNameFormatted, false);
                                if (file.GetIsZipFile().Equals("YES"))
                                {
                                    this.ZipFile(new FileInfo(file.GetDestinationFolder() + "\\" + fileNameFormatted), new FileInfo(file.GetDestinationFolder() + "\\" + fileNameFormatted + ".zip").FullName);
                                }
                            }
                        }
                        else
                        {
                            CopyFile(fileInfo, file.GetDestinationFolder(), fileInfo.Name, true);
                        }
                    }
                    else if(file.GetIsFile().Equals("NO")) // for folders.
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(file.GetSourceFileName());

                        if (Directory.Exists(file.GetDestinationFolder() + "\\" + dirInfo.Name))
                        {
                            if (file.GetOverwriteIfExists().Equals("YES"))
                                CopyFolder(dirInfo, @file.GetDestinationFolder() + "\\" + dirInfo.Name, true);
                            else
                            {
                                string folderNameFormatted = GenerateFileNameFormat(dirInfo.Name, file.GetFileNameFormat(), false, true);
                                BackupFolder(new DirectoryInfo(file.GetDestinationFolder() + "\\" + dirInfo.Name) , @file.GetDestinationFolder() + "\\" + folderNameFormatted);
                                CopyFolder(dirInfo, @file.GetDestinationFolder() + "\\" + dirInfo.Name, true);
                                if (file.GetIsZipFile().Equals("YES"))
                                    this.ZipFolder(new DirectoryInfo(file.GetDestinationFolder() + "\\" + folderNameFormatted), new DirectoryInfo(file.GetDestinationFolder() + "\\" + folderNameFormatted + ".zip").FullName);
                            }
                        }
                        else
                        {
                            CopyFolder(dirInfo, file.GetDestinationFolder() + "\\" +  dirInfo.Name, true );
                        }
                    }
                }
            }
        }

        private string GenerateFileNameFormat(string originalFileName, string fileNameFormat, bool overwriteIfExists, bool isFolder)
        {
            //File formats.
            //FILENAME_YYYYDDMM_HHMMSS
            //FILENAME_YYYYDDMM

            int indexOfPeriod = originalFileName.LastIndexOf('.'); //get the location of the last period, to indicate the extension name of the file.
            string extension = (indexOfPeriod < 0 ? "" : originalFileName.Substring(indexOfPeriod)); //Get the file extension name.
            string fileName = originalFileName.Split(new char[] { '.' })[0].ToString(); //Get the file name without the extension name.

            string generatedFileName = ""; //The return file name.

            if (overwriteIfExists)
                generatedFileName = fileName;
            else
            {
                if (fileNameFormat.Equals("FILENAME_YYYYDDMM"))
                    generatedFileName = fileName + "_" + GenerateDate();
                else if (fileNameFormat.Equals("FILENAME_YYYYDDMM_HHMMSS"))
                    generatedFileName = fileName + "_" + GenerateDate() + "_" + GenerateTime();
            }

            if (!isFolder)
                generatedFileName += extension;
            return generatedFileName;
        }
        private string GenerateDate()
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            return year + month + day;
        }
        private string GenerateTime()
        {
            string time = DateTime.Now.ToLongTimeString();
            string [] splitted_time = time.Split(new char[] { ':' });
            string hours = (splitted_time[0].Length == 1 ? "0" + splitted_time[0] : splitted_time[0]);
            string minutes = (splitted_time[1].Length == 1 ? "0" + splitted_time[1] : splitted_time[1]);
            string seconds = (splitted_time[2].Length == 1 ? "0" + splitted_time[2] : splitted_time[2]);

            return hours + minutes + seconds.Split(new char[]{' '})[0].ToString();
        }
        private string GetCurrentDayAbbreviated()
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;
            switch (today.ToString())
            {
                case "Monday": return "M";
                case "Tuesday": return "T";
                case "Wednesday": return "W";
                case "Thursday": return "TH";
                case "Friday": return "F";
                case "Saturday": return "ST";
            }
            return "M";
        }
        private void GetBackupFileDetailsForRun()
        {
            string selectQuery = "SELECT * FROM tblbackupfiles ORDER BY fileid ASC";
            filesToBackup.Clear();
            try
            {
                mainConnection.Open();
                maincommand = new OleDbCommand(selectQuery, mainConnection);
                mainReader = maincommand.ExecuteReader();
                while (mainReader.Read())
                {
                    FileBackupDetails fileBackupDetails = new FileBackupDetails();
                    fileBackupDetails.SetFileID(mainReader["fileid"].ToString());
                    fileBackupDetails.SetFileRemarks(mainReader["file_remarks"].ToString());
                    fileBackupDetails.SetIsFile(mainReader["isfile"].ToString());
                    fileBackupDetails.SetSourceFileName(mainReader["source_file_name"].ToString());
                    fileBackupDetails.SetDestinationFolder(mainReader["destination_folder"].ToString());
                    fileBackupDetails.SetIsScheduled(mainReader["isscheduled"].ToString());
                    fileBackupDetails.SetScheduleTime(mainReader["schedule_time"].ToString());
                    fileBackupDetails.SetScheduleDays(mainReader["schedule_days"].ToString());
                    fileBackupDetails.SetOverwriteIfExists(mainReader["overwrite_if_exists"].ToString());
                    fileBackupDetails.SetFileNameFormat(mainReader["filename_format"].ToString());
                    fileBackupDetails.SetIsZipFile(mainReader["is_zip_file"].ToString());
                    fileBackupDetails.SetIncludeInRun(mainReader["include_in_run"].ToString());

                    filesToBackup.Add(fileBackupDetails);
                }
                mainReader.Close();
                mainReader = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error in your connection : " + ex.Message, " Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mainReader != null)
                    mainReader.Close();
                if (mainConnection.State == System.Data.ConnectionState.Open)
                    mainConnection.Close();
            }
        }
        private void InitializeConnection()
        {
            connectionString = "Provider=" + OleDBProvider +
                               "; Data Source=" + OleDBDataSource +
                               "; Persist Security Info = false";
            try
            {
                mainConnection = new OleDbConnection(connectionString);
                mainConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error in your connection : " + ex.Message, " Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mainConnection.State == System.Data.ConnectionState.Open)
                    mainConnection.Close();
            }
        }
        private string GetDays()
        {
            string retVal = "";

            if (chkM.Checked) retVal += "M,";
            if (chkT.Checked) retVal += "T,";
            if (chkW.Checked) retVal += "W,";
            if (chkTH.Checked) retVal += "TH,";
            if (chF.Checked) retVal += "F,";
            if (chkST.Checked) retVal += "ST,";
            if (chkSU.Checked) retVal += "SU,";

            return (retVal.Length > 0 ? retVal.Substring(0,retVal.Length - 1) : retVal);
        }
        private void UpdateBackupDetails()
        {
            string updateQuery = "UPDATE tblBackupFiles SET file_remarks = '" + txtFileRemarks.Text + "'," +
                                 "isfile = " + chkFile.Checked + ",source_file_name = '" + txtSourceFile.Text + "'," +
                                 "destination_folder = '" + txtDestinationFolder.Text + "', isscheduled = " + ckScheduled.Checked + "," +
                                 "schedule_time = '" + dtBackupTime.Value.ToShortTimeString() + "', schedule_days = '" + GetDays() + "'," +
                                 "overwrite_if_exists = " + chkOverwrite.Checked + ", filename_format = '" + cmbFileFomat.Text + "'," +
                                 "is_zip_file=" + chkCompressFile.Checked + ", include_in_run = " + chkIncludeInRun.Checked + " " +
                                 "WHERE fileid = " + selectedFileID;
            DialogResult result = MessageBox.Show("Are you sure you want to update the selected backup details?", "Update Backup Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    mainConnection.Open();
                    maincommand = new OleDbCommand(updateQuery, mainConnection);
                    int affectedRecords = maincommand.ExecuteNonQuery();
                    if (affectedRecords > 0)
                    {

                        mainConnection.Close();
                        PopulateRecords();
                        ControlSettings.SetTextToNull(grpNewBackup);
                        ControlSettings.SetAllCheckBoxValue(grpNewBackup, false);
                        chkFile.Checked = true;
                        btnSaveBackupDetails.Text = "Save Backup Details";
                        isUpdate = false;
                        MessageBox.Show("Backup Details successfully updated.", "Update Backup File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("There is an error in running the query: " + e.Message);
                }
                finally
                {
                    if (mainConnection.State == ConnectionState.Open)
                        mainConnection.Close();
                }
            }
        }
        private void SaveBackupDetails()
        {
            string insertQuery = "INSERT INTO tblBackupFiles(file_remarks, isfile, source_file_name, destination_folder, "+
                                 "isscheduled, schedule_time, schedule_days, overwrite_if_exists, filename_format, is_zip_file, include_in_run) " +
                                 "VALUES ('" + txtFileRemarks.Text + "'," + chkFile.Checked + ",'" + txtSourceFile.Text + "','" + txtDestinationFolder.Text + "'," +
                                 "" + ckScheduled.Checked + ",'" + dtBackupTime.Value.ToShortTimeString() + "','" + GetDays() + "'," +
                                 "" + chkOverwrite.Checked + ",'" + cmbFileFomat.Text + "'," + chkCompressFile.Checked + "," + chkIncludeInRun.Checked + "  ) ";

            DialogResult result = MessageBox.Show("Proceed in saving the new backup file?", "Save Backup File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    mainConnection.Open();
                    maincommand = new OleDbCommand(insertQuery, mainConnection);
                    int affectedRecords = maincommand.ExecuteNonQuery();
                    if (affectedRecords > 0)
                    {
                        mainConnection.Close();
                        PopulateRecords();
                        ControlSettings.SetTextToNull(grpNewBackup);
                        ControlSettings.SetAllCheckBoxValue(grpNewBackup, false);
                        chkFile.Checked = true;
                        btnSaveBackupDetails.Text = "Save Backup Details";
                        MessageBox.Show("New backup details successfully saved.", "Save Backup File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("There is an error in running the query: " + e.Message);
                }
                finally
                {
                    if (mainConnection.State == ConnectionState.Open)
                        mainConnection.Close();
                }
            }

        }
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            PopulateRecords();
        }
        private void btnSaveBackupDetails_Click(object sender, EventArgs e)
        {
            if ((txtSourceFile.Text.Length == 0) || (txtDestinationFolder.Text.Length == 0)) return;

            if (((chkFile.Checked) && (IsPathAFile(txtSourceFile.Text))) || ((!chkFile.Checked) && (IsPathDirectory(txtSourceFile.Text))))
            {
                if (isUpdate)
                    UpdateBackupDetails();
                else
                    SaveBackupDetails();
            }
            else
            {
                MessageBox.Show("There is a problem saving the backup file. You either ticked 'File' but the source file is not a valid file " + Environment.NewLine +
                                " or you did not tick 'File' but the source folder is not a valid folder. ", "Save Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (chkFile.Checked)
                txtSourceFile.Text = GetFileName();
            else
                txtSourceFile.Text = GetFolderLocations();

        }
        private bool IsPathDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(@path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return true;
            else
                return false;
        }
        private bool IsPathAFile(string path)
        {
            FileAttributes attr = File.GetAttributes(@path);

            FileInfo fileInfo = new FileInfo(@path);
            if ((fileInfo.Exists) && (Path.GetExtension(@path).Length != 0))
                return true;

            return false;
        }
        private string GetFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;
            else return "";
        }
        private string GetFolderLocations()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                return folderBrowserDialog.SelectedPath;
            else return "";
        }
        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            txtDestinationFolder.Text = GetFolderLocations();
        }
        public void PopulateRecords()
        {
            string populateQuery = "SELECT * FROM tblbackupfiles ORDER BY fileid";
            lstAllBackupFiles.Items.Clear();

            try
            {
                mainConnection.Open();
                maincommand = new OleDbCommand(populateQuery, mainConnection);
                OleDbDataReader reader = maincommand.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["file_remarks"].ToString());
                    item.SubItems.Add(reader["source_file_name"].ToString());
                    item.SubItems.Add(reader["destination_folder"].ToString());
                    item.SubItems.Add((reader["isscheduled"].ToString().Equals("0")? "NO" : "YES"));
                    item.SubItems.Add(reader["schedule_time"].ToString());
                    item.SubItems.Add(reader["schedule_days"].ToString());
                    item.SubItems.Add((reader["filename_format"].ToString().Equals("0") ? "NO" : "YES"));
                    item.SubItems.Add(reader["fileid"].ToString());
                    lstAllBackupFiles.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("There is an error in running the query: " + e.Message);
            }
            finally
            {
                if (mainConnection.State == ConnectionState.Open)
                    mainConnection.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Run the Backup Process for specified files and folder?", "Run Backup Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                GetBackupFileDetailsForRun();
                RunMainProcess();
                //ProcessBackupOnScheduledFiles();
            }
        }
        private void tmrRunUpdate_Tick(object sender, EventArgs e)
        {
            GetBackupFileDetailsForRun();
            RunMainProcess();
            //ProcessBackupOnScheduledFiles();
        }
        private void lstAllBackupFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lstAllBackupFiles.Items.Count != 0)
            {
                try
                {
                    selectedFileID = lstAllBackupFiles.SelectedItems[0].SubItems[7].Text;
                    GetFileBackupDetailsForUpdate();
                }
                catch (Exception ex)
                {
                    selectedFileID = "";
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private bool IsDayExists(string[] days, string day)
        {
            for (int i = 0; i < days.Length; i++)
                if (days[i].Equals(day))
                    return true;
            return false;
        }
        private void GetFileBackupDetailsForUpdate()
        {
            string selectQuery = "SELECT * FROM tblbackupfiles WHERE fileid = " + selectedFileID + " ORDER BY fileid";
            try
            {
                mainConnection.Open();
                maincommand = new OleDbCommand(selectQuery, mainConnection);
                mainReader = maincommand.ExecuteReader();
                if (mainReader.HasRows)
                {
                    mainReader.Read();
                    txtFileRemarks.Text = mainReader["file_remarks"].ToString();
                    chkFile.Checked = (mainReader["isfile"].ToString().Equals("True") ? true : false);
                    txtSourceFile.Text = mainReader["source_file_name"].ToString();
                    txtDestinationFolder.Text = mainReader["destination_folder"].ToString();
                    ckScheduled.Checked = (mainReader["isscheduled"].ToString().Equals("True") ? true : false);
                    dtBackupTime.Value = Convert.ToDateTime(mainReader["schedule_time"].ToString());
                    string sched_days = mainReader["schedule_days"].ToString();
                    chkM.Checked = sched_days.Contains("M");
                    chkT.Checked = sched_days.Contains("T");
                    chkW.Checked = sched_days.Contains("W");
                    chkTH.Checked = sched_days.Contains("TH");
                    chF.Checked = sched_days.Contains("F");
                    chkST.Checked = sched_days.Contains("ST");
                    chkSU.Checked = sched_days.Contains("SU");
                    chkOverwrite.Checked = (mainReader["overwrite_if_exists"].ToString().Equals("True") ? true : false);
                    cmbFileFomat.Text = mainReader["filename_format"].ToString();
                    chkCompressFile.Checked = (mainReader["is_zip_file"].ToString().Equals("True") ? true : false);
                    chkIncludeInRun.Checked = (mainReader["include_in_run"].ToString().Equals("True") ? true : false);
                    mainReader.Close();
                    isUpdate = true;
                    btnSaveBackupDetails.Text = "Update Backup Details";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (mainConnection.State == System.Data.ConnectionState.Open)
                    mainConnection.Close();
            }
        }
        private void BackupFile(FileInfo file, string newFileName, bool overwrite)
        {
            try
            {
                string path = file.FullName.Substring(0, file.FullName.Length - (file.Name.Length + 1));
                file.CopyTo(path + "\\" + newFileName, overwrite);
            }
            catch (Exception e)
            {
                //Log file for error.
            }
            finally
            {
                file = null;
            }
        }
        private void CopyFile(FileInfo file, string destinationFolder ,string newFileName, bool overwrite)
        {
            try
            {
                file.CopyTo(destinationFolder + "\\" + newFileName, overwrite);
            }
            catch (Exception e)
            {
                //Log file for error.
            }
            finally
            {
                file = null;
            }
        }
        private bool ZipFile(FileInfo file, string zipFileName)
        {
            bool result = false;
            try
            {
                result = CompressFile(file.FullName, zipFileName);
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        private void CopyFolder(DirectoryInfo sourceDirectory, string newFolderName, bool overwrite)
        {
            try
            {
                ControlSettings.DirectoryCopy(sourceDirectory.FullName, newFolderName, true, overwrite);
            }
            catch (Exception e)
            {
                //Logging for error.
            }
            finally
            {
                sourceDirectory = null;
            }
        }
        private void BackupFolder(DirectoryInfo sourceDirectory, string newFolderName)
        {
            try
            {
                sourceDirectory.MoveTo(newFolderName);
            }
            catch (Exception e)
            {
                //Logging for error.
            }
            finally
            {
                sourceDirectory = null;
            }
        }
        private void ZipFolder(DirectoryInfo folderToZip, string zipFileName)
        {
            try
            {
                System.IO.Compression.ZipFile.CreateFromDirectory(folderToZip.FullName, zipFileName);
            }
            catch (Exception e)
            {
                //Logging for possible errors.
            }
            finally
            {
                folderToZip = null;
            }
        }
    }
}
