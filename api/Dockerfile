# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 5248
# EXPOSE 5249


# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src
# COPY ["api/api.csproj", "api/"]
# RUN dotnet restore "api/api.csproj"
# COPY . .
# WORKDIR "/src/api"
# RUN dotnet build "api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
# RUN dotnet publish "api.csproj" -c $BUILD_CONFIGURATION -o /app/publish 

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "api.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]