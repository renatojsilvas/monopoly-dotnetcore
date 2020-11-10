FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build

WORKDIR /app

COPY *.sln .

COPY src/monopoly/*.csproj ./src/monopoly/
COPY test/monopoly.tests/*.csproj ./test/monopoly.tests/

RUN dotnet restore

COPY . .

RUN dotnet build

FROM build AS testrunner
WORKDIR /app/test/monopoly.tests/
CMD ["dotnet", "test", "--logger:trx"]

FROM build AS test
WORKDIR /app/test/monopoly.tests
RUN dotnet test --logger:trx

FROM build AS publish

WORKDIR /app/src/monopoly

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
WORKDIR /app

COPY --from=publish /app/src/monopoly/out ./

ENTRYPOINT ["dotnet", "monopoly.dll"]