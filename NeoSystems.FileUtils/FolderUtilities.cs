using System;
using System.IO;
using System.Linq;

public class FolderUtilities
{
    /// <summary>
    /// Find the oldest file in the input folder. If the folder does not exist or is empty, return an empty string.
    /// </summary>
    /// <param name="inputFolder">Folder to search for files.</param>
    /// <returns>string</returns>
    /// <exception cref="Exception"></exception>
    public static string GetOldestFile(string inputFolder)
    {
        try
        {
            // get the oldest file in the input folder
            if (!Directory.Exists(inputFolder))
            {
                return string.Empty;
            }

            var directory = new DirectoryInfo(inputFolder);
            var oldestFile = directory.GetFiles()
                .OrderBy(f => f.LastWriteTime)
                .FirstOrDefault();

            if (oldestFile == null)
            {
                return string.Empty;
            }

            return oldestFile.FullName;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting oldest file in folder {inputFolder}", ex);
        }
    }

    /// <summary>
    /// Find the oldest file in the input folder. If the folder does not exist or is empty, return an empty string.
    /// </summary>
    /// <param name="inputFolder">Folder to search for files.</param>
    /// <param name="searchPattern">Search pattern for files.</param>
    /// <returns>string</returns>
    /// <exception cref="Exception"></exception>
    public static string GetOldestFile(string inputFolder, string searchPattern = "*.*")
    {
        try
        {
            // get the oldest file in the input folder
            if (!Directory.Exists(inputFolder))
            {
                return string.Empty;
            }

            var directory = new DirectoryInfo(inputFolder);
            var oldestFile = directory.GetFiles(searchPattern)
                .OrderBy(f => f.LastWriteTime)
                .FirstOrDefault();

            if (oldestFile == null)
            {
                return string.Empty;
            }

            return oldestFile.FullName;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting oldest file in folder {inputFolder}", ex);
        }
    }

    /// <summary>
    /// Find the newest file in the input folder. If the folder does not exist or is empty, return an empty string.
    /// </summary>
    /// <param name="inputFolder">Folder to search for files.</param>
    /// <returns>string</returns>
    public static string GetNewestFile(string inputFolder)
    {
        try
        {
            // get the newest file in the input folder
            if (!Directory.Exists(inputFolder))
            {
                return string.Empty;
            }

            var directory = new DirectoryInfo(inputFolder);
            var newestFile = directory.GetFiles()
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();

            if (newestFile == null)
            {
                return string.Empty;
            }

            return newestFile.FullName;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting newest file in folder {inputFolder}", ex);
        }
    }

    /// <summary>
    /// Find the newest file in the input folder. If the folder does not exist or is empty, return an empty string.
    /// </summary>
    /// <param name="inputFolder">Folder to search for files.</param>
    /// <param name="searchPattern">Search pattern for files.</param>
    /// <returns>string</returns>
    public static string GetNewestFile(string inputFolder, string searchPattern = "*.*")
    {
        try
        {
            // get the newest file in the input folder
            if (!Directory.Exists(inputFolder))
            {
                return string.Empty;
            }

            var directory = new DirectoryInfo(inputFolder);
            var newestFile = directory.GetFiles(searchPattern)
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();

            if (newestFile == null)
            {
                return string.Empty;
            }

            return newestFile.FullName;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting newest file in folder {inputFolder}", ex);
        }
    }
}