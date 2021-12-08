FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day8/Day8.csproj", "Day8/"]
RUN dotnet restore "Day8/Day8.csproj"
COPY . .
WORKDIR "/src/Day8"
RUN dotnet build "Day8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day8.dll"]
