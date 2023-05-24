FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

COPY ./TodoApi.csproj ./TodoApi/TodoApi.csproj

RUN dotnet restore "TodoApi/TodoApi.csproj"

COPY ./ ./TodoApi
RUN dotnet publish "TodoApi/TodoApi.csproj" -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TodoApi.dll"]