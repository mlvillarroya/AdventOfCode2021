FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day2/Day2.csproj", "Day2/"]
RUN dotnet restore "Day2/Day2.csproj"
COPY . .
WORKDIR "/src/Day2"
RUN dotnet build "Day2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day2.dll"]
