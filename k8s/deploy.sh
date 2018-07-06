#!/bin/bash

key="$1"

case $key in
    -d|--delete)
    kubectl delete -f app.yaml,infra.yaml,traefik.yaml
    ;;
    *)
    kubectl apply -f traefik.yaml,infra.yaml,app.yaml
    ;;
 esac