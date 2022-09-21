#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InClub.Api/InClub.Api.csproj", "InClub.Api/"]
COPY ["InClub.Util/InClub.Util.csproj", "InClub.Util/"]
COPY ["InClub.Service/InClub.Service.csproj", "InClub.Service/"]
COPY ["InClub.Exceptions/InClub.Exceptions.csproj", "InClub.Exceptions/"]
COPY ["InClub.Domain/InClub.Domain.csproj", "InClub.Domain/"]
COPY ["InClub.Repository/InClub.Repository.csproj", "InClub.Repository/"]
COPY ["InClub.Entities/InClub.Entities.csproj", "InClub.Entities/"]
COPY ["InClub.Infraestructure/InClub.Infraestructure.csproj", "InClub.Infraestructure/"]
RUN dotnet restore "InClub.Api/InClub.Api.csproj"
COPY . .
WORKDIR "/src/InClub.Api"
RUN dotnet build "InClub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InClub.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InClub.Api.dll"]