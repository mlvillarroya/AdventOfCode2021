FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day6/Day6.csproj", "Day6/"]
RUN dotnet restore "Day6/Day6.csproj"
COPY . .
WORKDIR "/src/Day6"
RUN dotnet build "Day6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day6.dll"]
