FROM microsoft/dotnet:latest
# Set the Working Directory
WORKDIR ./app
# Configure the listening port to 80
EXPOSE 5006
# Copy the app
COPY /bin/Debug/netcoreapp1.0/publish/ /app/ 
# Start the app
ENTRYPOINT dotnet DotNetCoreSample.dll --server.urls  http://*:5006