$execStr = "docker-compose.exe --env-file dev.env up -d";
Invoke-Expression "$execStr";