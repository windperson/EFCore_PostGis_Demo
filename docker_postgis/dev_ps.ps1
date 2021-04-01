$execStr = "docker-compose --env-file dev.env ps $args";
Invoke-Expression "$execStr";