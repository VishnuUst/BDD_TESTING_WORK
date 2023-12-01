Feature: Login
User login with valid credentials (username,password)
Home page will load after successful login
Background: 
	Given User will be on the login page

@positive
Scenario: Login with Valid Credentials
	When User will enter username
	And User will enter password
	And User will click on login button
	Then User will redirect to Homepage
@negative
Scenario: Login with InValid Credentials
	When User will enter username
	And User will enter password
	And User will click on login button
	Then Error message for password length should be throw
@regression
Scenario: Check for password Hidden Display
	When User will enter password
	And User will click on Show link in the password textbox
	Then the password characters should be shown
@regression
Scenario: Check for password Show Display
	When User will enter password
	And User will click on Show link in the password textbox
	And User will click on Hide link in the password textbox
	Then the password characters should go back to *