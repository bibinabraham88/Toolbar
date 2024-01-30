@Edge
Feature: Edge_Login
		Test to check if user can successfully login to Toolbar in Edge browser


Background: 
	Given I try to open the 'Edge' browser
	When I try to open the toolbar extesion in 'Edge'
	When I click on join button
	When I login to the TCB Website
	When I try to open the toolbar extesion in 'Edge'

Scenario: As a user I should see the toolbar pop up when I try to access it in Edge
	Then I should see the logged in toolbar


