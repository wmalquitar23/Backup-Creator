using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileBackup
{
    class FileBackupDetails
    {
        private string fileID;
        private string fileRemarks;
        private string isFile;
        private string sourceFileName;
        private string destinationFolder;
        private string isScheduled;
        private string scheduleTime;
        private string scheduleDays;
        private string overwriteIfExists;
        private string fileNameFormat;
        private string isZipFile;
        private string includeInRun;

        public FileBackupDetails()
        {
            this.fileID = "";
            this.fileRemarks = "";
            this.isFile = "";
            this.sourceFileName = "";
            this.destinationFolder = "";
            this.isScheduled = "";
            this.scheduleTime = "";
            this.scheduleDays = "";
            this.overwriteIfExists = "";
            this.fileNameFormat = "";
            this.isZipFile = "";
            this.includeInRun = "";
        }

        public void SetFileID(string value)
        {
            this.fileID = value;
        }
        public string GetFileID() { return this.fileID; }
        public void SetFileRemarks(string value)
        {
            this.fileRemarks = value;
        }
        public string GetFileRemarks() { return this.fileRemarks; }
        public void SetIsFile(string value)
        {
            this.isFile = (value.Equals("True") ? "YES" : "NO");
        }
        public string GetIsFile() { return this.isFile; }
        public void SetSourceFileName(string value)
        {
            this.sourceFileName = @value;
        }
        public string GetSourceFileName() { return this.sourceFileName; }
        public void SetDestinationFolder(string value)
        {
            this.destinationFolder = @value;
        }
        public string GetDestinationFolder() { return this.destinationFolder; }
        public void SetIsScheduled(string value)
        {
            this.isScheduled = (value.Equals("True") ? "YES" : "NO");
        }
        public string GetIsScheduled() { return this.isScheduled; }
        public void SetScheduleTime(string value)
        {
            this.scheduleTime = value;
        }
        public string GetScheduleTime() { return this.scheduleTime; }
        public void SetScheduleDays(string value)
        {
            this.scheduleDays = value;
        }
        public string GetScheduleDays() { return this.scheduleDays; }
        public void SetOverwriteIfExists(string value)
        {
            this.overwriteIfExists = (value.Equals("True") ? "YES" : "NO");
        }
        public string GetOverwriteIfExists() { return this.overwriteIfExists; }
        public void SetFileNameFormat(string value)
        {
            this.fileNameFormat = value;
        }
        public string GetFileNameFormat() { return this.fileNameFormat; }
        public void SetIsZipFile(string value)
        {
            this.isZipFile = (value.Equals("True") ? "YES" : "NO");
        }
        public string GetIsZipFile() { return this.isZipFile; }
        public void SetIncludeInRun(string value)
        {
            this.includeInRun = (value.Equals("True") ? "YES" : "NO");
        }
        public string GetIncludeInRun() { return this.includeInRun; }
    }
}
