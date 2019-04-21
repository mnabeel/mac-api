FROM microsoft/dotnet:2.1-sdk as build
WORKDIR /app

# Copy csproj and restore as distinct layer
COPY *.csproj ./
RUN dotnet restore

# Copy SQLite database file
COPY *.db ./

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime as runtime
WORKDIR /app

COPY --from=build /app/out .
# Install SQLite 
RUN apt-get -y update
RUN apt-get -y upgrade
RUN  apt-get install -y sqlite3 libsqlite3-dev
RUN sqlite3 MacApiMembers.db  "create table Member (Id smallint, Name varchar(50));"

ENTRYPOINT ["dotnet", "mac-api.dll"]

