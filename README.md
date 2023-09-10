# file-generator

```
dotnet pack -c Release
dotnet tool install --global --add-source ./nupkg FileGenerator --version 0.1.0
dotnet tool update --global --add-source ./nupkg FileGenerator --version 0.1.0

file-generator
file-generator pdf --name Test.pdf --from-html "<h1>Test</h1>"
```
