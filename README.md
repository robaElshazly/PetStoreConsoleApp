## About the App
This is a .Net Core console app that executes the API of https://petstore.swagger.io/

* The App executes an endpoint to get all available pets.
* The App sorts pets by Category and displays them in reverse order by Name.
* The app includes unit tests to test sorting by Category and names, also unit tests for the API calls.

## Prerequisite
.Net Core 5 SDK

## How to Run The App
* Clone this repo
* Navigate to the repo directory
* Then to run the app, execute the following command
```
dotnet run --project PetStoreConsoleApp
```
* To run the unit tests, execute the following command
```
dotnet test PetStoreUnitTest
```