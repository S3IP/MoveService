#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["s3-dreamcatcher-api/s3-dreamcatcher-api.csproj", "s3-dreamcatcher-api/"]
RUN dotnet restore "s3-dreamcatcher-api/s3-dreamcatcher-api.csproj"
COPY . .
WORKDIR "/src/s3-dreamcatcher-api"
RUN dotnet build "s3-dreamcatcher-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "s3-dreamcatcher-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "s3-dreamcatcher-api.dll"]
