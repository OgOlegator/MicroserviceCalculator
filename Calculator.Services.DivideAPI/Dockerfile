#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calculator.Services.DivideAPI/Calculator.Services.DivideAPI.csproj", "Calculator.Services.DivideAPI/"]
RUN dotnet restore "Calculator.Services.DivideAPI/Calculator.Services.DivideAPI.csproj"
COPY . .
WORKDIR "/src/Calculator.Services.DivideAPI"
RUN dotnet build "Calculator.Services.DivideAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculator.Services.DivideAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculator.Services.DivideAPI.dll"]