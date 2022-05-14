Feature: RDFLimitModifier
	RDFLimitModifier is a modifier which applies an upper-bound counter to the number of query results to be considered

Scenario: Create valid RDFLimitModifier
	When create a RDFLimitModifier with a limit of 10
	Then the modifier is successfully created

Scenario: Create invalid RDFLimitModifier
	When create a RDFLimitModifier with a limit of -1
	Then the program sould throw an RDFQueryException 
