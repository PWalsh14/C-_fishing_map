
# Big FishUs

## Overview

This project is a Windows Forms application designed to promote adherence to sustainable fishing laws by mapping fishing restrictions. These restrictions can be fetched from a dataset or manually inputted, corresponding to customizable zones on a map of the United Kingdom. It is designed for a company to use a large dataset in their primary location for all zones, while individual expedition teams can have just the zones and restrictions required. The application utilizes several libraries for functionalities such as password hashing, mapping, database interaction, and unit testing. It is connected to a SQLite database instance containerized by Docker, allowing the database to be updateable offline.

## Essential Features

- **Login System**: 
  - Login system with user privileges, data validation, and password changing.
  - Passwords hashed with BCrypt.

- **Admin Map**: 
  - Users with the admin role can create and remove drawable zones on the map.

- **Data Import**: 
  - Admins can update the data from the official UK 'Seafish' fishing restrictions dataset.

- **Standard Map**: 
  - Non-admin users can view the restrictions zone map but cannot make any changes.

- **Fishing Log**: 
  - Allows users to store details about prior fishing expeditions in zones, recording observations with a timestamp.

- **User Administration**: 
  - Admins can delete and promote other users to admin.

## Requirements

- .NET 6.0 SDK or later
- Visual Studio 2022 or later (or any compatible IDE)
- Docker Desktop
  
## Instructions on How to Run the System

1. **Open Docker Desktop**

2. **Open Terminal to the CSC2033_TeamProject directory**

3. **Type in the Terminal:**
    ```sh
    dotnet restore
    ```

4. **In an IDE, Run `program.cs` in the root of CSC2033_TeamProject**

5. On Exit - Remove the Docker container from your Docker Desktop client

# Relevant Documentation For Markers


Project Repository:
https://github.com/newcastleuniversity-computing/Group21-project

## Supporting files can be found inside root folder and also in the "Support Documents" folder inside "CSC2033_TeamProject"



Project Roles:

Tom - Project Manager and Front End Design

Camina - Map Engineering, Geodesic Maths Programming

James - Database Engineer and Back End Programming

Aoife -  Database Engineer 

Owen - General functionality

Patrick -
