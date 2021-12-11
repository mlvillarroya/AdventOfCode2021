FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day11/Day11.csproj", "Day11/"]
RUN dotnet restore "Day11/Day11.csproj"
COPY . .
WORKDIR "/src/Day11"
RUN dotnet build "Day11.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day11.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day11.dll"]
