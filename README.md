# Pizzeria
A simple web application to manage pizzas and their prices in different locations of the restaurant <br />
Coded in .NET 6 and React <br />
Technologies used:
* .NET 6
* EntityFramework Core
* React

Design patterns used:
* CQRS
* Repository pattern
* Clean code architecture

### How to run Pizzeria on your machine?
#### Back-end:
Prerequisite software
* Visual Studio
* MS SQL Server Management Studio

In order to run back end, you need to have .NET 6 installed on your Visual Studio
1. Before running, go to appsettings.json file, and update the following with your database connection string:
* ```"DefaultConnection": "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=my_pizzeria; Integrated Security=True"```
* In my case, it is ```my_pizzeria``` but you can give in any name you want.
2. Once this is done, open ```package manager console``` and type: ```Update-Database```
This should create schema and apply all migrations to your database. You can verify the changes by opening your database in MSSQL Server.

3. It is always good idea to build solution before starting.
4. Now select ```pizzeriaserver``` as your startup project and start with debugging.
You should see Swagger UI page open in your browser on ```localhost:7213```
If you have seen this, it is good news!
<img width="930" alt="image" src="https://user-images.githubusercontent.com/33806340/218599717-46171c89-c79c-4544-88f9-7aae8d05d3bc.png">

#### Front-end:
Prerequisite software installation
* NodeJS
* npm

1. Open command line and go to ```pizzeriaclient``` as root directory.
2. Run command ```npm install```. This should install all node modules from package.json file
3. Now run command ```npm start```
4. Once code is compiled, this should open the react app in your browser with URL: http://localhost:3000 and you should land to the home page of the application.

Current version of Pizzeria does not have login and logout functionality for admin. You can go to admin portal by appending ```/adminhome``` to the url of home page.
So the url for admin page will be: http://localhost:3000/adminhome.
If you want to add locations, click ```Modify Locations```. Now your url will become: http://localhost:3000/adminmodifylocations
Once you have added atleast one location of Pizzeria, you can also navigate to ```Modify Menu``` page (http://localhost:3000/adminmodifymenu) and add some pizzas to the menu by clicking ```Add a new Pizza```.
Once pizzas are added, go to home page (http://localhost:3000), and your can start ordering by clicking ```Start New Order```

Start by select a location. Once a location is selected, the available pizzas in that location are shown, along with their description and prices. There are also ```-``` and ```+``` buttons in front of each pizza. You can use these buttons to add the number of pizzas to your order. 
At bottom of this screen, you can see the ```total price of your order``` getting updated in real time.
