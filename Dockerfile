FROM microsoft/dotnet:latest
ENV name WebserviceConsumer
COPY src/$name /root/$name
WORKDIR /root/$name
RUN dotnet restore && dotnet build && dotnet publish
RUN cp -rf /bin/Debug/netcoreapp1.0/publish/* /root/
EXPOSE 80/tcp
WORKDIR /root
ENTRYPOINT dotnet ${name}.dll
