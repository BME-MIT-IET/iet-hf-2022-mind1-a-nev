Feature: RDFGraphFromFile
	Create RDFGraph from file

Scenario: Create graph from a valid file
	Given an RDF graph in the file "valid.rdf"
	When create a graph from the file
	Then the graph sould be succesfully created

Scenario: Create graph from a file without closing tag
	Given an RDF graph in the file "withoutClosingTag.rdf"
	When create a graph from the file
	Then the program should throw an Exception, because of invalid file

Scenario: Create graph from a file without rdf:RDF tag
	Given an RDF graph in the file "withoutRDFtag.rdf"
	When create a graph from the file
	Then the program should throw an Exception, because of invalid file