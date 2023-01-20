FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5067

ENV ASPNETCORE_URLS=http://+:5067
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TopSchool.API/TopSchool.API.csproj", "TopSchool.API/"]
COPY ["TopSchool.API/TopSchool.Domain.csproj", "TopSchool.Domain/"]
COPY ["TopSchool.API/TopSchool.Infra.csproj", "TopSchool.Infra/"]
COPY ["TopSchool.API/TopSchool.Service.csproj", "TopSchool.Service/"]

RUN dotnet restore "TopSchool.API\TopSchool.API.csproj"
COPY . .
WORKDIR "/src/TopSchool.API"
RUN dotnet build "TopSchool.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TopSchool.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TopSchool.API.dll"]
