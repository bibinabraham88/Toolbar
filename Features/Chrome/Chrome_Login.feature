@chrome
Feature: Chrome_Login
	Test to check if user can successfully login to Toolbar in Chrome browser

Background: 
	Given I try to open the 'Chrome' browser
	When I try to open the toolbar extesion in 'Chrome'
	When I click on join button
	When I login to the TCB Website
	When I try to open the toolbar extesion in 'Chrome'

Scenario: As a user I should see the toolbar pop up when I try to access it in Chrome
	Then I should see the logged in toolbar

