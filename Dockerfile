FROM microsoft/dotnet:latest
COPY src /app
WORKDIR /app
RUN ["dotnet", "restore"]
WORKDIR /app/NetCoreTestCI.Web
RUN ["dotnet", "build", "--configuration", "Release"]
ENV ASPNETCORE_URLS http://+:1905
EXPOSE 1905
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://+:1905"]
