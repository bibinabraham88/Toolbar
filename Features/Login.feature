
@mytag 

Feature: Login with existing member 
		


Background: 
   
 01  login with existing member 

	Given I try to open the toolbar extesion
	When I click on join button
	Then I click on Accept cookies
	When  I fills-in mailbox field with "tcbtestteam@topcashback.co.uk"
	And I fills-in password field with "Yadda123!"
	And I click on join free button
	Then I should see sucssesfully install extension
 
	
	
Scenario: 01_ click on Tell a friend

       Given I try to open the toolbar extesion	  
	   Then I click on Tell a friend 


 Scenario: 02_ click on My account 
  
        Given I try to open the toolbar extesion
	    Then I click on My account   
		

Scenario: 03_ search any mearchant on toolbar 

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


Scenario: 04_ click on recently visited  

         Given I try to open the toolbar extesion 
		 Then I able to click on recently visited 
		 

Scenario: 05_ search mearchant on google 
  
           Given I open chrome browser 
		   And I click on Accepte all cookies button 
		   And I search on google mearchnt <SearchTerm> 
           When I click on google search button
		   Then I shuld see topcashback tax with %
		  # And I click on merchant link
		 #  And I click on active cashback on popup
		    
Examples:
| SearchTerm |
| Nike       |
| currys     |
| Argos      |
| asos       |


Scenario: 06_ see suggestion merchnat 
 
             When I should see sucssesfully install extension   
	    	 And I should able to click on suggestion merchant 
	    	 # Need to check in BO how many suggestion merchant have If >=7 should see 4 and if 8=< should see 8


Scenario: 07_ click on carousel 
 
             Given I try to open the toolbar extesion 		  
		   	 Then I should able to see on carousel image 
			 # Need to check in BO how many carousel we have and also we can add new one 

 Scenario: 08_ FAQ on browser extention 

              Given I should see sucssesfully install extension
		      Then I should able to click on FAQlink page 


Scenario: 09_ cick 0n Offer link 

               Given I should see sucssesfully install extension
		       And I should able to click on offer link 
		       Then I should able to see offer page 


Scenario: 10_ logout toolbar account 

             Given I should see sucssesfully install extension
			 And I click on account 
			 And I click on sign out 
			 Then I should able to see logout page 


Scenario: 11_ see best deal 

          Given I try to open the toolbar extesion
		  # Need to add mercant in BO and check  
		  Then I should able to see best deal 

Scenario: 12_ Fingerpring track

          When I should see sucssesfully install extension
		  Then I should able to track Url 


#Scenario: 13_Autocoupon apply 
#
#           Given I open chrome browser 
#		   And I click on Accepte all cookies button 
#		   And I search on google mearchnt <SearchTerm> 
#           And I click on merchant link          
#
#Examples:
#| SearchTerm |
#| Nike       |

Scenario: 14_able to see green popup 

           Given I open chrome browser 
		   And I click on Accepte all cookies button 
		   And I search on google mearchnt <SearchTerm> 
           When I click on google search button
		   And I click on merchant link
		   And I should able to click and see white popup 
		   
Examples:
| SearchTerm |
| Nike       |
| currys     |
| Argos      |
| asos       |
