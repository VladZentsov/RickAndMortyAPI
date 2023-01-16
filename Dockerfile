#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RickAndMortyAPI/RickAndMortyAPI.csproj", "RickAndMortyAPI/"]
COPY ["DAL/DAL.csproj", "RickAndMortyAPI/"]
COPY ["BLL/BLL.csproj", "RickAndMortyAPI/"]
#RUN dotnet restore "RickAndMortyAPI/RickAndMortyAPI.csproj"
COPY . .
WORKDIR "/src/RickAndMortyAPI"
#RUN dotnet restore "RickAndMortyAPI/RickAndMortyAPI.csproj"
RUN dotnet build "RickAndMortyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RickAndMortyAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

#Server Stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RickAndMortyAPI.dll"]