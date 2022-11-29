# tap
Tap technical test

The fun travel company is planning to build a travel fare service for all its taxi fares and plans to expand this service to include busses and trains fares in the future.

For your task please create a taxi fare calculation application that supports the following functions.

Using any programming language you like preferably Python, C#, Java, Angular, or Flutter

1. Create an application that allows you to register, delete and update driver profiles
		The drive profile consists of the following information.
			1. Name
			2. Surname
			3. Email
			4. VehicleType
			4. Base Fare Price
			5. Base Fare Distance

2. Create a fare calculation function that uses the registered driver to calculate the cheapest fare.

The fare information will be provided in CSV file format. The CSV file will contain the following information, Distance Traveled, Traveled Unit, and Cost Per Distance Traveled.
		
The cost of the fare is determined by the Base Fare Price, Distance Travel, and Cost Per Distance Traveled.

Note that the Cost Per Distance traveled is only applied if the Distance Traveled exceeds the Base Fare Distance.

The fare is calculated using the following formula: 
Fare = Base Fare Price + (Distance Traveled Units * Cost Per Distance Traveled)

Distance Traveled Units is calculated by
	Distance Traveled Units = Base Fare Distance - Distance traveled
	For example
	
	Driver A Base Fare Price = 200 Base Fare Distance = 150
	Driver B Base Fare Price = 300 Base  Fare Distance = 250
	
	Input Text file
	200,50,100
	
Driver A
Since Driver A base distance is 150 and total travel is 200 meaning and the distance travel unit is 50
	 200 - 150 = 50
	 50/50 = 1
	 Price = 200 +(1*100) = 300

Driver B base distance is = 250
	 200 - 250 = -50
	 Price = 300

Since Driver A base price does not cover the total travel distance you have to perform the fare calculate. Whereas Driver B's base price does cover the total travel distance.
	
3. Save the calculated cost of the fare so that it can be viewed later can view later. 

Note you do not have to use any databases for this task and all information can be stored in memory.
