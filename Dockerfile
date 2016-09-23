FROM microsoft/dotnet:latest
ENV name WebserviceConsumer
COPY src/$name /root/$name
RUN cd /root/$name && dotnet restore && dotnet build && dotnet publish
RUN cp -rf /root/$name/bin/Debug/netcoreapp1.0/publish/* /root/
EXPOSE 80/tcp
ENTRYPOINT cd /root && dotnet ${name}.dll
