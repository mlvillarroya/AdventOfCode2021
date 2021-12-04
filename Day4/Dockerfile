FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Day4/Day4.csproj", "Day4/"]
RUN dotnet restore "Day4/Day4.csproj"
COPY . .
WORKDIR "/src/Day4"
RUN dotnet build "Day4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day4.dll"]
