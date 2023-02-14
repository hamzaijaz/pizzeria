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
<img width="287" alt="image" src="https://user-images.githubusercontent.com/33806340/218648571-c138df75-84e6-4af7-8b48-970c48529913.png">


### How to run Pizzeria on your machine?
#### Back-end:
Prerequisite software
* Visual Studio
* MS SQL Server Management Studio

In order to run back end, you need to have .NET 6 installed on your Visual Studio
1. Before running, go to appsettings.json file, and update the following with your database connection string:
* ```"DefaultConnection": "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=my_pizzeria; Integrated Security=True"```
<img width="994" alt="image" src="https://user-images.githubusercontent.com/33806340/218648753-98e649c5-436a-48c4-a5da-1c6f8fc42764.png">

* In my case, it is ```my_pizzeria``` but you can give in any name you want.
2. Once this is done, open ```package manager console``` and type: ```Update-Database```
<img width="434" alt="image" src="https://user-images.githubusercontent.com/33806340/218648912-06d17b95-3933-4424-bcd2-b59b0cb80171.png">

This should create schema and apply all migrations to your database. You can verify the changes by opening your database in MSSQL Server.
<img width="175" alt="image" src="https://user-images.githubusercontent.com/33806340/218649020-c1694cda-a9c4-4f1c-9e58-fed263edc565.png">

3. It is always good idea to build solution before starting.
4. Now select ```pizzeriaserver``` as your startup project and start with debugging.
<img width="668" alt="image" src="https://user-images.githubusercontent.com/33806340/218649158-d8292a85-b0e7-406a-aa3f-d17148591e2c.png">

You should see Swagger UI page open in your browser on ```localhost:7213```
If you have seen this, it is good news!
<img width="930" alt="image" src="https://user-images.githubusercontent.com/33806340/218599717-46171c89-c79c-4544-88f9-7aae8d05d3bc.png">

#### Front-end:
Prerequisite software installation
* NodeJS
* npm

1. Open command line and go to ```pizzeriaclient``` as root directory.
2. Run command ```npm install```. This should install all node modules from package.json file
<img width="319" alt="image" src="https://user-images.githubusercontent.com/33806340/218649487-4241eca1-2f4b-4614-84e6-b5a56452fb59.png">

3. Now run command ```npm start```
<img width="292" alt="image" src="https://user-images.githubusercontent.com/33806340/218649557-845c9f29-5e20-4725-85b9-16d9e731f941.png">

4. Once code is compiled, this should open the react app in your browser with URL: http://localhost:3000 and you should land to the home page of the application.
<img width="854" alt="image" src="https://user-images.githubusercontent.com/33806340/218649711-9bb5fccb-6c62-4890-a8e8-695e342a70ab.png">

Current version of Pizzeria does not have login and logout functionality for admin. You can go to admin portal by appending ```/adminhome``` to the url of home page.
So the url for admin page will be: http://localhost:3000/adminhome.
<img width="887" alt="image" src="https://user-images.githubusercontent.com/33806340/218649844-d474f5fe-4385-4d8c-815b-2a60400f6e66.png">

If you want to add locations, click ```Modify Locations```. Now your url will become: http://localhost:3000/adminmodifylocations
Once you have added atleast one location of Pizzeria, you can also navigate to ```Modify Menu``` page (http://localhost:3000/adminmodifymenu) and add some pizzas to the menu by clicking ```Add a new Pizza```.
Once pizzas are added, go to home page (http://localhost:3000), and your can start ordering by clicking ```Start New Order```

Start by select a location. Once a location is selected, the available pizzas in that location are shown, along with their description and prices. There are also ```-``` and ```+``` buttons in front of each pizza. You can use these buttons to add the number of pizzas to your order. 
At bottom of this screen, you can see the ```total price of your order``` getting updated in real time.
