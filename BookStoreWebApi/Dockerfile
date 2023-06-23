
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookStoreWebApi/BookStoreWebApi.csproj", "BookStoreWebApi/"]
COPY ["BookStore.Application/BookStore.Application.csproj", "BookStore.Application/"]
COPY ["BookStore.Domain/BookStore.Domain.csproj", "BookStore.Domain/"]
COPY ["BookStore.Persistence/BookStore.Persistence.csproj", "BookStore.Persistence/"]
RUN dotnet restore "BookStoreWebApi/BookStoreWebApi.csproj"
COPY . .
WORKDIR "/src/BookStoreWebApi"
RUN dotnet build "BookStoreWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStoreWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStoreWebApi.dll"]