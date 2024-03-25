# Guard-Clauses
A set of simple guard classes inspired by the approach take bu Steve Smith (Ardalis).  

The usege of these is intended to be very simple and expressive. There are 2 main ways to use 
these methods, with and without a custom message.

 - Guard.Against.Null(someObjectName);
	- This throw an error that included the name of the parameter passed in. 

 - Guard.Against.Null(someObjectName, "This is a special message I want included in the Argumentexception that is thrown.")
	- This will use the message you set in the exception that is thrown.

