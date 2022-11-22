
# GitHub actions

- Choose a programming language/platform
- Provide a sample project
  - With _at least_ 1 automated test
- Configure GitHub actions
  - So that it verifies _at least_ the test mentioned above
- For bonus points pack more features into your _GitHub actions_

## Notes

### Setup .NET on server
- In order for the testing server to function accordingly, it requires .NET installed on it. The package is available on the GitHub marketplace.
- The action completed without errors.

### Restore NuGet dependencies
- Restores dependencies specified in the project file using the command dotnet restore.
- The executed command completed without errors.

### Build project
- Builds the project and all of its dependecies with the Release configuration and skips the restore. Restore executes before.
- The executed command completed without errors.

### Execute xUnit Tests
- Tests written xUnit Tests.
- The command functioned in order.

### Use Linter against project
- Formats and check the code for stylistical errors. The package used is super-linter from the GitHub marketplace.
- The execution completed without errors.
