using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using System.IO;

namespace Utilities
{
    class ControlSettings
    {

        public static string SAVE_CLIENT = "Are you sure you want to add a new client records?";
        public static string UPDATE_CLIENT = "Are you sure you want to update the selected client records?";
        public static string INSUFFICIENT_INPUT = "Please provide the required fields marked with asterisk (*).";
        public static string SELECT_CLIENT = "Please make sure that you have selected a client, by double-clicking " + Environment.NewLine +
                                             "the company name on a list in the left, before you can update it.";

        public static void SetTextToNull(Control sourceForm)
        {
            foreach (Control c in sourceForm.Controls)
            {
                if (c.GetType().Name.Equals("TextBox"))
                    c.Text = "";
            }
        }
        public static bool isAllTextHasValue(Control sourceForm)
        {
            foreach (Control c in sourceForm.Controls)
            {
                if (c.GetType().Name.Equals("TextBox"))
                    if (c.Text.Trim().Equals("")) return false;
            }
            return true;
        }
        public static bool isRadioSelected(Control sourceForm)
        {
            foreach (Control c in sourceForm.Controls)
            {
                if (c.GetType().Name.Equals("RadioButton"))
                {
                    RadioButton radioButton = (RadioButton)c;
                    if (radioButton.Checked) return true;
                }
            }
            return false;
        }
        public static void PopulateComboBox(ComboBox comboBox, string[] contents)
        {
            foreach (string s in contents)
            {
                comboBox.Items.Add(s);
            }
        }       
        public static void SetComboToFirstItem(ComboBox comboBox)
        {
            comboBox.SelectedIndex = 0;
        }
        public static void SetAllRadioButtonToFalse(Control sourceForm)
        {
            foreach (Control c in sourceForm.Controls)
            {
                if (c.GetType().Name.Equals("RadioButton"))
                {
                    RadioButton radioButton = (RadioButton)c;
                    radioButton.Checked = false;
                }
            }
        }
        public static void SetRadioButtonToTrue(RadioButton radioButton)
        {
            radioButton.Checked = true;
        }
        public static void SetAllCheckBoxValue(Control sourceForm, bool setTo)
        {
            foreach (Control c in sourceForm.Controls)
            {
                if (c.GetType().Name.Equals("CheckBox"))
                {
                    CheckBox checkBox = (CheckBox)c;
                    checkBox.Checked = setTo;
                }
            }
        }
        public static void SetControlEnabled(Control sourceForm, bool setTo, String[] listOfControls)
        {
            foreach (Control c in sourceForm.Controls)
            {
                foreach (String controlType in listOfControls)
                {
                    if (c.GetType().Name.Equals(controlType))
                        c.Enabled = setTo;
                }
            }
        }
        public static string RunOpenDialog(string title)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = title;
            openDialog.Multiselect = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
                return openDialog.FileName;
            else
                return "";
        }
        public static void LoadPhoto(PictureBox picClient, string photo)
        {
            Image image;
            FileStream myStream;
            try
            {
                //picClient.Image = Image.FromFile(Application.StartupPath + @"\ClientImages\" + photo);
                myStream = new FileStream(Application.StartupPath + @"\ClientImages\" + photo, FileMode.Open);
                image = Image.FromStream(myStream);
                picClient.Image = image;
                myStream.Dispose();
            }
            catch (Exception ex)
            {
                picClient.Image = Image.FromFile(Application.StartupPath + @"\ClientImages\NoImage.png");
            }

        }   
        public static void NumbersOnly(ref object sender, ref KeyPressEventArgs e, bool withDecPoint)
        {
            if (withDecPoint)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }
        public static double GetTotalProjectCost(ListView lst, int colToSum)
        {
            double sum = 0;
            if (lst.Items.Count != 0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    sum += Convert.ToDouble(lst.Items[i].SubItems[colToSum].Text);
                }
            }
            return sum;
        }
        public static bool IsItemExistsInList(ListView lst, string valueToFind)
        {
            if (lst.Items.Count != 0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (lst.Items[i].Text == valueToFind)
                        return true;
                }
            }
            return false;
        }
        public static bool IsItemExistsInList_withSub(ListView lst, string valueToFind)
        {
            if (lst.Items.Count != 0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (lst.Items[i].SubItems[1].Text.Equals(valueToFind))
                        return true;
                }
            }
            return false;
        }
        public static bool IsItemExistsInList(ListView lst, string valueToFind, int whereToFind)
        {
            if (lst.Items.Count != 0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (lst.Items[i].SubItems[whereToFind].Text == valueToFind)
                        return true;
                }
            }
            return false;
        }
        public static int GetExistsItemIndex(ListView lst, string valueToFind)
        {
            if (lst.Items.Count != 0)
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (lst.Items[i].Text == valueToFind)
                        return i;
                }
            }
            return -1;
        }
        public static void RemoveAllCheckItems(ListView lst)
        {
            if (lst.Items.Count == 0) return;
            for (int i = 0; i < lst.Items.Count; i++)
            {
                try
                {
                    lst.Items[i].Checked = false;
                }
                catch (Exception ex) { }
            }
        }
        public static void SetAllItemToCheck(ListView lst)
        {
            if (lst.Items.Count == 0) return;
            for (int i = 0; i < lst.Items.Count; i++)
            {
                try
                {
                    lst.Items[i].Checked = true;
                }
                catch (Exception ex) { }
            }
        }
        public static string FormatNumberInTextBox(double number)
        {
            try
            {
                return String.Format("{0:N}", number);
            }
            catch (Exception ex) { return "0"; }
        }
        public static void SetCheckItem(ListView lst, int selected, bool findInSub)
        {
            for (int i = 0; i < lst.Items.Count; i++)
            {
                if (findInSub)
                {
                    if (lst.Items[i].SubItems[1].Text == selected.ToString())
                    {
                        lst.Items[i].Checked = true;
                        return;
                    }
                }
                else
                {
                    if (lst.Items[i].Text == selected.ToString())
                    {
                        lst.Items[i].Checked = true;
                        return;
                    }
                }
            }
        }
        public static int GetCheckedItem(ListView lst)
        {
            for (int i = 0; i < lst.Items.Count; i++)
                if (lst.Items[i].Checked == true)
                    return i;
            return -1;
        }
        public static string RemoveQuotes(string sourceStr)
        {
            return sourceStr.Replace("\"", "").Replace("\'", "");
        }
        public static bool DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool OverwriteIfExists)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            DirectoryInfo destinationDirectory = new DirectoryInfo(destDirName);
            
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (destinationDirectory.Exists)
            {
                if (OverwriteIfExists)
                    destinationDirectory.Delete(true);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, OverwriteIfExists);
                }
            }

            //Done;
            return true;

        }
    
    
    
    
    }
}
