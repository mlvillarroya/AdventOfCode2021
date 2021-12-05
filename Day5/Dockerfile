FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day5/Day5.csproj", "Day5/"]
RUN dotnet restore "Day5/Day5.csproj"
COPY . .
WORKDIR "/src/Day5"
RUN dotnet build "Day5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day5.dll"]
