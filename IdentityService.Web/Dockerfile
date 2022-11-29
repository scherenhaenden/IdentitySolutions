FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IdentityService.Web/IdentityService.Web.csproj", "IdentityService.Web/"]
RUN dotnet restore "IdentityService.Web/IdentityService.Web.csproj"
COPY . .
WORKDIR "/src/IdentityService.Web"
RUN dotnet build "IdentityService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityService.Web.dll"]
