$execStr = "docker-compose -f $PSScriptRoot/docker-compose.yml --env-file $PSScriptRoot/dev.env ps $args";
Invoke-Expression "$execStr";