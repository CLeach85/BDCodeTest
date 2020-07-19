@Posts
Feature: Posts
	In order to view posts
	As a user
	I want to see the posts for the requested ID
	
@Posts
Scenario: Return a single post
	Given I have created a post search request with the post number 1
	When I call the API
	Then there should be a single post returned

@Posts
Scenario: Return all posts
	Given I have created a post search request with an empty post number
	When I call the API
    Then there should be 100 posts returned
	
	
@Posts
Scenario: Title of the post
	Given I have created a post search request with the post number 1
	When I call the API
	Then the title of the post should be 'sunt aut facere repellat provident occaecati excepturi optio reprehenderit'

@Posts	
Scenario: Body of the post
	Given I have created a post search request with the post number 1
	When I call the API
	Then the body of the post should contain 'suscipit recusandae consequuntur expedita et cum'

@Posts	
Scenario: ID of the post
	Given I have created a post search request with the post number 1
	When I call the API
	Then the id of the post should be 1