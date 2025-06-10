#Call sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#Establish root folder
WORKDIR /src
#Copy the entire code
COPY . .
#Restore NuGet Package
RUN dotnet restore
##Compile and publish in release mode
RUN dotnet publish -c Release -o /app/publish

#Use light image for run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#Copy only compiled files
WORKDIR /app
COPY --from=build /app/publish .
#Open 8080 port within the container
EXPOSE 8080
#This command run the microservice
ENTRYPOINT ["dotnet", "PrimerMicroServicio.dll"]
