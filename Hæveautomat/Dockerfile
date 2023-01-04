FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hæveautomat/Hæveautomat.csproj", "Hæveautomat/"]
RUN dotnet restore "Hæveautomat/Hæveautomat.csproj"
COPY . .
WORKDIR "/src/Hæveautomat"
RUN dotnet build "Hæveautomat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hæveautomat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hæveautomat.dll"]
