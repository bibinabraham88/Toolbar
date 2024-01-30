@chrome
Feature: Chrome_Login
	Test to check if user can successfully login to Toolbar in Chrome browser

Background: 
	Given I try to open the browser
	When I try to open the toolbar extesion
	When I click on join button
	When I login to the TCB Website
	When I try to open the toolbar extesion

Scenario: As a user I should see the toolbar pop up when I try to access it in Chrome
	Then I should see the logged in toolbar

Scenario: As I user I should be able to search for merchants
    When I enter a merchant name 'Nike'
    Then I should see the suggested list

Scenario: As a user I should be able to click on My account and redirected to corect page
    When I click on 'My Account'
    Then I should be redirected to correct page

Scenario: As a user I should be able to click on Tell a friend and redirected to correct page
    When I click on 'Tell a friend'
    Then I should be redirected to correct page
