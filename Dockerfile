FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . .

RUN dotnet restore BookMe.BookingService.sln
RUN dotnet publish -c Release -o /dist

# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build-env /dist .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet BookMe.BookingService.Host.dll
