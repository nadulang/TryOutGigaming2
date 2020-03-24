FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-payment
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/allpayment
FROM mcr.microsoft.com/dotnet/core/aspnet

WORKDIR /app
COPY --from=build-payment src/out/allpayment .
ENTRYPOINT ["dotnet", "PaymentService.dll"]
