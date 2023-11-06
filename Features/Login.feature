
@mytag 

Feature: Login with existing member 
		


Background: 
   
 01  As a user I should able to login with existing member 

	Given I try to open the toolbar extesion
	When I click on join button
	Then I click on Accept cookies
	When  I fills-in mailbox field with "tcbtestteam@topcashback.co.uk  "
	And I fills-in password field with "Yadda123!"
	And I click on join free button
	Then I should see sucssesfully install extension
 
	
	
Scenario: 01_As a user I should able to click on Tell a friend

       Given I try to open the toolbar extesion	  
	   Then I click on Tell a friend 


 Scenario: 02_As a user I should able to click on My account 
  
        Given I try to open the toolbar extesion
	    Then I click on My account   
		

Scenario: 03_As user I should able to search any mearchant on toolbar 

         Given I try to open the toolbar extesion
		 And I search mearchnt <SearchTerm> 
		 Then I should see search result 
		# And I click on nike mearchnat 
Examples:
| SearchTerm |
| Boots      |
| currys     |
| ebay       |
| asos       |
| Argos      |


Scenario: 04_As a user I should able to click on recently visited  

         Given I try to open the toolbar extesion 
		 Then I able to click on recently visited 
		 

Scenario: 05_As a user I should able to search mearchant on google 
  
           Given I open chrome browser 
		   And I click on Accepte all cookies button 
		   And I search on google mearchnt <SearchTerm> 
           When I click on google search button 
		  Then I shuld see topcashback tax with % 
Examples:
| SearchTerm |
| Nike       |
| currys     |
| Argos      |
| asos       |


Scenario: 06_As user I should able to click and see suggestion merchnat 
 
             When I should see sucssesfully install extension  
	    	 # Need to check in BO how many suggestion merchant have If >=7 should see 4 and if 8=< should see 8 
	    	 And I should able to click on suggestion merchant 


Scenario: 07_As user I should able to see and click on carousel 
 
              Given I try to open the toolbar extesion 
		   	 Then I should able to click on carousel image 

 Scenario: 08_As user I should able to click on FAQ on browser extention 

              Given I should see sucssesfully install extension
		      Then I should able to click on FAQlink page 

Scenario: 09_As user I should able to cick 0n Offer link 

               Given I should see sucssesfully install extension
		       And I should able to click on offer link 
		       Then I should able to see offer page 

Scenario: 10_As user I should able logout toolbar account 

             Given I should see sucssesfully install extension
			 And I click on account 
			 And I click on sign out 
			 Then I should able to see logout page 
			 
			 