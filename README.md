# Veygo Shopping Cart

Spin up a Postgres database

```
docker run -d -p 5432:5432 --name my-postgres -e POSTGRES_PASSWORD=mysecretpassword postgres
```

## Applying Migrations to Db and Populating with Initial Data

From Visual Studio -> Package Manager Console

```
Update-Database
```

or from command line (within VeygoShaoppingCart.API/)

```
dotnet ef database update
```

## Runing the project

From Visual Studio: target VeygoShaoppingCart.API project and run that.

From the command line (within src/)

```
dotnet run --project VeygoShaoppingCart.API/
```
Follow the url presented in command line.

- If something goes wrong, You may have to manually install the frontend dependencies by running `yarn` in `VeygoShaoppingCart.API/ClientApp/` directory.

### Discount Codes
- VC08A9VSK7
- VC08AURX7G
- FIRST15UK