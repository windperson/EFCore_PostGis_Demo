﻿# Database update script

The `update.sql` is for offline database data & schema initialization, which is generated by invoking EF Core CLI tool when in  `GisWebApi` folder:
```powershell
dotnet ef migrations script -i -o ../sql_update/update.sql
```