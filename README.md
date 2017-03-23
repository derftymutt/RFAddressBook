# RFAddressBook

Hello!

Once you have cloned this to your local machine, all that is needed is to run the application 
in your browser and access the API via a RESTClient using the API below.  
The database is integrated into the solution (and can be accessed via the Server Explorer in Visual Studio). 
The database file is within the App_Data folder.


Roofshoot AddressBook API 

--CRUD operations for UserAddresses--

POST api/users/{userId:int}/addresses   //create a new address by user

PUT api/users/{userId:int}/addressses/{id:guid}   //update an existing address by user

GET api/users/{userId:int}/addresses    //get all addresses by user

GET api/users/{userId:int}/addresses/{id:guid}    //get one address by user

DELETE api/users/{userId:int}/addresses/{id:guid}     //delete an address by user


Happy addressbooking!

Allen
