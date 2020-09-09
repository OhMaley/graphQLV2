# graphQLV2

This is a small project made for understanding the basics of GraphQL.

This project contains a small web client from which a user can type a graphQL query that is sent through http to a dotnet server. This server send the necessary front-end files to the browser and catch graphQL queries, execute them and send back the requested json object to the client. Then the vuejs framework updates automatically the result section of the webpage with the json object.

## Instalation

1) Open visual studio and clone this repository.

Then, using a terminal, run npm install inside the client folder as follow:
```bash
cd graphQLV2/clientapp
npm install
```

## Usage
1) Start the Server using the 'graphQLV2' config instead of IIS Express

2) Open your favourite browser and go to http://localhost:8080/


From here you can add any amount of movies (only his title is required).

You can also select a movie and see / add actors (only their name is required) to it by clicking on it.
