# Esta é a imagem base para compilar o código
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto e restaura as dependências
COPY ["techjobs-api/techjobs-api.csproj", "techjobs-api/"]
RUN dotnet restore "./techjobs-api/techjobs-api.csproj"

# Copia o restante do código e compila
COPY . .
WORKDIR "/src/techjobs-api"
RUN dotnet build "./techjobs-api.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "./techjobs-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Esta é a imagem base para a aplicação ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Copia a aplicação publicada
COPY --from=publish /app/publish .

# Esta é a imagem final, que inclui a aplicação publicada
FROM base AS final
ENTRYPOINT ["dotnet", "techjobs-api.dll", "--server.urls", "http://+:8080", "https://+:443"]
