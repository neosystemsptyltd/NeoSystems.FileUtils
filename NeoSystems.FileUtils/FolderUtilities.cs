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
        return GetOldestFile(inputFolder, "*");
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
            FileInfo oldestFile = null;

            foreach (var file in directory.EnumerateFiles(searchPattern))
            {
                if (oldestFile == null || file.LastWriteTime < oldestFile.LastWriteTime)
                {
                    oldestFile = file;
                }
            }

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
        return GetNewestFile(inputFolder, "*");
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
            FileInfo newestFile = null;

            foreach (var file in directory.EnumerateFiles(searchPattern))
            {
                if (newestFile == null || file.LastWriteTime > newestFile.LastWriteTime)
                {
                    newestFile = file;
                }
            }

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
