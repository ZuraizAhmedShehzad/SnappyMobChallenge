FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ChallengeB_App.csproj ChallengeB_App/
WORKDIR /src/ChallengeB_App
RUN dotnet restore

COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir -p /app/input
COPY random_object.txt /app/input/random_object.txt

RUN mkdir -p /app/output

ENTRYPOINT ["dotnet", "ChallengeB_App.dll"]
