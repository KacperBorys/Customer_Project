# Project_Customer

# Table of Contents📓
* [Project Description](#project-description)
* [Running the Application](#running-the-application)
* [Console Application(class-description)](#console-application)
* [WPF Application (Window Description)](#wpf-application)
* [Project Visualization](#project-visualization)
* [Conclusion](#conclusion)
<br>

## Project Description🖊
The application allows adding, editing, and deleting customers. It has been developed as a console application, but its visualization has been presented in a GUI. The application's functionality is clear and intuitive, allowing the user to easily store information about their customers. Additionally, the user has the ability to save and load data from a file.
<br>

## Running the Application💻
To run the application, compile the project in Visual Studio and run the executable file.<br>
In the main window, click File -> Open -> test.xml
This will allow you to retrieve a list of sample customers.


## Console Application🎮

### Customer Class🙍
The Customer class represents a customer object with attributes such as name, surname, email, VAT identification number, address, phone number, gender, and creation date. It also includes methods for setting and getting these attributes, as well as input validation for email, phone number, and creation date. The class implements the DataContract attribute for serialization purposes and overrides the ToString method to display the customer information in a readable format.

### Clients_Base_Information Class🏠
The Clients_Base_Information class is responsible for managing a list of Customer objects, allowing for adding and removing customers, listing all customers, and serializing/deserializing the list to/from a file using the DataContractSerializer.

## WPF Application🖥
The following windows were used in the project:
* Clients_List (main window)
* Add_Client (adding a customer)
* Edit_Client (editing customer information)


## Project visualization📺
It was made using the WPF platform. Its visualization is presented in the following illustrations:
<br>
<p align="center">
  <img src="https://user-images.githubusercontent.com/101069553/229640093-d5cfc464-7cda-4d83-bbc1-7dea0e2470c1.png" width="500">
</p>
<p align="center">
<img src="https://user-images.githubusercontent.com/101069553/229640346-b200f30c-c1c7-47c7-8b55-ac0ab6cf5263.png" width="500">
</p>
<p align="center">
<img src="https://user-images.githubusercontent.com/101069553/229640795-4c75d97c-c919-46cd-b9a7-041b5d1cee4d.png" width="500">
</p>

## Conclusion🔚
I am satisfied with the project outcome and believe that all goals have been accomplished.✅




