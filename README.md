# ALevelSample

For Database we use MsSql server in a docker container

**docker command for setup Ms Sql server with sample DB inside:** `docker run -p 1434:1433 -e ACCEPT_EULA=Y -e SA_PASSWORD=1My_password -d chriseaton/adventureworks:latest`

**install ef tool (if it is not installed on your PC)** `dotnet tool install --global dotnet-ef`

**create migration command:** `dotnet ef migrations add InitialCreate -p ALevelSample`

For new migration just change name from InitialCreate to yours

**update migration command:** `dotnet ef database update -p ALevelSample`