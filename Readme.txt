Readme file
Author: José Hernán Valdés Murguía
Project: Drone Delivery Service

Description:
The Drone Delivery Service is a POC project to demonstrate general development skills. It was developed using Visual Studio 2022 and .Net Framework 5.0. It consists of two projects: DroneDeliveryService and DroneDeliveryServiceTest.

 - DroneDeliveryService: Contains the needed classes to collect the input data from different sources, discover the trips each drone will do, and print the trips in console. The main classes are the following:
    * DeliveryInputReader and its implementations: ConsoleInputReader, FileInputReader
    * DeliveryEngine, which handles the trip discovery.
	* The Utility classes: Drone, Location, Trip,
	* TripPublisher, that prints the trips in different formats.
 
 -  DroneDeliveryServiceTest: contains the Test classes needed to validate the behavior of the DroneDeliveryService. This library was created following the TDD process.
 
Algorithm Description:
The DeliveryInputReader collects the Drones and Locations lists, and the DeliveryEngine reads those inputs and process the trips as follows:

1. To order the Drones and locations by weight so that the drones with more capacity and the locations that require more weight will be handled first.

2. For each drone, a trip is created and the locations that fit in that trip are loaded. This process is repeated in a WHILE loop until all the locations are loaded or none of the drones could load a location or the maximum number of tries is reached. The two last conditions are added to avoid deadlocks or unnecessary loops.
3. If there is any location that could not be added to a trip, an exception is thrown. For instance a location with a weight higher than any of the drones maximum weight triggers this exception.
4. The DeliveryEngine will return a list of trips done by each drone to the selected locations.
5. The list of Trips is then printed in the console using the TripPublisher class. 

Valid Input Examples:

Example 1 : 
> Drone_A, 6, Drone_B, 10
Number of locations > 3
> Loc_1, 5
> Loc_2, 9
> Loc_3, 1


Example 2 : 
> Drone_A, 6, Drone_B, 10, Drone_C, 6, Drone_D, 2
Number of locations > 4
> Loc_1, 3
> Loc_2, 9
> Loc_3, 2
> Loc_4, 6

Restrictions: The Max location weight should be equals of less than the Max drone weight. The Application will throw if that rule is broken.

TODO's
Define and improve what to do if a location has a weight higher than the max drone weight.
  
HOW TO RUN THIS APP.
1. Download the code in the github repository : https://github.com/josehvaldes/DroneDeliveryService.git
2. Compile and run the DroneDeliveryService project
3. Follow the instruction in the application console. 
Example:
> Drone_A, 6, Drone_B, 10, Drone_C, 6, Drone_D, 2
Enter the total number of locations: 2
Location 1 : Loc_1, 5
Location 2 : Loc_2, 9

