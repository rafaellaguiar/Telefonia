#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Telefonia.Core/Telefonia.Core.csproj", "Telefonia.Core/"]
RUN dotnet restore "Telefonia.Core/Telefonia.Core.csproj"
COPY . .
WORKDIR "/src/Telefonia.Core"
RUN dotnet build "Telefonia.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Telefonia.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Telefonia.Core.dll"]