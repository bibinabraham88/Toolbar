
Feature: TCBToolbarExtension
		Test to check if toolbar opens up as expected


@mytag 
Scenario:  As a user I should able to instrall toolbar extension 

	Given I try to open the toolbar extesion
	When I click on join button 
	Then I click on Accept cookies
	When I fills-in mailbox field with new user "tcbtestteam+0312@topcashback.co.uk "
	And I fills-in password field with new user "Yadda123!"
	And I click on join free button new user
	Then I should see sucssesfully install extension
	
	
