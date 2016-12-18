# Cake.Curl

Cake.Curl is an add-in for [Cake](http://cakebuild.net/) that allows to transer
files to a remote URL using [curl](https://curl.haxx.se).

## Examples

Uploading a local file to a remote HTTP server:

```csharp
#addin Cake.Curl

Task("Upload")
    .Does(() =>
{
    CurlUploadFile("some/file.txt", new Uri("http://host/path"));
});
```
Uploading a local file to a remote FTPS server using credentials:

```csharp
#addin Cake.Curl

Task("Upload")
    .Does(() =>
{
    CurlUploadFile(
        "some/file.txt",
        new Uri("ftps://host/path"),
        new CurlSettings
        {
            Username = "username",
            Password = "password"
        });
});
```