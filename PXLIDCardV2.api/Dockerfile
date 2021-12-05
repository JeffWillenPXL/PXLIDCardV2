#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PXLIDCardV2.api/PXLIDCardV2.api.csproj", "PXLIDCardV2.api/"]
COPY ["PXLIDCardV2.data/PXLIDCardV2.data.csproj", "PXLIDCardV2.data/"]
COPY ["PXLIDCardV2.domain/PXLIDCardV2.domain.csproj", "PXLIDCardV2.domain/"]
COPY ["PXLIDCardV2.business/PXLIDCardV2.business.csproj", "PXLIDCardV2.business/"]
RUN dotnet restore "PXLIDCardV2.api/PXLIDCardV2.api.csproj"
COPY . .
WORKDIR "/src/PXLIDCardV2.api"
RUN dotnet build "PXLIDCardV2.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PXLIDCardV2.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PXLIDCardV2.api.dll"]