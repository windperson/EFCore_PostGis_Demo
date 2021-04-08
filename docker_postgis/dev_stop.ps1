$execStr = "docker-compose -f $PSScriptRoot/docker-compose.yml --env-file $PSScriptRoot/dev.env stop";
Invoke-Expression "$execStr";