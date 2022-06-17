#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#ENV ASPNETCORE_URLS=http://+:5001
#EXPOSE 5001

#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["MoveService/MoveService.csproj", "MoveService/"]
#RUN dotnet restore "MoveService/MoveService.csproj"
#COPY . .
#WORKDIR "/src/MoveService"
#RUN dotnet build "MoveService.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "MoveService.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MoveService.dll"]

# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "MoveService.csproj" --disable-parallel
RUN dotnet publish "MoveService.csproj" -c release -o /app --no-restore

# Run
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

#EXPOSE 5000

ENTRYPOINT ["dotnet", "MoveService.dll"]
