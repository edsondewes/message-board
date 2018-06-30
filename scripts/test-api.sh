#!/bin/bash
set -ev

TESTURL=${URL_MESSAGING_API:-"localhost:9090/api/messages"}
echo $TESTURL;

while [[ "$(curl -s -o /dev/null -w ''%{http_code}'' $TESTURL)" != "200" ]]; do
    printf '.'
	sleep 5
done

yarn --cwd "$(dirname "$0")/../test/integration-api/" test