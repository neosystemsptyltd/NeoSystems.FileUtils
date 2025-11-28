# Project Review: Problems and Potential Features

## Refactoring and Improvements

- **Reduce Code Duplication in `FolderUtilities`**:
    - The methods `GetOldestFile` and `GetNewestFile` (and their overloads) share significant logic. Refactor to use a common private method or helper to reduce redundancy.
- **Optimize File Enumeration**:
    - `Directory.GetFiles()` loads all file names into memory at once. For large directories, consider using `Directory.EnumerateFiles()` which is lazy-evaluated (although sorting by date still requires iterating all items).
- **Correct Path Handling in `FileNameUtils`**:
    - `AddDateTimeToFileName` uses `Path.GetFileNameWithoutExtension` which strips the directory path. This causes the function to return only the filename, effectively losing the original path if one was provided.
- **Namespace Consistency**:
    - `FolderUtilities` is currently in the global namespace. It should be moved to the `NeoSystems.FileUtils` namespace to match the rest of the library.
- **Exception Handling**:
    - `FolderUtilities` catches all exceptions and rethrows a generic `Exception`. This hides the original exception type (e.g., `UnauthorizedAccessException`, `PathTooLongException`). It is better to let specific exceptions bubble up or wrap them in a custom domain exception while preserving the stack trace.

## Feature Requests

- **Custom Date Formats in `FileNameUtils`**:
    - Add an overload to `AddDateTimeToFileName` that accepts a custom date format string, instead of hardcoding `yyyy-MM-dd-HH-mm-ss`.
- **Deterministic Time for Testing**:
    - Add an overload to `AddDateTimeToFileName` that accepts a `DateTime` object. This allows callers to specify the time and makes unit testing deterministic without relying on `DateTime.Now`.
- **Positioning of Timestamp**:
    - Allow configuring the position of the timestamp (prefix, suffix, or before extension) via an enum or parameter.
- **Asynchronous File Operations**:
    - Add async versions of `FolderUtilities` methods (e.g., `GetOldestFileAsync`) to avoid blocking threads on I/O operations, where applicable and supported by the target framework.
- **Recursive Search**:
    - Add support for `SearchOption` in `FolderUtilities` to allow searching in subdirectories.
- **Enhanced Search Criteria**:
    - Allow finding files based on other criteria, such as creation time or file size, potentially via a generic predicate or strategy pattern.

## Documentation and Tooling

- **Update README**:
    - The `README.md` currently only documents `FileNameUtils`. Add documentation for `FolderUtilities`.
- **CI/CD Pipeline**:
    - Set up a Continuous Integration (CI) pipeline (e.g., GitHub Actions) to automatically build the project and run tests on every commit/PR.
- **XML Documentation**:
    - Ensure all public methods have complete XML documentation comments to support IntelliSense and API documentation generation.
