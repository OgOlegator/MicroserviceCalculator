#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calculator.Services.MinusAPI/Calculator.Services.MinusAPI.csproj", "Calculator.Services.MinusAPI/"]
RUN dotnet restore "Calculator.Services.MinusAPI/Calculator.Services.MinusAPI.csproj"
COPY . .
WORKDIR "/src/Calculator.Services.MinusAPI"
RUN dotnet build "Calculator.Services.MinusAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculator.Services.MinusAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculator.Services.MinusAPI.dll"]