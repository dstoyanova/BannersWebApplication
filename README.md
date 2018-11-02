This project implements ASP.NET Core Web API with the usage of NoSQL database.

## Software used
- MongoDB
- Microsoft Visual Studio 2017
- Postman 

## Prerequisites
- You can change the connection string and the name of the database in **appsettings.json** , respectively line 3 and 4
- You can change the name of the database collection on line 20 in **BannerContext.cs**

## How to test the different API endpoints
I have used Postman HTTP client to test the Web API and I'm going to include some examples of how to test the different endpoints available.

### Create a Banner
To Create a banner, create a new **POST** request in Postman and paste the code below into the URL field:
```
http://localhost:58718/api/Banner
```
In the Headers section, set **Key** to *Content-Type* and the **Value** to *application/json*. In the **Body** section, enter the **raw** format and paste the following code:
```
{
  "BannerId" : 1,
  "Html" : "<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>",
  "Created" : "2012-04-23T18:25:43.511Z",
  "Modified" : "2012-04-23T18:25:43.511Z"
}
```
Send the request and this will create a new document in the database.

### Update a Banner
To Update the newly created banner, create a new **PUT** request in Postman and paste the code below into the URL field:
```
http://localhost:58718/api/Banner/1
```
The number one stands for the BannerId. Here, you only need to change the Body section with updating the content of the JSON object. Everything else can be left the same. Send the request and this will update the document we created in the previous step.

### Get all the Banners
To see a list of all the documents available in your database, create a new **GET** method in Postman and paste the following code into the URL section:
```
http://localhost:58718/api/Banner
```
This is also the root of the application so, if you run the project from Visual Studio, you will see the same result.

### Get a single Banner
To get a single document from the database, you can do that by adding the BannerId to the url. Paste the following code into a **GET** request in Postman.
```
http://localhost:58718/api/Banner/1
```
This will return the json object for the document we created in the beginning of this guide with BannerId equals to 1.

### Render the HTML content of a Banner
To show the HTML content of a banner with BannerId qual to 1, paste the following code into a **GET** request in Postman:
```
http://localhost:58718/api/Banner/1/Html
```

### Delete a Banner
Finally, to delete a banner from the database, paste the following code into a **DELETE** request in Postman:
```
http://localhost:58718/api/Banner/1
```
