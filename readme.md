This project is a simple Library created using dotnet 6 and react on frontend


To run the project you need to:

Make sure you have all the dependencies installed, they are:
    dotnet 6: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
    node 18+: https://nodejs.org/en/download/

Run the scripts of 'scripts' folder on your SQL Database (following the numeric order)

Run the api by entering the 'api' folder and running
    `dotnet run`

Run the frontend by entering the 'client' folder and running
    `npm i`
    `npm run start`



## Architecture decisions

**Clean Architecture
I decided to use an adaptation of Clean Architecture looking for a better readability and maintenance of the code
    
**Dapper
Entity framework is easier to use and sometimes the code looks better than dapper, but with dapper we have more control over the queries that are being executed on database, then the decision was by dapper was looking for better control and also better performance of the database operations.

**MUI
MUI is a MaterialUI component library designed for react, we decided to use MUI because of the high community adoption