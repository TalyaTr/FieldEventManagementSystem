"# FieldEventManagementSystem"

Running the System

Below are the full instructions for running each component.



1\. Clone the repository:



git clone https://github.com/<your-org>/<your-repo>.git

cd <your-repo>



2\. Configure environment variables

Backend API

Create a file:

src/Backend/appsettings.Development.json



Example:

{

&#x20; "ConnectionStrings": {

&#x20;   "DefaultConnection": "Server=localhost;Database=WebSystem;Trusted\_Connection=True;"

&#x20; },

&#x20; "Jwt": {

&#x20;   "Issuer": "WebSystem",

&#x20;   "Audience": "WebSystemUsers",

&#x20;   "Key": "YOUR\_SECRET\_KEY"

&#x20; },

&#x20; "Agent": {

&#x20;   "ApiKey": "AGENT\_SECRET\_KEY"

&#x20; }

}



Agent

Create:

src/Agent/appsettings.json



Example:

{

&#x20; "BackendUrl": "https://localhost:5001/api/events/ingest",

&#x20; "Sources": \[

&#x20;   {

&#x20;     "Type": "http",

&#x20;     "Name": "LocalApp",

&#x20;     "Port": 6000,

&#x20;     "ApiKey": "SOURCE\_KEY"

&#x20;   }

&#x20; ],

&#x20; "Buffer": {

&#x20;   "StoragePath": "buffer.db"

&#x20; }

}



Frontend

Create:

src/Frontend/src/environments/environment.ts



Example:



export const environment = {

&#x20; production: false,

&#x20; apiUrl: 'https://localhost:5001/api',

&#x20; signalRHub: 'https://localhost:5001/hub/notifications'

};



3\. Run the Backend API

Navigate to backend folder:



cd src/Backend

dotnet restore

dotnet build

dotnet ef database update

dotnet run

API will start at:

https://localhost:5001



Swagger UI:

ttps://localhost:5001/swagger

4\. Run the Agent Service

Navigate to Agent folder:



cd src/Agent

dotnet restore

dotnet build

dotnet run



Agent will:



Start listening for events from configured sources



Buffer events locally



Forward them to the backend



5\. Run the Angular Frontend

Navigate to frontend folder:



cd src/Frontend

npm install

ng serve



Frontend will start at:

http://localhost:4200

