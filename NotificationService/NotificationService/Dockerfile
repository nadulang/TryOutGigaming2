FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-notifications
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/allnotif
FROM mcr.microsoft.com/dotnet/core/aspnet

WORKDIR /app
COPY --from=build-notifications src/out/allnotif .
ENTRYPOINT ["dotnet", "NotificationService.dll"]
