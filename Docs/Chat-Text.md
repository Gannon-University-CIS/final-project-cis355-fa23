### Steps Compelted
- [x] Setup Docker
- [x] Setup PGamin4
- [x] Planning Chatroom DB
- [x] Planning Chathistory DB
- [x] Setup Chatroom DB
- [x] Setup ChatHistory DB
- [x] Setup Room Creator
- [x] Get Room List
- [x] Room Authentication
- [x] Chat Send
- [x] Get Chat by Id

### Setup of Databases
For the chatroom setup I had used the **Ef Migration** to autosetup the Databases based on the written functions on the _UserDbContext.cs_ file located in `Backend/src/UserApi/Entities/` File.

### Setup of Room Creator
For the setup fo a room I was required to make a controller to keep track not just of the creation, but as well other actions I will develop further on. I was required to create a post `Chatroom/room` of typer **Post** to make the action of posting a new room into the database. afterwards I required to setup the function which gets activated with `[HttpPost("room")]` which runs the process of creating a new room.

In order to make the new room a _password must be set of minimum 8 characters_ and a _title_. The **Id** is set automatically onces the required fields where filled correctly then it go to create the database and it maps all the information from the database in the required fields.

When the post has been activated then a request, if all is good to go then it brings back a response.

### Setup of Room List
By using the **Get** http request we are able to obtain all of the chatrooms created. In comparison with the **Get** from _users_ this one doe snot have any `Role` requierments to view the list of all available chatrooms.

### Room Authentication
In order to enter rooms which you've been invited there are many ways but because if time I chose to make the user type the **id** and the **password**.
if room exist and the password was set right then it `throws back the id`. Later on the Id will be used to get chat messages and send chat messages to a specific chatroom

### Chat Send
To send the chat I made a authenticator which queries for `password` and `room id` in order to find the desired room and verify if you have permission. Once authenticated then there is a http request to obtain the users id. Once the message is sent the `id` of the room and the user are added into the chat message.
### Get Chat By Id
To set it up I set it up just how all the gets where set but with a little twist.
In order to **filter** I added the content of all into a list which later I parse through in a for loop to compare the _id_ of the requested chat room and later it adds all of the ones containing the same id into a list to later be returned. This can be seen in `/backend/src/UserApi/Repositories/UserRepository.cs`.
As well I set up the need for authentication with a password so the content can stay private.