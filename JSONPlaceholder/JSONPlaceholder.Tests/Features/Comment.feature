@Comments
Feature: Comments
	In order to view comments
	As a user
	I want to be able to see comments that relate to a post
	

@Comments
Scenario: Number of comments returned
	Given I have created a comments search request with the post number 1
	When I call the API
	Then there should be 5 comments returned
	

@Comments
Scenario Outline: Name of the comment
	Given I have created a comments search request with the post number 1
	When I call the API
	Then the name of the '<commentNumber>' comment should be '<name>'

Examples:
|commentNumber  |name                           |
|0              |id labore ex et quam laborum   |
|3              |alias odio sit                 |
	

@Comments
Scenario Outline: Email address of the comment
	Given I have created a comments search request with the post number 1
	When I call the API
	Then the email address of the '<commentNumber>' comment should be '<email>'

Examples:
|commentNumber  |email              |
|0              |Eliseo@gardner.biz |
|4              |Hayden@althea.biz  |
	
@Comments
Scenario Outline: Body of the comment
	Given I have created a comments search request with the post number 5
	When I call the API
	Then the body of the '<commentNumber>' comment should contain '<body>'

Examples:
|commentNumber  |body                           |   
|0              |commodi odio ratione nesciunt  |
|4              |et non ex                      |

	
@Comments
Scenario: Post ID of the comment
	Given I have created a comments search request with the post number 1
	When I call the API
	Then the postid of the 3 comment should be 1
	
@Comments
Scenario: Invalid comment number, too low
	Given I have created a comments search request with the post number 0
	When I call the API
	Then the response should be empty


@Comments
Scenario: Invalid comment number, too high
	Given I have created a comments search request with the post number 10000000
	When I call the API
	Then the response should be empty

@Comments
Scenario: Invalid comment number, text
	Given I have created a comments search request with text as the post number
	When I call the API
	Then the response should be empty