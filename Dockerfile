FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5067

ENV ASPNETCORE_URLS=http://+:5067

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TopSchool.API/TopSchool.API.csproj", "TopSchool.API/"]
RUN dotnet restore "TopSchool.API\TopSchool.API.csproj"
COPY . .
WORKDIR "/src/TopSchool.API"
RUN dotnet build "TopSchool.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TopSchool.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TopSchool.API.dll"]
