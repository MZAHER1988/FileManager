# File Manager

A desktop file management application developed with C# and Windows Forms.

The purpose of this project was to gain hands-on experience with file system operations, user interaction, and desktop application development in .NET. The application provides common file management functionality through a simple graphical user interface.
## Features

- **Navigation** – Browse through drives, folders, and files using double-click or the address bar.
- **Files and Folders** – Create, rename, copy, cut, paste, and delete files/folders.
- **Visualization** – File and folder icons based on file type (e.g., `.txt`, `.pdf`, `.mp3`, `.exe`).
- **Open Files** – Double-click a file to open it with its default associated program.
- **Information** – Display the name and type of the selected item.

## Requirements

- Windows operating system
- .NET Framework (with support for `Microsoft.VisualBasic`)
- Visual Studio or similar IDE (for compilation)

## Installation

1. Clone or download the project.
2. Open the solution in Visual Studio.
3. Add a reference to `Microsoft.VisualBasic` (used for InputBox dialogs).
4. Build and run the project.

## Usage

### General Navigation

- **Address Bar** – Type a path and click `Go` or press Enter.
- **Back Button** – Go to the previous folder.
- **Double-click** – Open a folder or file.

### File/Folder Management

| Button        | Function                                          |
|---------------|---------------------------------------------------|
| `New Folder`  | Create a new folder (you will be prompted for a name). |
| `New File`    | Create a new empty file (provide name with extension). |
| `Rename`      | Rename the selected file or folder.              |
| `Delete`      | Delete the selected file or folder (confirmation required). |
| `Copy`        | Copy the selected file or folder to clipboard.   |
| `Cut`         | Cut the selected file or folder to clipboard.    |
| `Paste`       | Paste from clipboard into the current folder.    |

### Drives and Special Views

- When at the root level (`This PC`), all available drives are displayed.
- Certain actions (such as creating/deleting drives) are not allowed to prevent accidental changes.

## Error Handling

- The application handles insufficient permissions (`UnauthorizedAccessException`) and invalid paths.
- If a folder is inaccessible, it reverts to the previous path.
- Conflicts during copy/paste are handled by generating unique names (e.g., `file (1).txt`).

## Limitations

- Created files are empty – you must edit them externally.
- No built-in search functionality.
- Local drives only – no network drive support.
- Requires `Microsoft.VisualBasic` for InputBox dialogs.

## Future Improvements (Suggestions)

- Add search functionality.
- Display file size, date, and attributes.
- Ability to create files with pre-filled content.
- Support for network drives.
- Keyboard shortcuts (e.g., Ctrl+C, Ctrl+V, Ctrl+X).

## Technical Information

- **Language:** C#
- **Interface:** Windows Forms
- **Dependencies:** `Microsoft.VisualBasic`
- **Icons:** Built-in ImageList (indices 0–22 for different file types)

---

## Author

# *Zaher Hariri*

**Note:** I created this program as part of my journey to learn C# and Windows Forms development. This project helped me understand file system operations, event handling, and user interface design in .NET.

---
