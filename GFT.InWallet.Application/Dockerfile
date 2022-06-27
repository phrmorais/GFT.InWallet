#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GFT.InWallet.Application.csproj", "GFT.InWallet.Application/"]
COPY ["../GFT.InWallet.Domain/GFT.InWallet.Domain.csproj", "GFT.InWallet.Domain/"]
COPY ["../GFT.InWallet.Infra/GFT.InWallet.Infra.csproj", "GFT.InWallet.Infra/"]
COPY ["../GFT.InWallet.Business/GFT.InWallet.Business.csproj", "GFT.InWallet.Business/"]
RUN dotnet restore "GFT.InWallet.Application/GFT.InWallet.Application.csproj"
COPY . .
WORKDIR "/src/GFT.InWallet.Application"
RUN dotnet build "GFT.InWallet.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GFT.InWallet.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GFT.InWallet.Application.dll"]
