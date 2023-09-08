FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TaskNinja/TaskNinja.csproj", "TaskNinja/"]
RUN dotnet restore "TaskNinja/TaskNinja.csproj"
COPY . .
WORKDIR "/src/TaskNinja"
RUN dotnet build "TaskNinja.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskNinja.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskNinja.dll"]
