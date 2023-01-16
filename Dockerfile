#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RickAndMortyAPI/RickAndMortyAPI.csproj", "RickAndMortyAPI/"]
COPY ["DAL/DAL.csproj", "RickAndMortyAPI/"]
COPY ["BLL/BLL.csproj", "RickAndMortyAPI/"]
COPY . .
RUN dotnet restore "RickAndMortyAPI/RickAndMortyAPI.csproj"
RUN dotnet publish "RickAndMortyAPI/RickAndMortyAPI.csproj" -c Release -o /app --no-restore

#Server Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR "/app"
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "RickAndMortyAPI.dll"]
