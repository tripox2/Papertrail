#!/bin/bash
export WEBSERVICE_PORT=50000
echo "WEBSERVICE_PORT set"
export SLACK_WEBHOOK=<WEBHOOK-URL>
echo "SLACK_WEBHOOK set"
export SLACK_CHANNEL=#general
echo "SLACK_CHANNEL set"
export SLACK_USERNAME=papertrail-bot
echo "SLACK_USERNAME set"
dotnet Papertrail.dll