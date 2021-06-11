# PostGIS Docker service

## Prerequisite

To use the development [PostGIS](https://postgis.net/) server & associated [pgAdmin web management](https://www.pgadmin.org/) service, you need:

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [PowerShell v7+](https://github.com/PowerShell/PowerShell)

## Start PostGIS and connect database

### Start PostGIS docker 

To start **PostGIS** & **pgAdmin** docker compose service:

1. Make sure [Docker Desktop daemon is currently running when on Windows or macOS](https://docs.docker.com/docker-for-windows/install/#start-docker-desktop).

2. Run `dev_start.ps1` script in normal PowerShell session:
    ```powershell
    ./docker_postgis/dev_start.ps1
    ```
    ![startup screen shot](./pics/run_PostGIS.png)

#### Inspect container status

Run `dev_ps.ps1` script to see current docker container status:  

```powershell
./docker_postgis/dev_ps.ps1
```

![container status screen shot](./pics/docker_ps.png)

### Connect PostGis using pgAdmin

1. After startup the docker compose service, use browser app to open web page: `http://localhost:8088`:  
    ![pgAdmin first screen shot](./pics/login_pgAdmin_portal_01.png)  
   Enter `dev@local.idv` as Account, `pass1234` as password to login, which are the environment variables written inside the `dev.env` file as `{PGADMIN_USERNAME}@{PGADMIN_DOMAIN}` & `{PGADMIN_PASS}`:  
   ![dev.env content](./pics/login_pgAdmin_portal_02.png)  
2. Expand the left server list, it will prompt for PostGIS server connection's password:  
    ![pgAdmin prompt for PostGIS server connection](./pics/connect_PostGIS_01.png)  
3. Enter the password that written inside the `dev.env` variable file as `{POSTGIS_PASS}`:  
    ![dev.env content](./pics/connect_PostGIS_02.png)  
   Check **Save Password** and then click OK:  
    ![password screen shot](./pics/connect_PostGIS_03.png)  
4. pgAdmin connects to PostGIS services successfully:  
    ![pgAdmin connect to PostGIS](./pics/connect_PostGIS_04.png)

### Import/Export PostGIS database file via pgAdmin

Sometimes you need to get backup files of PostgreSQL in order to do Database backup/restore, via pgAdmin's [storage manager](https://www.pgadmin.org/docs/pgadmin4/latest/storage_manager.html):  
![open pgAdmin storage manager](./pics/pgAdmin_storage_manager01.png)  
Which is binding to docker mounted folder inside the `docker_postgis\pgadmin_conf\storage` folder within the `{PGADMIN_USERNAME}_{PGADMIN_DOMAIN}` subfolder:  
![pgAdmin storage mapping](./pics/pgAdmin_storage_manager02.png)   

## Stop PostGIS & pgAdmin

To stop **PostGIS** & **pgAdmin** docker compose service, Run `dev_stop.ps1` script in normal PowerShell session:

```powershell
./docker_postgis/dev_stop.ps1
```

Or you can stop the services composition entry in [Docker dashboard](https://docs.docker.com/desktop/dashboard/):
![docker dashboard to stop services](./pics/stop_PostGIS.png)
Then you can safely exit docker desktop daemon if on Windows or macOS.

## Remove PostGIS & pgAdmin services

If you need to reset the PostGIS server, run the `dev_remove.ps1` with additional parameters in normal PowerShell session:

```powershell
./docker_postgis/dev_remove.ps1 --volumes
```
