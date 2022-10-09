# 1. dotnet ef migrations add InitialPersistedGrantMigration -c PersistedGrantDbContext -o Migrations/IdentityServer/PersistedGrantDb

# 2. dotnet ef migrations add InitialConfigurationMigration -c ConfigurationDbContext -o Migrations/IdentityServer/ConfigurationDb

# 3. dotnet ef migrations add Init_Identity -c MSIdentityContext -o Migrations/IdentityServer/Identity

# 4. update database
    - dotnet ef database update -c PersistedGrantDbContext
    - dotnet ef database update -c ConfigurationDbContext
    - dotnet ef database update -c MSIdentityContext