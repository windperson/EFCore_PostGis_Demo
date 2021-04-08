$execStr = "docker-compose -f $PSScriptRoot/docker-compose.yml --env-file $PSScriptRoot/dev.env down $args";
Invoke-Expression "$execStr";