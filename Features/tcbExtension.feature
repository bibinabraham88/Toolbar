@mytag 
Feature: TCBToolbarExtension
		Test to check if toolbar opens up as expected

Background: 
As a user I should able to instrall toolbar extension 

	Given I try to open the toolbar extesion
	When I click on join button
	Then I click on Accept cookies
	When  I fills-in mailbox field with "  "
	And I fills-in password field with "Yadda123!"
	And I click on join free button
	Then I should see sucssesfully install extension
	
	
Scenario: 01_As a user I should able to click on Tell a friend

       And I try to open again toolbar extesion
	   Then I click on Tell a friend 

 Scenario: 02_As a user I should able to click on My account 
  
        And I try to open again toolbar extesion
	    Then I click on My account      

Scenario: 03_As user I should able to search any mearchant 

         And I try to open again toolbar extesion
		 Then I try to serach mearchant "nike"
		 And I click on nike mearchnat 

Scenario: 04_As a user I should able to click on recently visited  

         Given I try to open the toolbar extesion 
		 Then I able to click on recently visited  