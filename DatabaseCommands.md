
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