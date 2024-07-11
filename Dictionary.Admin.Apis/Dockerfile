#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Dictionary.Admin.Apis/Dictionary.Admin.Apis.csproj", "Dictionary.Admin.Apis/"]
COPY ["DictionaryMng.Business/DictionaryMng.Business.csproj", "DictionaryMng.Business/"]
COPY ["DictionaryMng.Db/DictionaryMng.Db.csproj", "DictionaryMng.Db/"]
RUN dotnet restore "./Dictionary.Admin.Apis/Dictionary.Admin.Apis.csproj"
COPY . .
WORKDIR "/src/Dictionary.Admin.Apis"
RUN dotnet build "./Dictionary.Admin.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dictionary.Admin.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dictionary.Admin.Apis.dll"]