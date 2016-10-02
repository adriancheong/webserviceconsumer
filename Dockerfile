FROM microsoft/iis
RUN dism /online /enable-feature /all /featurename:iis-webserver /NoRestart
RUN mkdir c:\install
ADD WebDeploy_2_10_amd64_en-US.msi /install/WebDeploy_2_10_amd64_en-US.msi
WORKDIR /install
RUN powershell start-Process msiexec.exe -ArgumentList '/i c:\install\WebDeploy_2_10_amd64_en-US.msi /qn' -Wait
