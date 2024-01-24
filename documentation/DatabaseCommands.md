- Set the Startup Project as **Alameen.Dashly.API**
- Goto Tools-> Nuget Package Manager -> Package Manager Console
- In the Package Manager Console Window Set the Default Project to **Alameen.Dashly.Repository**
- Enter below commands based on the configuration selected


## Ms Sql Server

### Add Migration 

`Add-Migration InitialDbMsSql -Context MsSqlDbContext -OutputDir Migrations\MsSql`

### Update Database

`update-database -Context MsSqlDbContext`

---

## SQLite

### Add Migration 

`Add-Migration InitialDbSQLite -Context SQLiteDbContext -OutputDir Migrations\SQLite`

### Update Database

`update-database -Context SQLiteDbContext`

---

## PostgreSql

### Add Migration 

`Add-Migration InitialDbPostgres -Context PostgresDbContext -OutputDir Migrations\PostgreSql`

### Update Database

`update-database -Context PostgresDbContext`

---