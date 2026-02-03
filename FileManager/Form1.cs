using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FileManager
{
    public partial class Form1 : Form
    {
        //private readonly string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\")); // Set the initial file path to the project directory , four levels up from the executable directory
        //private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private string filePath = @"C:\";
        public bool isFile = false;
        private string currentlySelectedItemName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filePathTextBox.Text = filePath;
            loadFilesAndDirectories();
        }

        public void loadFilesAndDirectories()
        {
            DirectoryInfo fileList;
            FileAttributes fileAttr;
            try
            {
                fileAttr = File.GetAttributes(filePath);        // Get the attributes of the current path

                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {

                    fileList = new DirectoryInfo(filePath);                         // Create a DirectoryInfo object for the specified path
                    FileInfo[] files = fileList.GetFiles();                         // Get all files in the directory
                    DirectoryInfo[] directories = fileList.GetDirectories();        // Get all subdirectories in the directory
                    string fileExtension = "";
                    listView1.Items.Clear();


                    for (int i = 0; i < files.Length; i++)
                    {
                        fileExtension = files[i].Extension.ToUpper();
                        switch (fileExtension)
                        {
                            case ".MP3":
                            case ".MP2":
                                listView1.Items.Add(files[i].Name, 5);

                                break;
                            case ".EXE":
                            case ".COM":
                                listView1.Items.Add(files[i].Name, 7);

                                break;
                            case ".MP4":
                            case ".AVI":
                            case ".MKV":
                                listView1.Items.Add(files[i].Name, 6);
                                break;
                            case ".PDF":
                                listView1.Items.Add(files[i].Name, 4);

                                break;
                            case ".DOC":
                            case ".DOCX":
                                listView1.Items.Add(files[i].Name, 3);
                                break;
                            case ".PNG":
                            case ".JPG":
                            case ".JPEG":
                                listView1.Items.Add(files[i].Name, 9);
                                break;

                            default:
                                listView1.Items.Add(files[i].Name, 8);

                                break;
                        }

                    }
                    for (int i = 0; i < directories.Length; i++)
                    {
                        listView1.Items.Add(directories[i].Name, 10);
                    }
                }
                else
                {
                    FileNameLabel.Text = this.currentlySelectedItemName;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void loadButtonAction()
        {

            // Om en MAPP är markerad: navigera till den (sätt rutan först)
            if (!string.IsNullOrEmpty(currentlySelectedItemName))
            {
                string selectedPath = Path.Combine(filePath, currentlySelectedItemName);
                if (Directory.Exists(selectedPath))
                {
                    filePathTextBox.Text = selectedPath;
                }
                // Om en FIL är markerad gör vi inget här – "Gå" ska navigera, inte öppna filer
            }

            removeBackSlash(); // städar textboxen (utan att sabba C:\)

            string input = filePathTextBox.Text;
            if (!Directory.Exists(input))
            {
                MessageBox.Show("Please enter or select a valid folder path.");
                return;
            }

            filePath = input;
            isFile = false;
            loadFilesAndDirectories();



            // removeBackSlash();
            // filePath = filePathTextBox.Text;  
            // isFile = false;
            // loadFilesAndDirectories();
        }

        public void backButtonAction()
        {
            try
            {
                // Alternative approach using Directory.GetParent
                DirectoryInfo parentDir = Directory.GetParent(filePath);                    // Get the parent directory of the current path
                if (parentDir != null)                                                      // Check if the parent directory exists
                {
                    //removeBackSlash();
                    filePath = parentDir.FullName;                                          // Update the filePath variable to the parent directory's full path
                    filePathTextBox.Text = filePath;                                        // Update the text box to reflect the new path
                    isFile = false;                                                         // Reset the isFile flag when navigating up
                    loadFilesAndDirectories();                                              // Load the files and directories in the new path
                    //removeBackSlash();
                    //loadFilesAndDirectories();

                }
                else
                {
                    filePath = "";
                    filePathTextBox.Text = filePath;

                    //isFile = false;
                    loadFilesAndDirectories();
                    MessageBox.Show("No parent directory found.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void removeBackSlash()
        {
            string path = filePathTextBox.Text;


            if (path.EndsWith("/") || path.EndsWith("\\"))
            {
                filePath = filePath.Substring(0, filePath.Length - 1);
            }
        }
        private void goButton_Click(object sender, EventArgs e)
        {
            //loadButtonAction();

            listView1_MouseDoubleClick(this, null);     // Simulate a double-click event to open the selected item after navigating to a new path
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (e.IsSelected == false)
            {
                // If the item is not selected, do nothing and return
                return;
            }

            currentlySelectedItemName = e.Item.Text;                                         // Get the name of the currently selected item in the list view
            string fullPath = Path.Combine(filePath, currentlySelectedItemName);            // Construct the full path of the selected item 

            if (Directory.Exists(fullPath))
            {
                isFile = false;
                FileNameLabel.Text = e.Item.Text;
                FileTypeLabel.Text = "Folder";
            }
            else if (File.Exists(fullPath))
            {
                isFile = true;
                var fi = new FileInfo(fullPath);
                FileNameLabel.Text = fi.Name;
                FileTypeLabel.Text = fi.Extension;
            }
            else
            {
                isFile = false; // okänt
                FileNameLabel.Text = "";
                FileTypeLabel.Text = "";
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //loadButtonAction();
            //string tempFilePath = "";

            if (string.IsNullOrEmpty(currentlySelectedItemName)) return;

            string fullPath = Path.Combine(filePath, currentlySelectedItemName);

            if (Directory.Exists(fullPath))
            {
                // Navigera in i mappen
                filePath = fullPath;
                filePathTextBox.Text = filePath;
                isFile = false;
                loadFilesAndDirectories();
            }
            else if (File.Exists(fullPath))
            {

                // Öppna filen med standardprogram
                try
                {
                    Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });       // Open the file with the default associated application, UseShellExecute is required for .NET Core and .NET 5+ , for .NET Framework it can be omitted, but it's good practice to include it for compatibility

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open file: " + ex.Message);
                }
            }
            return;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backButtonAction();
            //loadButtonAction();
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            string newFolder = "New folder";        // Default name for the new folder, can be modified to take user input
            string targetPath = Path.Combine(filePath, newFolder);  // Construct the full path for the new folder, combining the current path and the new folder name

            if (!Directory.Exists(filePath))        // Check if the current path exists and is a valid directory
            {
                MessageBox.Show("Please select a valid folder first.");
                return;
            }
            while (true)
            {
                newFolder = Interaction.InputBox("Enter the name of the new folder:", "New Folder", "New folder");   // Prompt the user to enter the name of the new folder, with a default value , can be modified to take user input, using Microsoft.VisualBasic, requires adding reference to Microsoft.VisualBasic
                if (string.IsNullOrWhiteSpace(newFolder))    // Check if the new folder name is valid (not empty or whitespace)
                {
                    return;
                }
                if (newFolder.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) // Check if the new folder name contains any invalid characters
                {
                    MessageBox.Show("The folder name contains invalid characters.");
                    continue;
                }
                targetPath = Path.Combine(filePath, newFolder);  // Construct the full path for the new folder, combining the current path and the new folder name

                if (Directory.Exists(targetPath) || File.Exists(targetPath))
                {
                    MessageBox.Show("A file or directory with the same name already exists.");
                    continue;
                }

                try
                {
                    Directory.CreateDirectory(targetPath);  // Create the new directory at the specified path, will throw an exception if it fails
                    loadFilesAndDirectories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in new folder!" + ex.Message);
                }
                break;
            }

        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(filePath))                                                                    // Check if the current path exists and is a valid directory
            {
                MessageBox.Show("Please select a valid folder first.");
                return;
            }
            while (true)
            {
                string newFile = Interaction.InputBox
                    ("Enter the name of the new file (with extension):", "New File", "NewTextDocument.txt");    // Prompt the user to enter the name of the new file, with a default value , can be modified to take user input, using Microsoft.VisualBasic, requires adding reference to Microsoft.VisualBasic


                if (string.IsNullOrWhiteSpace(newFile))                                                         // Check if the new file name is valid (not empty or whitespace)
                {
                    return;
                }
                if (newFile.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)                                    // Check if the new file name contains any invalid characters
                {
                    MessageBox.Show("The file name contains invalid characters.");
                    continue;
                }

                string targetPath = Path.Combine(filePath, newFile);                                            // Construct the full path for the new file, combining the current path and the new file name

                try
                {
                    if (File.Exists(targetPath) || Directory.Exists(targetPath))
                    {
                        MessageBox.Show("A file or directory with the same name already exists.");
                        continue;
                    }

                    using (FileStream fs = File.Create(targetPath))                                            // Create the new file at the specified path, will throw an exception if it fails
                    {
                    }
                    loadFilesAndDirectories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating new file: " + ex.Message);
                }

                break;
            }

        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentlySelectedItemName))                            // Check if an item is selected in the list view
            {
                MessageBox.Show("Please select a file or folder to rename.");
                return;
            }

            string oldPath = Path.Combine(filePath, currentlySelectedItemName);             // Construct the full path of the selected item to be renamed
            bool isDirectory = Directory.Exists(oldPath);                                   // Check if the selected item is a directory
            bool isFile = File.Exists(oldPath);                                             // Check if the selected item is a file
            if (!isDirectory && !isFile)                                                    // If the selected item does not exist, show an error message
            {
                MessageBox.Show("The selected item does not exist.");
                loadFilesAndDirectories();
                return;
            }

            while (true)
            {
                string newName = Interaction.InputBox("Enter the new name for the selected item:", "Rename Item", currentlySelectedItemName);   // Prompt the user to enter the new name for the selected item, with the current name as default value, can be modified to take user input, using Microsoft.VisualBasic, requires adding reference to Microsoft.VisualBasic


                if (string.IsNullOrWhiteSpace(newName))
                {
                    return;
                }
                if (newName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)                     // Check if the new name contains any invalid characters
                {
                    MessageBox.Show("The new name contains invalid characters.");
                    continue;
                }
                if (newName == currentlySelectedItemName)                                       // Check if the new name is the same as the current name
                {
                    continue;                                                                   // If so, do nothing and return
                }

                string newPath = Path.Combine(filePath, newName);

                if (File.Exists(Path.Combine(filePath, newName)) || Directory.Exists(Path.Combine(filePath, newName)))
                {
                    MessageBox.Show("A file or directory with the same name already exists.");
                    continue;
                }

                // Construct the full path for the renamed item
                try
                {
                    if (isDirectory)
                    {
                        Directory.Move(oldPath, newPath);                                       // Rename the directory
                    }
                    else if (isFile)
                    {
                        File.Move(oldPath, newPath);                                            // Rename the file
                    }
                    currentlySelectedItemName = newName;                                        // Update the currently selected item name to the new name
                    loadFilesAndDirectories();                                                  // Reload the files and directories to reflect the change
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error renaming item: " + ex.Message);
                }
                loadFilesAndDirectories();
                break;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentlySelectedItemName))                                    // Check if an item is selected in the list view
            {
                MessageBox.Show("Please select a file or folder to delete.");
                return;
            }
            string targetPath = Path.Combine(filePath, currentlySelectedItemName);                  // Construct the full path of the selected item to be deleted
            bool isDirectory = Directory.Exists(targetPath);                                        // Check if the selected item is a directory
            bool isFile = File.Exists(targetPath);                                                  // Check if the selected item is a file
            if (!isDirectory && !isFile)                                                            // If the selected item does not exist, show an error message
            {
                MessageBox.Show("The selected item does not exist.");
                loadFilesAndDirectories();
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{currentlySelectedItemName}'?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
                // Proceed with deletion
                return;
            }
            try
            {
                if (isDirectory)
                {
                    Directory.Delete(targetPath, true);                                         // Delete the directory and its contents
                }
                else if (isFile)
                {
                    File.Delete(targetPath);                                                    // Delete the file
                }
                currentlySelectedItemName = "";                                                 // Clear the currently selected item name
                loadFilesAndDirectories();                                                      // Reload the files and directories to reflect the change
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message);
            }
        }
    }
}
