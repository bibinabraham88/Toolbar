Feature: TCBToolbarExtension
		Test to check if toolbar opens up as expected

@mytag
Scenario: As a user I should see the toolbar pop up when I try to access it
	Given I try to open the toolbar extesion
	When I click on join button
	Then I click on Accept cookies
	When  I fills-in mailbox field with "  "
	And I fills-in password field with "Yadda123!"
	And I click on join free button
	Then I should see sucssesfully install extension
	#And I try to open again toolbar extesion
	#Then I click on Tell a friend 

	
Scenario: 01_As a user I should able to click on Tell a friend

         And I try to open again toolbar extesion
		 Then I click on Tell a friend 

 Scenario: 02_As a user I should able to click on My account 
  
         And I try to open again toolbar extesion
		 Then I click on My account      