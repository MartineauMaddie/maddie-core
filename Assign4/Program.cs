// A friend of yours is starting a personal training business and wants to take on personal clients. As part of their business operations, they need a simple system to help them store and track information about their clients. As a pilot, you've agreed to help them by creating a simple console application that will allow them to enter their client details and display the BMI scores and status for their clients. As time goes on, additional functionality can be added to the application.
// Requirements

// The program build will be developed in two parts:
// Part A – Class and Object Implementation

// Client Class

// Design a class named Client that meets the following requirements:

//     A string field to store the client's first name and a corresponding property FirstName with both get and set
//         The first name cannot be empty, null, or whitespace; ensure that the stored value is trimmed of leading and trailing whitespace
//     A string field to store the client's last name and a corresponding property LastName with both get and set
//         The last name cannot be empty, null, or whitespace; ensure that the stored value is trimmed of leading and trailing whitespace
//     An int field to store the client's weight in pounds and a corresponding property Weight with both get and set
//         The weight must be greater than zero
//     An int field to store the client's height in inches and a corresponding property Height with both get and set
//         The weight must be greater than zero
//     A greedy constructor that requires the first name, last name, weight, and height as parameters
//         Use the properties in the constructor for setting the fields to take advantage of any validation checks already coded
//     A read-only property named BmiScore that will return as a double the BMI score for the client
//     A read-only property named BmiStatus that will return as a string the BMI status for the corresponding BMI score
//     A read-only property named FullName that will return as a string the client's full name in the format Lastname, FirstName

// Additional Information

// The formula to calculate a client's weight follows:

// Formula: weight / height2 x 703

// Where height is in inches and weight is in pounds.

// The status for corresponding BMI values are as follows:
// BMI Score 	Status
// <= 18.4 	Underweight
// 18.5 - 24.9 	Normal
// 25.0 - 39.9 	Overweight
// >= 40 	Obese

// Write a program to test your Client class as shown in the sample run below. The program must, at a minimum, demonstrate the following:

// a. prompt for a string b. prompt for an int c. create an instance of Client d. display the status or score, depending on user request, along with full client name e. have user friendly error handling (i.e. the program must not crash)