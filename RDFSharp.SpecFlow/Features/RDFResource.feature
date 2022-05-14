Feature: RDFResource
	Create RDFResource object

Scenario: Create blank resource
	When create resource without parameters
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"
	
Scenario: Create blank resource with input "bnode:xxsdsdsdxx"
	When create resource with parameter "bnode:xxsdsdsdxx"
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"

Scenario: Create blank resource with input "bnode:"
	When create resource with parameter "bnode:"
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"

Scenario: Create blank resource with input "bnODe:"
	When create resource with parameter "bnODe:"
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"

Scenario: Create blank resource with input "_:"
	When create resource with parameter "_:"
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"

Scenario: Create blank resource with input "_:xxsdsdsdxx"
	When create resource with parameter "_:xxsdsdsdxx"
	Then the resource sould not be null
	And the resource should be blank
	And the resources URI should be start with "bnode:"

Scenario: Create resource with input "http://iet/test#xx"
	When create resource with parameter "http://iet/test#xx"
	Then the resource sould not be null
	And the resource should not be blank
	And the resources URI should be "http://iet/test#xx"

Scenario: Create resource with input "urn:iet:test"
	When create resource with parameter "urn:iet:test"
	Then the resource sould not be null
	And the resource should not be blank
	And the resources URI should be "urn:iet:test"

Scenario: Create resource with invalid input "iet"
	When create resource with parameter "iet"
	Then the program sould throw RDFModelException

Scenario: Create resource with invalid input ""
	When create resource with parameter ""
	Then the program sould throw RDFModelException
	
Scenario: Create resource with invalid input "http:/iet#"
	When create resource with parameter "http:/iet#"
	Then the program sould throw RDFModelException

Scenario: Create resource with invalid input "http:/ "
	When create resource with parameter "http:/ "
	Then the program sould throw RDFModelException

Scenario: Create resource with invalid input "http:// iet/test#xx"
	When create resource with parameter "http:// iet/test#xx"
	Then the program sould throw RDFModelException

Scenario: Create resource with invalid input "http://iet\0"
	When create resource with parameter "http://iet\0"
	Then the program sould throw RDFModelException