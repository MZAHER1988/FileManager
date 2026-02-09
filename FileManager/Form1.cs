using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FileManager
{
    public partial class Form1 : Form
    {
        private string filePath = @"C:\";
        private string currentlySelectedItemName = "";
        string previousFilePath = "";                                   // Variable to store the previous file path for error handling and navigation purposes
        private bool showingDrives = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filePathTextBox.Text = filePath;
            LoadFilesAndDirectories();
        }

        public void ShowDrives()
        {
            showingDrives = true;
            listView1.BeginUpdate();
            listView1.Items.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                try
                {
                    listView1.Items.Add(drive.Name, 22);
                }
                catch
                {
                    continue;
                }
            }
            listView1.EndUpdate();
            filePathTextBox.Text = "This PC";
            currentlySelectedItemName = "";
            FileNameLabel.Text = "";
            FileTypeLabel.Text = "";
        }

        public void LoadFilesAndDirectories()
        {
            bool isBeginUpdateCalled = false;                       // Flag to track if BeginUpdate has been called, to ensure EndUpdate is called appropriately
            try
            {
                if (!Directory.Exists(filePath))
                {
                    MessageBox.Show("Folder does not exist.");
                    return;
                }

                showingDrives = false;                                          // Reset the flag when loading a specific directory, as we are no longer showing drives
                DirectoryInfo fileList = new DirectoryInfo(filePath);           // Create a DirectoryInfo object for the specified path
                FileInfo[] files = fileList.GetFiles();                         // Get all files in the directory
                DirectoryInfo[] directories = fileList.GetDirectories();        // Get all subdirectories in the directory
                string fileExtension = "";                                      // Variable to hold the file extension for determining the appropriate icon
                listView1.BeginUpdate();
                isBeginUpdateCalled = true;                                     // Set the flag to indicate that BeginUpdate has been called
                listView1.Items.Clear();

                // Add directories to the ListView with folder icon
                for (int i = 0; i < directories.Length; i++)
                {
                    try
                    {
                        listView1.Items.Add(directories[i].Name, 20);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (IOException)
                    {
                        continue;
                    }
                }
                // Add files to the ListView with appropriate icons based on file type
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        fileExtension = (files[i].Extension ?? "").ToUpperInvariant();
                        int imageIndex = 21;                     // Default icon index for unknown file types

                        switch (fileExtension)
                        {
                            case ".TXT":
                                imageIndex = 0;
                                break;

                            case ".ZIP":
                                imageIndex = 1;
                                break;

                            case ".GIF":
                                imageIndex = 2;
                                break;

                            case ".DOC":
                            case ".DOCX":
                                imageIndex = 3;
                                break;

                            case ".PDF":
                                imageIndex = 4;
                                break;

                            case ".MP3":
                            case ".MP2":
                                imageIndex = 5;
                                break;

                            case ".MP4":
                            case ".AVI":
                            case ".MKV":
                                imageIndex = 6;
                                break;

                            case ".EXE":
                            case ".COM":
                                imageIndex = 7;
                                break;

                            case ".PNG":
                            case ".JPG":
                            case ".JPEG":
                            case ".BMP":
                                imageIndex = 8;
                                break;

                            case ".CS":
                                imageIndex = 9;
                                break;

                            case ".XLS":
                            case ".XLSX":
                                imageIndex = 10;
                                break;

                            case ".CSV":
                                imageIndex = 11;
                                break;

                            case ".PPT":
                            case ".PPTX":
                                imageIndex = 12;
                                break;

                            case ".HTML":
                                imageIndex = 13;
                                break;

                            case ".CSS":
                                imageIndex = 14;
                                break;

                            case ".JS":
                                imageIndex = 15;
                                break;

                            case ".JSON":
                                imageIndex = 16;
                                break;

                            case ".XML":
                                imageIndex = 17;
                                break;

                            case ".PY":
                                imageIndex = 18;
                                break;

                            case ".RAR":
                                imageIndex = 19;
                                break;
                        }
                        listView1.Items.Add(files[i].Name, imageIndex);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    catch (IOException)
                    {
                        continue;
                    }
                }
                filePathTextBox.Text = filePath;            // Update the text box to reflect the current path
                currentlySelectedItemName = "";             // Clear the currently selected item name when loading a new directory
                FileNameLabel.Text = "";                    // Clear the file name label when loading a new directory
                FileTypeLabel.Text = "";                    // Clear the file type label when loading a new directory
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to access this folder.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filePath = previousFilePath;                // Revert to the previous file path if access is denied
                filePathTextBox.Text = filePath;            // Update the text box to reflect the reverted path
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (isBeginUpdateCalled)
                {
                    listView1.EndUpdate();                  // Ensure that the ListView is updated after loading files and directories
                }
            }
        }


        public void LoadButtonAction()
        {
            RemoveBackSlash();
            string input = (filePathTextBox.Text ?? "").Trim(); // Safely trim the text box input, handling null values

            if (!Directory.Exists(input))
            {
                MessageBox.Show("Please enter or select a valid folder path.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            previousFilePath = filePath; // Store the current file path before attempting to load the new path, used for error handling and navigation purposes
            filePath = input;
            LoadFilesAndDirectories();
        }

        public void BackButtonAction()
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    MessageBox.Show("Current path is invalid. Cannot navigate back.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Alternative approach using Directory.GetParent
                DirectoryInfo parentDir = Directory.GetParent(filePath);                    // Get the parent directory of the current path
                if (parentDir != null)                                                      // Check if the parent directory exists
                {
                    previousFilePath = filePath;                                            // Store the current file path before navigating up, used for error handling and navigation purposes
                    filePath = parentDir.FullName;                                          // Update the filePath variable to the parent directory's full path
                    filePathTextBox.Text = filePath;                                        // Update the text box to reflect the new path
                    LoadFilesAndDirectories();                                              // Load the files and directories in the new path
                }
                else
                {        
                    ShowDrives();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RemoveBackSlash()
        {
            //string path = filePathTextBox.Text.Trim();
            string path = (filePathTextBox.Text ?? "").Trim(); // Safely trim the text box input, handling null values

            if (string.IsNullOrEmpty(path))
            {
                // If the path is empty after trimming, do nothing and return
                return;
            }

            string root = Path.GetPathRoot(path);                       // Get the root of the path (e.g., "C:\")
            if (!string.IsNullOrEmpty(root) && string.Equals(path, root, StringComparison.OrdinalIgnoreCase))
            {
                filePathTextBox.Text = root;
                return;
            }
            path = path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar); // Remove trailing slashes
            filePathTextBox.Text = path;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            LoadButtonAction();
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (showingDrives)
            {
                currentlySelectedItemName = e.Item.Text; // Get the name of the currently selected drive in the list view
                FileNameLabel.Text = e.Item.Text;
                FileTypeLabel.Text = "Drive";
                return;
            }
            if (e.IsSelected == false)
            {
                // If the item is not selected, do nothing and return
                return;
            }

            currentlySelectedItemName = e.Item.Text;                                         // Get the name of the currently selected item in the list view
            string fullPath = Path.Combine(filePath, currentlySelectedItemName);            // Construct the full path of the selected item 

            if (Directory.Exists(fullPath))
            {
                FileNameLabel.Text = e.Item.Text;
                FileTypeLabel.Text = "Folder";
            }
            else if (File.Exists(fullPath))
            {
                var fi = new FileInfo(fullPath);
                FileNameLabel.Text = fi.Name;
                FileTypeLabel.Text = fi.Extension;
            }
            else
            {
                FileNameLabel.Text = "";
                FileTypeLabel.Text = "";
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(currentlySelectedItemName)) return;

            if (showingDrives)
            {
                string driveRoot = currentlySelectedItemName; // Assuming the drive name is in the format "C:\"
                
                
                    if (Directory.Exists(driveRoot))
                    {
                        showingDrives = false;
                        previousFilePath = filePath; // Store the current file path before navigating into the new directory, used for error handling and navigation purposes
                        filePath = driveRoot;
                        filePathTextBox.Text = filePath;
                        LoadFilesAndDirectories();
                    }
                    else
                    {
                        MessageBox.Show("The selected drive is not accessible.");
                    }             
                return;
            }

            string fullPath = Path.Combine(filePath, currentlySelectedItemName);

            if (Directory.Exists(fullPath))
            {
                previousFilePath = filePath; // Store the current file path before navigating into the new directory, used for error handling and navigation purposes

                filePath = fullPath;
                filePathTextBox.Text = filePath;
                LoadFilesAndDirectories();
            }
            else if (File.Exists(fullPath))
            {
                try
                {
                    // Open the file with the default associated application, UseShellExecute is required for .NET Core and .NET 5+,
                    // for .NET Framework it can be omitted, but it's good practice to include it for compatibility
                    Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open file: " + ex.Message);
                }
            }
            return;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonAction();
        }

        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            if (showingDrives)
            {
                MessageBox.Show("Cannot create folders in drives. Please select a folder to create a new folder.");
                return;
            }
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
                    LoadFilesAndDirectories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in new folder!" + ex.Message);
                }
                break;
            }

        }

        private void NewFileButton_Click(object sender, EventArgs e)
        {
            if (showingDrives)
            {
                MessageBox.Show("Cannot create files in drives. Please select a folder to create a new file.");
                return;
            }
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
                    LoadFilesAndDirectories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating new file: " + ex.Message);
                }
                break;
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (showingDrives)
            {
                MessageBox.Show("Cannot rename drives. Please select a file or folder to rename.");
                return;
            }
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
                LoadFilesAndDirectories();
                return;
            }

            while (true)
            {
                // Prompt the user to enter the new name for the selected item, with the current name as default value, can be modified to take user input,
                // using Microsoft.VisualBasic, requires adding reference to Microsoft.VisualBasic
                string newName = Interaction.InputBox("Enter the new name for the selected item:", "Rename Item", currentlySelectedItemName);

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
                    LoadFilesAndDirectories();                                                  // Reload the files and directories to reflect the change
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error renaming item: " + ex.Message);
                }
                break;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (showingDrives)
            {
                MessageBox.Show("Cannot delete drives. Please select a file or folder to delete.");
                return;
            }

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
                LoadFilesAndDirectories();
                return;
            }
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{currentlySelectedItemName}'?",
                                                   "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
            {
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
                LoadFilesAndDirectories();                                                      // Reload the files and directories to reflect the change
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message);
            }
        }
    }
}
