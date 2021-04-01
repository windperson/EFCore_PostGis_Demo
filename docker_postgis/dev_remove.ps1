$execStr = "docker-compose --env-file dev.env down $args";
Invoke-Expression "$execStr";