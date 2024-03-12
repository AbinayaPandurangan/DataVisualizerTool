# Data Visualizer Tool

The tool visualizes the data provided by the user in a Bar chart, which will also show randomized data in the interval of 60seconds.

## How it works

Step 1: The uploaded data file is first validated to check if it is in the correct FileType and if it contains data (not empty file) in the Client side.

Step 2: Then the data in the file is extracted and validated to check if the data is in the correct format and then the processed and saved to the database in the server side. The data is then received by the Client and is visualized as a Bar chart.

Step 3: The client also sends request for a random data to the server every 60sec. The server generated data is then received by the Client and is visualized as a Bar chart.

## Set-up and run API:

Navigate to the root folder<br/>
In cmd line - run the below cmds <br/>
cd Snow.DataVisualizer.API<br/>
dotnet run
To Confirm that the API is running, open in the browser "https://localhost:7128/swagger/index.html"

## Set-up and run UI:

Navigate to the root folder<br/>
In cmd line - run the below cmds<br/>
cd "Snow.DataVisualizer.Web\ClientApp"<br/>
npm install<br/>
npm start<br/>
Run in the Browser "https://localhost:5000"

## Test Data:

Test Data Files are available in the "TestData" folder in the root path

## TechStack:

Backend:<br/>

1. .Net 6
2. SQLite
3. xUnit
4. Moq
5. Entity Framework
6. Fluent Validation
7. Serilog
8. Postman

Frontend: </br>

1. React
2. Material UI
3. React-Testing-Library
4. Jest
5. jest-matchmedia-mock
