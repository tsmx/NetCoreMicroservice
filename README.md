# NetCoreMicroservice

A very basic .Net Core 3.1 microservice example.

## Prerequisites
- .Net Core 3.1
- VS Code plus plugin "C#"
- Docker CE

## Useful commands:

```
dotnet new webapi -o [project-name] --no-https
```
initialize a new microservice project without https support for testing purposes

```
dotnet publish -c Release
```
create a "release build" of the service under bin/Release/, e.g. for building a docker image