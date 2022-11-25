# ALevelSample

For Database we use Postgres SQl in a docker container

**docker command for setup Postgres:** `docker-compose up`

**install ef tool (if it is not installed on your PC)** `dotnet tool install --global dotnet-ef`

**create migration command:** `dotnet ef migrations add InitialCreate -p ALevelSample`

For new migration just change name from InitialCreate to yours

**update migration command:** `dotnet ef database update -p ALevelSample`