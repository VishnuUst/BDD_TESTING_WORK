Feature: GoogleSearch

To perform the search operations on google home page.

@tag1
Scenario: To perform search with Google search button
	Given Google home page should be loaded
	When Type "hp laptop" in the search text box
	And Click on the Google search button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"

Scenario: To perform search with IMFL button
	Given Google home page should be loaded
	When Type "hp laptop" in the search text box
	And Click on the IMFL button
	Then the results should be redirected to a new page with title "HP Laptops"
