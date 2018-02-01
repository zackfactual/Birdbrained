# Birdbrained
Birdbrained, an ASP.NET MVC project made in Visual Studio, is a taxonomic key to the birds of Tompkins County, NY. 

***THE DATA SOURCE***

An Excel spreadsheet from a field bio course I took in college serves as the data source for a SQL Server database: 
![Screenshot](Birdbrained/screenshots/ExcelSheetDataSource.png)

***THE CODE***

I imported the spreadsheet data into a new SSMS database.
In SSMS I reformatted the data types and added a Guid primary key.
I then detached the database from SSMS and attached it to my MVC solution in Visual Studio:
![Screenshot](Birdbrained/screenshots/BirdsTableModifiedInSSMSAndAttachedToSolution.png)

To my Models folder, I added an ADO.NET Entity Data Model, which generated a Bird partial class:
![Screenshot](Birdbrained/screenshots/BirdPartialClassGeneratedFromADO.NETEntityDataModel.png)

I then added another Bird partial class for metadata:
![Screenshot](Birdbrained/screenshots/BirdPartialClassWithMetadata.png)

From the Bird Model, I scaffolded an Admin Controller in my Admin Area, authorized with total CRUD functionality:
![Screenshot](Birdbrained/screenshots/AdminAreaAdminBirdsControllerThatAuthorizesAdminWithFullCRUDFunctionality.png)

I also scaffolded a User Controller to my User Area, with Details and Index Views only:
![Screenshot](Birdbrained/screenshots/UserAreaUserBirdsControllerWithDetailsAndIndexViewsOnly.png)

Here's the AdminArea/AdminBirds/Index View (left) opposite the UserArea/UserBirds/Index View (right):
![Screenshot](Birdbrained/screenshots/AdminAreaIndexViewVSUserAreaIndexView.png)

Here's the AdminArea/AdminBirds/Details View (left) opposite the UserArea/UserBirds/Details View (right):
![Screenshot](Birdbrained/screenshots/AdminAreaDetailsViewVSUserAreaDetailsView.png)

***RUNNING THE APPLICATION***

The Home Page:
![Screenshot](Birdbrained/screenshots/HomePage.png)

The Index page for guests and guest users:
![Screenshot](Birdbrained/screenshots/GuestAndOrdinaryUserIndexView.png)

The Details page for guests and guest users:
![Screenshot](Birdbrained/screenshots/GuestAndOrdinaryUserDetailsView.png)

The Index page for admins:
![Screenshot](Birdbrained/screenshots/AdminIndexView.png)

The Details page for admins:
![Screenshot](Birdbrained/screenshots/AdminDetailsView.png)
