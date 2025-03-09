using System.Globalization;
using NeoSystems.FileUtils;

namespace NeoSystems.FileUtils.Test;

public class FolderUtilitiesTests
{
    private string _testFolderPath;
    private List<string> _testFiles;

    [SetUp]
    public void Setup()
    {
        _testFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testFolderPath);

        _testFiles = new List<string>
        {
            Path.Combine(_testFolderPath, "file1.txt"),
            Path.Combine(_testFolderPath, "file2.txt"),
            Path.Combine(_testFolderPath, "file3.txt")
        };

        // Create files with different last write times
        File.WriteAllText(_testFiles[0], "File 1 content");
        File.SetLastWriteTime(_testFiles[0], DateTime.Now.AddDays(-2));

        File.WriteAllText(_testFiles[1], "File 2 content");
        File.SetLastWriteTime(_testFiles[1], DateTime.Now.AddDays(-1));

        File.WriteAllText(_testFiles[2], "File 3 content");
        File.SetLastWriteTime(_testFiles[2], DateTime.Now);
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(_testFolderPath, true);
    }

    [Test]
    public void GetOldestFile_ReturnsOldestFile()
    {
        // Act
        string oldestFile = FolderUtilities.GetOldestFile(_testFolderPath);

        // Assert
        Assert.That(oldestFile, Is.EqualTo(_testFiles[0]));
    }

    [Test]
    public void GetNewestFile_ReturnsNewestFile()
    {
        // Act
        string newestFile = FolderUtilities.GetNewestFile(_testFolderPath);

        // Assert
        Assert.That(newestFile, Is.EqualTo(_testFiles[2]));
    }

    [Test]
    public void GetOldestFile_EmptyFolder_ReturnsEmptyString()
    {
        // Arrange
        string emptyFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(emptyFolderPath);

        // Act
        string oldestFile = FolderUtilities.GetOldestFile(emptyFolderPath);
        Directory.Delete(emptyFolderPath);

        // Assert
        Assert.That(oldestFile, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetNewestFile_EmptyFolder_ReturnsEmptyString()
    {
        // Arrange
        string emptyFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(emptyFolderPath);

        // Act
        string newestFile = FolderUtilities.GetNewestFile(emptyFolderPath);
        Directory.Delete(emptyFolderPath);

        // Assert
        Assert.That(newestFile, Is.EqualTo(string.Empty));
    }
    [Test]
    public void GetOldestFile_FolderDoesNotExist_ReturnsEmptyString()
    {
        // Arrange
        string nonExistentFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        // Act
        string oldestFile = FolderUtilities.GetOldestFile(nonExistentFolderPath);

        // Assert
        Assert.That(oldestFile, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetNewestFile_FolderDoesNotExist_ReturnsEmptyString()
    {
        // Arrange
        string nonExistentFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        // Act
        string newestFile = FolderUtilities.GetNewestFile(nonExistentFolderPath);

        // Assert
        Assert.That(newestFile, Is.EqualTo(string.Empty));
    }
}
