# About
RentalApp is an example project showcasing an ASP.NET WebApi Endpoint in a multilayered architecture with a connection to a PostgreSQL database and Client which uses a MAUI Blazor Hybrid project with Tailwindcss.

## Setup
### PostgreSQL
You can run PostgreSQL from a docker container, which is the easiest way in my opinion. You can find alternative images on [PostgreSQL Docker Hub](https://hub.docker.com/_/postgres).
```
docker pull postgres:16.1-alpine3.19
```

To run the container replace PWD with your password and the docker image name if you want to use a different one.
```
docker run -d -it --name postgres --restart=unless-stopped -p 5432:5432 -e POSTGRES_PASSWORD=PWD -d postgres:16.1-alpine3.19 -c shared_buffers=256MB -c max_connections=200 -c listen_addresses='*'
```

### Endpoint
#### Local environment
If you plan to run it from a local environment use:
```
dotnet run --urls "http://localhost:8080/"
```

Then set a User environment variable in your OS with the name of `NPGSQL_RENTAL` and the value of `Host=192.168.1.108; Port=5432; Database=rental; Username=postgres; Password=PWD`, where PWD is your PostgreSQL password.

#### Docker
You can build a Docker container **from the folder of RentalApp.Endpoint** using:
```
docker build .. -t rentalapp -f Dockerfile
```

To run the container replace PWD with your password for the PostgreSQL database:
```
docker run -d -it --name rentalapp --restart=unless-stopped -p 8080:8080 -e NPGSQL_RENTAL='Host=host.docker.internal; Port=5432; Database=rental; Username=postgres; Password=PWD' -d rentalapp
```
## Work in Progress