# Vehicle_Rental_System


--INTERFACES--

IOverlappable

IOverlappable is an interface that acts as a contract with the Schedule class. The interface includes one method: Overlaps(Schedule). Schedule implements the method defined in IOverlappable, defining the relationship between them as an Implementation.

IRentalVehicleCustomer

IRentalVehicleCustomer is an interface that acts as a contract with the WestminsterRentalVehicle class. This interface includes two methods: listAvailableVehicles(Schedule, VehicleType) and rentVehicle(string, Schedule). WestminsterRentalVehicle implements both of these methods, defining the relationship between them as an Implementation.

IRentalVehicleManager

IRentalVehicleManager is an interface that acts as a contract with the WestminsterRentalVehicle class. This interface includes five methods: addVehicle(Vehicle), deleteVehicle(string), listVehicles(), listVehiclesOrdered(), and generateReport(). WestminsterRentalVehicle implements all of these methods, defining the relationship between them as an Implementation.

IComparable

IComparable is an interface that acts as a contract with the Vehicle class. The Vehicle class overrides one of IComparable’s interfaces: CompareTo(Vehicle). As Vehicle implements this method, the relationship between them is an Implementation


--CLASSES--

Schedule

Schedule is a public class that implements the IOverlappable interface. Schedule uses IOverlappable to create the Overlap() method that tests whether two schedules overlap. Schedule has two DateTime attributes, one for the time of pickup date (pickUp) and one for the drop-off date (dropOff). The class takes two strings as inputs that are converted to the pickUp and dropOff attributes.

Schedule is related to the Vehicle class via an “Association”: each Vehicle (1) has zero-to-many (0..*) Schedules. Schedule also has an Association relationship with the WestminsterRentalVehicle class: each WestminsterRentalVehicle (1) records zero-to-many (0..*) different Schedules. The relationship between Schedule and IOverlappable is an “Implementation”, a type of Association: the abstract methods defined in IOverlappable are overridden by the Schedule class.

Vehicle

Vehicle is a public class that implements the IComparable<Vehicle> interface. Vehicle uses the IComparable interface in order to create the CompareTo() method that compares the make of two Vehicles and allows the listVehiclesOrdered() method in the WestminsterRentalVehicle to list Vehicles alphabetically. A vehicle is defined by three string inputs which are the make, model, and registration number of the vehicle being defined. The Vehicle class also includes a List<Schedule>, a list that keeps record of all of the booked schedules for a Vehicle.

Vehicle is the superclass of four subclasses: Cars, Vans, Motorbikes, and ElectricCars. This relationship between Vehicle and the four classes is a “Generalisation”, as each subclass “is-a-kind- of” Vehicle. These subclasses inherit all methods from Vehicle, and override the virtual method display() defined in Vehicle. Vehicle’s relationship with Schedule is an “Association”, as earlier stated. Vehicle also has an Association with the WestminsterRentalVehicle class: each WestminsterRentalVehicle (1) instance has zero-to-many (0..*) Vehicles associated with it. Vehicle also Implements the interface IComparable. Specifically, it overrides the CompareTo() method defined in IComparable. 

Cars, Vans, ElectricCars, & Motorbikes 

Each of the four classes Cars, Vans, ElectricCars, & Motorbikes is a subclass of the class Vehicles, as previously described. The difference between each type of subclass is the each has a string attribute “type” defined. The “type” defined in Cars is “Car”, in Vans it’s “Van”, in Motorbikes it’s “Motorbike”, and in ElectricCars it’s “Electric Car.” 

Each of these four classes “is-a-kind-of” Vehicle, a Generalisation relationship, and they each inherit every method defined in the class Vehicle. Each class also overrides the virtual display() method. They each have a one-to-one “Composition” relationship with the class VehicleType, as each of these classes has a single Type defined and Type cannot exist on its own.

VehicleType

VehicleType is a public class that has a single attribute that is a Type. VehicleType has a one-to- one “Composition” relationship with each of the four Vehicle subclasses: Cars, Vans, Motorbikes, and ElectricCars as previously described.

WestminsterRentalVehicle

WestminsterRentalVehicle is a public class that implements the IRentalVehicleCustomer and the IRentalVehicleManager interfaces. These interfaces act as contracts that the class must abide by, implementing all methods defined in both of these interfaces. It also has a List<Vehicle> that holds a list of all of the Vehicles and their attributes that have been added to the class.

WestminsterRentalVehicle has a one-to-many Association relationship with Vehicle as previously described, as each (1) WestminsterRentalVehicle has zero-to-many (0..*) Vehicles associated with it. WestminsterRentalVehicle also had an Association relationship with Schedule, where each WestminsterRentalVehicle (1) keeps record of zero-to-many (0..*) Schedules.

WestminsterRentalVehicle also Implements the interfaces IRentalVehicleCustomer and IRentalVehicleManager as stated above.
