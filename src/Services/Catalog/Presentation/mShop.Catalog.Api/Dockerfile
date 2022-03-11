#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Phone/Presentation/Rise.Phone.Api/Rise.Phone.Api.csproj", "src/Services/Phone/Presentation/Rise.Phone.Api/"]
COPY ["src/Services/Phone/Libraries/Rise.Phone.Services/Rise.Phone.Services.csproj", "src/Services/Phone/Libraries/Rise.Phone.Services/"]
COPY ["src/Services/Phone/Libraries/Rise.Phone.Data/Rise.Phone.Data.csproj", "src/Services/Phone/Libraries/Rise.Phone.Data/"]
COPY ["src/Services/Phone/Libraries/Rise.Phone.Core/Rise.Phone.Core.csproj", "src/Services/Phone/Libraries/Rise.Phone.Core/"]
COPY ["src/Common/Rise.Core/Rise.Core.csproj", "src/Common/Rise.Core/"]
RUN dotnet restore "src/Services/Phone/Presentation/Rise.Phone.Api/Rise.Phone.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Phone/Presentation/Rise.Phone.Api"
RUN dotnet build "Rise.Phone.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rise.Phone.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rise.Phone.Api.dll"]
