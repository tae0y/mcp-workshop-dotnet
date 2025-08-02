
# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

COPY . /source

WORKDIR /source/src/McpTodoServer.ContainerApp

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final

WORKDIR /app

COPY --from=build /app .

# 과도한 권한부여
RUN chmod -R 777 /app

USER $APP_UID

ENTRYPOINT ["dotnet", "McpTodoServer.ContainerApp.dll"]