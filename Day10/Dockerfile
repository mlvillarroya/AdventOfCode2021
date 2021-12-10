FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day10/Day10.csproj", "Day10/"]
RUN dotnet restore "Day10/Day10.csproj"
COPY . .
WORKDIR "/src/Day10"
RUN dotnet build "Day10.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day10.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day10.dll"]
