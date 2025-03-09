# FileNameUtils Documentation

The `FileNameUtils` class provides utility methods for manipulating file names. Currently, it offers a method to append the current date and time to a file name, which is useful for versioning or ensuring unique file names.

---

## Namespace
`NeoSystems.FileUtils`

---

## Class
`FileNameUtils`

---

## Method: AddDateTimeToFileName

### Signature
```csharp
public static string AddDateTimeToFileName(string fileName)
```

### Description
This method takes a file name as input and returns a new file name with the current date and time appended right before the file extension. The date and time are formatted as `yyyy-MM-dd-HH-mm-ss`.

### Parameters
- **fileName**: A `string` representing the file name. This can include a path, but must contain a file extension (e.g., `.txt`, `.cs`, `.pdf`).

### Returns
A `string` that combines the original file name (without its extension), the current date and time (formatted as `yyyy-MM-dd-HH-mm-ss`), and the original file extension.

### Implementation Details
- **Extracting Extension**: The method uses `Path.GetExtension(fileName)` to retrieve the file's extension.
- **Extracting File Name**: It then extracts the file name without the extension using `Path.GetFileNameWithoutExtension(fileName)`.
- **Appending DateTime**: The current date and time is retrieved with `DateTime.Now` and formatted accordingly.
- **String Interpolation**: The new file name is constructed using C# string interpolation.

### Example
If you pass `"example.txt"` as the input and the current date and time is `2025-03-09 14:30:15`, the method returns:
```
example-2025-03-09-14-30-15.txt
```

---

## Usage Example

Below is an example of how to use the `FileNameUtils` class in your application:

```csharp
using System;
using NeoSystems.FileUtils;

class Program
{
    static void Main(string[] args)
    {
        string originalFileName = "report.pdf";
        string newFileName = FileNameUtils.AddDateTimeToFileName(originalFileName);
        Console.WriteLine(newFileName);
    }
}
```

When this code is executed, it will output the file name with the current date and time appended. For example:
```
report-2025-03-09-14-30-15.pdf
```

---

## Conclusion
The `FileNameUtils` class is a simple yet effective utility to modify file names by adding a timestamp. This is particularly helpful for creating backups, maintaining version control, or avoiding file name collisions in applications.

Feel free to expand the class with additional file-related utilities as needed.
