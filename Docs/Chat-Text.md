### Steps Compelted
- [x] Setup Docker
- [x] Setup PGamin4
- [x] Planning Chatroom DB
- [x] Planning Chathistory DB
- [x] Setup Chatroom DB
- [x] Setup ChatHistory DB
- [x] Setup Room Creator

### Setup of Databases
For the chatroom setup I had used the **Ef Migration** to autosetup the Databases based on the written functions on the _UserDbContext.cs_ file located in `Backend/src/UserApi/Entities/` File.

### Setup of Room Creator
For the setup fo a room I was required to make a controller to keep track not just of the creation, but as well other actions I will develop further on. I was required to create a post `Chatroom/room` of typer **Post** to make the action of posting a new room into the database. afterwards I required to setup the function which gets activated with `[HttpPost("room")]` which runs the process of creating a new room.

In order to make the new room a _password must be set of minimum 8 characters_ and a _title_. The **Id** is set automatically onces the required fields where filled correctly then it go to create the database and it maps all the information from the database in the required fields.

When the post has been activated then a request, if all is good to go then it brings back a response.