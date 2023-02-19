FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CursoDotNetExpert/CursoDotNetExpert.csproj", "CursoDotNetExpert/"]
RUN dotnet restore "CursoDotNetExpert/CursoDotNetExpert.csproj"
COPY . .
WORKDIR "/src/CursoDotNetExpert"
RUN dotnet build "CursoDotNetExpert.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CursoDotNetExpert.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CursoDotNetExpert.dll"]
