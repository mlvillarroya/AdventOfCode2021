FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day3/Day3.csproj", "Day3/"]
RUN dotnet restore "Day3/Day3.csproj"
COPY . .
WORKDIR "/src/Day3"
RUN dotnet build "Day3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day3.dll"]
