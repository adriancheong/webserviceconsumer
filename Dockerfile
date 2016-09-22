FROM microsoft/dotnet:latest
ENV name WebserviceConsumer
COPY src/$name /root/$name
RUN cd /root/$name && dotnet restore && dotnet build && dotnet publish
COPY src/$name/bin/Debug/netcoreapp1.0/publish/ /root/
EXPOSE 5000/tcp
ENTRYPOINT dotnet /root/${name}.dll
