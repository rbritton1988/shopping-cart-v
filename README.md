# Veygo Shopping Cart

Spin up a Postgres database
```
docker run -d -p 5432:5432 --name my-postgres -e POSTGRES_PASSWORD=mysecretpassword postgres
```

## Applying Migrations to Db and Populating with Initial Data

From Visual Studio -> PackageManager Console -> 
```
Update-Database
```