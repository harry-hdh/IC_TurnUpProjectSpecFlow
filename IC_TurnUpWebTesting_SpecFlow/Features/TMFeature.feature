Feature: TMFeature

A Summary of TM page feature

Background: 
	Given I logged into TurnUp portal successfully
	And I navigate to Time and Material page

@regression
Scenario: Create time record with valid data
	When I create a time record
	Then the time record should be created successfully

Scenario Outline: Edit existing time record with valid data
	When I update the '<Code>', '<Description>' and '<Price>' on an existing Time records
	Then the time record should be updated successfully with '<Code>', '<Description>' and '<Price>'

	Examples: 
		| Code | Description | Price |
		| 101  | testing1    | 99    |
		| 102  | testing2    | 19    |
		| 103  | testing3    | 100   |

Scenario: Delete Time/Material record
And I delete and existing Time/Metrial record
Then the record should be deleted sucessfully