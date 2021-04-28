# Run PostGIS in Docker Container

You need to install:

* [Docker Desktop](https://www.docker.com/products/docker-desktop) if is on Mac / Windows desktop environment.
* [PowerShell Core v7+](https://github.com/PowerShell/PowerShell)

This docker-compose project consist of a [PostGIS](https://postgis.net/) development DB instance and an admin web portal "[pgAdmin](https://www.pgadmin.org/)".

And those configurable port & account/password values are stored in **dev.env** file.

## Start/Stop service

### Start PostGIS & pgAdmin

Execute `dev_start.ps1` in PowerShell Core.

### Stop PostGIS & pgAdmin

Execute `dev_stop.ps1` in PowerShell Core.

## Remove service

### Remove container but keep data

Execute `dev_remove.ps1` in PowerShell Core.

### Remove container and data

Execute `dev_remove.ps1 --volumes` in PowerShell Core.
