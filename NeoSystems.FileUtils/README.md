# FileNameUtils

`FileNameUtils` is a utility class designed to manipulate file names by appending the current date and time to them. This can be particularly useful for versioning files or avoiding naming conflicts.

## Features

- **Add DateTime to File Name**: Automatically appends the current date and time to a given file name, using the format `yyyy-MM-dd-HH-mm-ss`.

## Usage

### Namespace

Ensure that you include the following namespace in your project:

```csharp
using NeoSystems.FileUtils;
```

### Method Overview

#### `AddDateTimeToFileName`

This method takes a file name as input and returns a new file name with the current date and time appended before the file extension.

**Method Signature**:
```csharp
public static string AddDateTimeToFileName(string fileName)
```

**Parameters**:
- `fileName`: A `string` representing the original file name including its extension.

**Returns**:
- A `string` representing the new file name with the date and time appended.

### Example

Here is an example of how to use the `AddDateTimeToFileName` method:

```csharp
using System;
using NeoSystems.FileUtils;

class Program
{
    static void Main()
    {
        string originalFileName = "report.pdf";
        string newFileName = FileNameUtils.AddDateTimeToFileName(originalFileName);
        Console.WriteLine("New file name: " + newFileName);
    }
}
```

In this example, if the current date and time is October 5th, 2023, at 14:30:15, the output would be similar to:

```
New file name: report-2023-10-05-14-30-15.pdf
```

## Requirements

- .NET Framework or .NET Core that supports C# language features used within the code.
   
## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

By following the above guidelines, you should be able to seamlessly integrate and utilize the `FileNameUtils` class into your projects. If you have any issues or require further assistance, please feel free to contact the author or contribute to the project.