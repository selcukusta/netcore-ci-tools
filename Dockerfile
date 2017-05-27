FROM microsoft/dotnet:latest
COPY src /app
WORKDIR /app
RUN ["dotnet", "restore"]
WORKDIR /app/NetCoreTestCI.Web
RUN ["dotnet", "build", "--configuration", "Release"]
EXPOSE 1905/tcp
ENV ASPNETCORE_URLS http://0.0.0.0:1905
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:1905"]
