  
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY Todo.Application/*.csproj ./Todo.Application/
COPY Todo.Domain/*.csproj ./Todo.Domain/
COPY Todo.Infrastructure/*.csproj ./Todo.Infrastructure/

RUN dotnet restore ./Todo.Application/

# Build da aplicacao
COPY . ./
RUN dotnet build -c Release -o out ./Todo.Application

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Todo.Application.dll"]