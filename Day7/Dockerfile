FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day7/Day7.csproj", "Day7/"]
RUN dotnet restore "Day7/Day7.csproj"
COPY . .
WORKDIR "/src/Day7"
RUN dotnet build "Day7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day7.dll"]
