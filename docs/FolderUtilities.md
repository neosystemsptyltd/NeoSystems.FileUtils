# FolderUtilities Documentation

The `FolderUtilities` class provides utility methods to retrieve files based on their modification dates from a specified folder. It includes methods to find both the oldest and the newest file in a given directory.

---

## Methods Overview

- **GetOldestFile(string inputFolder)**
  - Returns the full path of the oldest file in the specified folder.
  - If the folder does not exist or is empty, it returns an empty string.
  - Throws an exception if an error occurs during the process.

- **GetOldestFile(string inputFolder, string searchPattern)**
  - Returns the full path of the oldest file in the specified folder matching the search pattern.
  - If the folder does not exist or is empty, it returns an empty string.
  - Throws an exception if an error occurs during the process.

- **GetNewestFile(string inputFolder)**
  - Returns the full path of the newest file in the specified folder.
  - If the folder does not exist or is empty, it returns an empty string.
  - Throws an exception if an error occurs during the process.

- **GetNewestFile(string inputFolder, string searchPattern)**
  - Returns the full path of the newest file in the specified folder matching the search pattern.
  - If the folder does not exist or is empty, it returns an empty string.
  - Throws an exception if an error occurs during the process.

---

## Method Details

### GetOldestFile

```csharp
public static string GetOldestFile(string inputFolder)
```

#### Description
Finds and returns the full path of the oldest file in the specified folder. The method checks whether the folder exists and then orders the files by their last write time in ascending order. If the folder is empty or does not exist, it returns an empty string.

#### Parameters
- **inputFolder**: A `string` representing the path of the folder to search for files.

#### Returns
- A `string` that is the full path of the oldest file in the folder.
- Returns an empty string if the folder does not exist or contains no files.

#### Exception Handling
- If an exception occurs during the process, the method catches it and rethrows a new exception with a message indicating the error and the folder path.

---

### GetOldestFile (with a search pattern)

```csharp
public static string GetOldestFile(string inputFolder, string searchPattern = "*.*")
```

#### Description
Finds and returns the full path of the oldest file in the specified folder, based on the optional search pattern for file names. The method first checks if the folder exists. It then orders the files by their last write time in ascending order to find the oldest file. If the folder does not exist or is empty, the method returns an empty string.

#### Parameters
- **inputFolder**: A `string` representing the path of the folder to search for files.
- **searchPattern**: An optional `string` that specifies the search pattern for filtering files within the folder. The default is `"*.*"` which includes all files.

#### Returns
- A `string` that is the full path of the oldest file found in the folder.
- Returns an empty string if the folder does not exist or contains no files matching the search pattern.

#### Exception Handling
- If an exception occurs during the process, the method catches it and throws a new exception with a message indicating the error and the folder path where the error occurred.
---

### GetNewestFile

```csharp
public static string GetNewestFile(string inputFolder)
```

#### Description
Finds and returns the full path of the newest file in the specified folder. The method checks whether the folder exists and then orders the files by their last write time in descending order. If the folder is empty or does not exist, it returns an empty string.

#### Parameters
- **inputFolder**: A `string` representing the path of the folder to search for files.

#### Returns
- A `string` that is the full path of the newest file in the folder.
- Returns an empty string if the folder does not exist or contains no files.

#### Exception Handling
- Similar to `GetOldestFile`, if an exception occurs, it is caught and a new exception is thrown with an error message that includes the folder path.

---

### GetNewestFile (with a search pattern)

```csharp
public static string GetNewestFile(string inputFolder, string searchPattern = "*.*")
```

#### Description
Finds and returns the full path of the newest file in the specified folder, utilizing an optional search pattern for file names. The method initially checks if the folder exists. It then orders the files by their last write time in descending order to locate the newest file. If the folder does not exist or is empty, the method returns an empty string.

#### Parameters
- **inputFolder**: A `string` representing the path of the folder to search for files.
- **searchPattern**: An optional `string` that specifies the search pattern used to filter files within the folder. The default is `"*.*"`, which matches all files.

#### Returns
- A `string` that represents the full path of the newest file found in the folder.
- Returns an empty string if the folder does not exist or contains no files matching the search pattern.

#### Exception Handling
- If an error occurs during the process, the method catches it and throws a new exception with a message indicating the error and specifying the folder path where the error occurred.

---

## Usage Example

Below is an example of how to use the `FolderUtilities` class in your application:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string folderPath = @"C:\ExampleFolder";

        // Get the oldest file in the folder
        string oldestFile = FolderUtilities.GetOldestFile(folderPath);
        if (!string.IsNullOrEmpty(oldestFile))
        {
            Console.WriteLine($"Oldest file: {oldestFile}");
        }
        else
        {
            Console.WriteLine("No files found or folder does not exist.");
        }

        // Get the newest file in the folder
        string newestFile = FolderUtilities.GetNewestFile(folderPath);
        if (!string.IsNullOrEmpty(newestFile))
        {
            Console.WriteLine($"Newest file: {newestFile}");
        }
        else
        {
            Console.WriteLine("No files found or folder does not exist.");
        }
    }
}
```

---

## Conclusion

The `FolderUtilities` class is a practical utility for managing files based on their modification dates. It simplifies the process of identifying the oldest or newest file within a directory, making it useful for tasks such as file maintenance, backup operations, or archival processes.