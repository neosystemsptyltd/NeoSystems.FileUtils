using System.Globalization;
using NeoSystems.FileUtils;

namespace NeoSystems.FileUtils.Test;

public class FileUtilsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddDateTimeToFileName_ShouldAppendCurrentDateTime()
    {
        // Arrange
        string originalFileName = "report.pdf";

        // Act
        string result = NeoSystems.FileUtils.FileNameUtils.AddDateTimeToFileName(originalFileName); // Replace with your actual namespace and class name

        // Extract the parts from the returned value
        string extension = Path.GetExtension(result);
        string name = Path.GetFileNameWithoutExtension(result);

        // Assert
        Assert.That(extension, Is.EqualTo(".pdf"), "The extension of the generated filename is incorrect. Expected: .pdf, Actual: " +  extension);

        // Obtain only the date part from the generated filename
        string[] parts = name.Split('-');

        // Ensure that the parts are as expected
        Assert.That(parts[0], Is.EqualTo("report"));

        // Prepare a datetime format pattern and validate that the date follows this pattern
        DateTime extractedDateTime;
        bool isValidDateTimeFormat = DateTime.TryParseExact(
            string.Join("-", parts, 1, parts.Length - 1),
            "yyyy-MM-dd-HH-mm-ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out extractedDateTime);

        Assert.True(isValidDateTimeFormat, "The datetime format appended to the file name is incorrect.");
    }
}