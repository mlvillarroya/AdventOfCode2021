FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day13/Day13.csproj", "Day13/"]
RUN dotnet restore "Day13/Day13.csproj"
COPY . .
WORKDIR "/src/Day13"
RUN dotnet build "Day13.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day13.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day13.dll"]
