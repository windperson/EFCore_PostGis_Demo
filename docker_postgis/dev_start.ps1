$execStr = "docker-compose --env-file dev.env up -d $args";
Invoke-Expression "$execStr";