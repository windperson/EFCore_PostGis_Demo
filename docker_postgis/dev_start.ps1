$execStr = "docker-compose -f $PSScriptRoot/docker-compose.yml --env-file $PSScriptRoot/dev.env up -d $args";
Invoke-Expression "$execStr";