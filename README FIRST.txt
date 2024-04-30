This an Xunit DEMO for unit testing a hypotethical online School application. 
This School contains courses that Students can contract.
Students can only be 18+ years old.
There are free and non free courses.
The students pay for non free courses through a Payment Gateway that is not part
of the School application. For DEMO purposes I've created a Payment System API simulation
that doesn't require Internet connection.
The School domain has been represented in a School library project.


1- Basic Architecture considerations:
	I've implemented the Repository Design Pattern in order to make
	it as much "Database-agnostic" as possible. 
	The classes involved in the Class Library project implement the  
	S.O.L.I.D. principles in order to make them as isolated as possible
	without loosing cohesion and readibility. 
	As a remarkable feature I can mention de abstract class RepositoryBase.cs,
	which describes generic operations for every existing and potentially new repository
	that might be added in future implementations.
	A SQL Server database has been registered as an example but you can run the unit test
	project with any database at all.

2- Technologies implemented:
		* ASP.NET Core 6.
		* Entity Framework Core SQL Server.
		* Microsoft.NET.Test.Sdk.
		* Automapper.Extensions.Microsoft.DependencyInjection.
		* NLog.Extensions.Logging.
		* XUnit.
		* Moq.


1- Solution Projects and Folders structure:

	Project SchoolLibrary:	   	  
		For this DEMO I've created a new library project instead of a full ASP.NET MVC Core or
		Web API application. This was in order to make it simple to understand.	

		Folder SchoolDomain:
		    Contains all the model classes needed to successfully test the 
		    use cases related to students, courses and course 
		    payment transactions.

			The SchoolDomain class contains an overloaded constructor where three objects are initialized for later use in the Use Cases: ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)

			USE CASE 1: CreateAdultStudent(StudentForCreationDto student)
				This Business rule receives a Student DTO object.
			Checks whether it is null, checks whether it is an adult person (18+ years old), 
			attempts to map the DTO Object with its corresponding Entity, attempts to asynchronously create a new Student object usings the DBContext and then save it to the database.
			For DEMO purposes the actual database insertion it's not implemented. 

			USE CASE 2: AdultStudentContractsExistingCourse(CourseScheduleForCreationDto courseschedule)
				Similarly to the previous Business rule, this one receives a CourseSchedule 
			DTOobjectwhich contains information of an existing Student and a course that he/she intends to contract. This method extracts that information from the DTO object, verifies whether the student is an adult person, attempts to map the DTO Object with its corresponding Entity,prepares the PaymentGateway repository to simulate an online transaction and then simulates a successfull one. Indicating that the student was able to contract an existing course successfully.





	Project SchoolLibrary.Test:
		Folder Mocks:
			Contains all the XUnit test cases according to the technical test
		    requirements and its use cases.

	Project Contracts:
			Contains all the interfaces related to both Entities and Repositories of the School Domain project.

	Project Entities:
		Folder DataTransferObjects:	
			 DTOs are used to transfer parameters to methods and as return types.
			 See Martin Fowler's site: https://martinfowler.com/eaaCatalog/dataTransferObject.html
			 DTOs are implemented along with Automapper in this application.
			 The idea of DTOs in particular for this School application DEMO is to ensure that
			 whatever database technology will be easy to attach and then remove from it without the need of complicated refactoring. 


		Folder Models:
			 For this application in particular both the Entities and DBContext were created using
			 Entity Framework Core scaffolding commands.

	Project LoggerService:
			The logging of events in this application is implemented through NLog and its various
			operations are described in the LoggerManager.cs file.
	
	Project Repository:
		    The concrete classes for the Repository Pattern implemented in this application are in this project.



Following the Business Rules described in the folder \\SchoolLibrar\SchoolDomain I've created a set of
Test Methods in the classes  SchoolDomainTests.cs and ValidationTests.cs inside the SchoolLibrary.Tests
project.

		TEST METHOD CreateAdultStudent_ShouldReturnStatus10Test():
		   This test method verifies whether the student's age is "legal" or over 18. So the Test will
		Assert code 10, corresponding to the status code for successfull creation of an adult student
		returned by its corresponding business rule in the School Domain project.

		TEST METHOD AdultStudentContractsExistingCourse_ShouldReturnApprovedStatusTest():
			For this Use Case scenario the Test evaluates that the Student
		is an Adult, the Course exists and it is not free of charge, otherwise it doesn't make sense to pay for it and that the Student's Credit Card and financial status is sufficient
		to approve the online "contract" of the Course.

In addition to the previous test methods, the ValidationTests class in the ValidationTests.cs file
contains tow methods:

	TestModelValidation(): This method simulates the creation of both Courses and Students with a set of different "Xunit In-line data attibute" parameters provided through "Data Anotations". This set of parameters tests different scenarios of creation for the mentioned objects.

	ValidateModel(): This model asserts whether the creation of the mentioned objects under the evaluated scenarios is success or not.

 


	