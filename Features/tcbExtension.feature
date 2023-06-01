Feature: TCBToolbarExtension
		Test to check if toolbar opens up as expected

@mytag
Scenario: As a user I should see the toolbar pop up when I try to access it
	Given I open the chrome browser
	When I try to open the toolbar extesion
	Then I should see the toolbar pop up