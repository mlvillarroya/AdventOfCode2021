FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day14/Day14.csproj", "Day14/"]
RUN dotnet restore "Day14/Day14.csproj"
COPY . .
WORKDIR "/src/Day14"
RUN dotnet build "Day14.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day14.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day14.dll"]
