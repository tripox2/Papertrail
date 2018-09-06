# Papertrail

<h3>Prerequirement</h3>
Install .Net core SDK: https://www.microsoft.com/net/download/linux-package-manager/ubuntu16-04/sdk-current</br>
</br>
Change telemtry environmental variable to disable data beeing sent to Microsoft.</br>
<code>
export DOTNET_CLI_TELEMETRY_OPTOUT=1
</code>
</br>
</br>
<b>Require Slack incoming webhook</b></br>
Enable Slack integration webhook to get a webhook url.

<h3>Build solution, configre and run</h3>

<b>Build solution</b></br>
Find and change directory to the path with <i>.sln</i> in it, e.g. <i>~/home/Papertrail</i>. In order to build the solution, run </br>
<code>
dotnet build
</code>
</br>
</br>
<b>Configure</b></br>
Requires the built in enviormental variables to be set. The varibles needed to be configured are</br>
</br>
<code>export WEBSERVICE_PORT=<WEBSERVICE_PORT></code> // The port the web service listening on</br>
<code>export SLACK_WEBHOOK=<WEBHOOK_URL></code> // Slack incoming webhook url.</br>
<code>export SLACK_CHANNEL=<#CHANNEL></code> // Slack channel to be published to</br>
<code>export SLACK_USERNAME=<USERNAME></code> // Slack username to be published with</br>
</br>
<b>Run compiled solution</b></br>
Change directry to assmebly of the build solution. Found in <i>../Papertrail/bin/Debug/netcoreapp2.1</i>
</br>
If configration is done run</br>
<code>
dotnet Papertrail.dll
</code>
