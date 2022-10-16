
## Application URLs - DEVELOPMENT:

- Identity API: http://localhost:5001

## Docker Command Examples
- Create a ".env" file at the same location with docker-compose.yml file:
  COMPOSE_PROJECT_NAME=tedu_identity
- run command: docker-compose -f docker-compose.yml up -d --remove-orphans --build

## Application URLs - PRODUCTION:

## Packages References

- https://github.com/serilog/serilog/wiki/Getting-Started
- https://github.com/IdentityServer/IdentityServer4.Quickstart.UI

## Install Environment

## References URLS


## Migrations commands (cd into Microservices.IDP project):
 - dotnet ef migrations add InitialPersistedGrantMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb
    + dotnet ef database update -c PersistedGrantDbContext
 - dotnet ef migrations add InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb
    + dotnet ef database update -c ConfigurationDbContext

 - dotnet ef migrations add "Init_Identity" -c MSIdentityContext -s Microservices.IDP.csproj -p ../Microservices.IDP.Infrastructure/Microservices.IDP.Infrastructure.csproj -o Migrations
    + dotnet ef database update -c MSIdentityContext -s Microservices.IDP.csproj -p ../Microservices.IDP.Infrastructure/Microservices.IDP.Infrastructure.csproj

## Useful commands:

