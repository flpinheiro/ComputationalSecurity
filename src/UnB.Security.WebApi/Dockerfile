#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/UnB.Security.WebApi/UnB.Security.WebApi.csproj", "src/UnB.Security.WebApi/"]
COPY ["src/UnB.Security/UnB.Security.csproj", "src/UnB.Security/"]
RUN dotnet restore "src/UnB.Security.WebApi/UnB.Security.WebApi.csproj"
COPY . .
WORKDIR "/src/src/UnB.Security.WebApi"
RUN dotnet build "UnB.Security.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnB.Security.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnB.Security.WebApi.dll"]