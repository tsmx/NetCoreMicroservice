# NetCoreMicroservice

A very basic .Net Core 3.1 microservice example.

## Usage

Run the service and send requests to http://localhost:5000/testservice using the following http methods:

- GET: returns a hello message
- POST: awaits a valid JSON and echoes it back in the response (serialize & de-serialize test), HTTP-500 if no valid JSON was sent

Creating & running with Docker:
```
docker build -t netcoreservice .
docker run -d -p 5000:80 netcoreservice
```

## Prerequisites
- .Net Core 3.1
- VS Code plus plugin "C#" [optional]
- Docker CE [optional]

## Endpoints

- `http:localhost:5000/testservice GET` returns a simple string
- `http:localhost:5000/testservice POST` awaits a valid JSON request body, serializes & de-serializes it before echoing it back
- `http:localhost:5000/testservice/person POST application/json` converts the request body JSON to a person object
- `http:localhost:5000/testservice/person POST application/x-www-form-urlencoded` converts the request url-encoded form parameters to a person object

To test in Postman or with curl use the following definition of a `Person`object:

```
{
    "FirstName": "Karl",
    "LastName: "Heinz",
    "Age": 45
}
```

## Useful commands

```
dotnet new webapi -o [project-name] --no-https
```
initialize a new microservice project without https support for testing purposes

```
dotnet publish -c Release
```
create a "release build" of the service under bin/Release/, e.g. for building a docker image
