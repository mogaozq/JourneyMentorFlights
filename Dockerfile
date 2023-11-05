#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JourneyMentorFlights.Api/JourneyMentorFlights.Api.csproj", "JourneyMentorFlights.Api/"]
COPY ["JourneyMentorFlights.Application/JourneyMentorFlights.Application.csproj", "JourneyMentorFlights.Application/"]
COPY ["JourneyMentorFlights.Domain/JourneyMentorFlights.Domain.csproj", "JourneyMentorFlights.Domain/"]
COPY ["JourneyMentorFlights.Infrastructure/JourneyMentorFlights.Infrastructure.csproj", "JourneyMentorFlights.Infrastructure/"]
RUN dotnet restore "JourneyMentorFlights.Api/JourneyMentorFlights.Api.csproj"
COPY . .
WORKDIR "/src/JourneyMentorFlights.Api"
RUN dotnet build "JourneyMentorFlights.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JourneyMentorFlights.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JourneyMentorFlights.Api.dll"]