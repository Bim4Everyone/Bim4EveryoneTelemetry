FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY Bim4EveryoneTelemetry.csproj Bim4EveryoneTelemetry.csproj
RUN dotnet restore "Bim4EveryoneTelemetry.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Bim4EveryoneTelemetry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bim4EveryoneTelemetry.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bim4EveryoneTelemetry.dll"]
