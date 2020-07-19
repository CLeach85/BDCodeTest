# JSON Placeholder Tests

## Scope
The following 2 API resources are under test
- GET /posts/1
- GET /posts/1/comments

## Out of Scope
### Route
GET /comments?postId=1

### Resources
- GET /comments/1
- GET /albums/1
- GET /photos/1
- GET /users/1
- GET /todos/1

### Non Functional
- Connection method, http/https
- Performance & Load

## Assumptions
Comment email address is validated when inputting into the API, checking this is a valid email address is not included in testing here.
We will only be returning comments when searching via a post, therefore invividual comment (GET /comments/1) testing has been excluded in this case.

## Recommendations
When searching for a post that doesn't exist or has an invalid search term this should be indicated in the response. This could be via a message in the response or via the status code in the header. This will help prevent  NullPointerException when trying to work with an empty json object and would also be useful to distinguish between invalid requests and trying to find items which do not exist.
Add a class name to the JSON response on results that return more than one result. This would make deserialization much easier without having to manually put the items into a list when deserializing. E.g Add {"Comments":[ to the start of the JSON response.
