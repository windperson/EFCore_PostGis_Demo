# DB Backup folder

This folder is for easier take database backup files from/to the pgAdmin web portal,  
otherwise, you need to use the [`docker cp`](https://docs.docker.com/engine/reference/commandline/cp/) command to tackle the backup file.

To access backup file, copy or put the backup file into to `storage/[account]/` subfolder, than that file will be accessible on pgAdmin's [Storage manager](https://www.pgadmin.org/docs/pgadmin4/development/storage_manager.html).

**Note:**  
- When not using git to distribute this folder, be sure to remove every files except this readme.
- When running on Linux or macOS environment, make sure to set [correct directory permission for pgAdmin4](https://www.pgadmin.org/docs/pgadmin4/development/container_deployment.html#mapped-files-and-directories) to save content to this folder.
