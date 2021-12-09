FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day9/Day9.csproj", "Day9/"]
RUN dotnet restore "Day9/Day9.csproj"
COPY . .
WORKDIR "/src/Day9"
RUN dotnet build "Day9.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day9.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day9.dll"]
