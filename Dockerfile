FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 3000

ENV ASPNETCORE_URLS=http://+:3000
ENV ApiAmazon__password="Password from dockerfile"


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["variables-entorno.csproj", "./"]
RUN dotnet restore "variables-entorno.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "variables-entorno.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "variables-entorno.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "variables-entorno.dll"]