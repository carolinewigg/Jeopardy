# Jeopardy
My recreation of Jeopardy. I tried finding other Jeopardy knockoffs to just practice questions, but I didn't really like any of them. I found a compiled JSON file of Jeopardy Questions on Reddit, and decided to use it to make this game.

## FileToDbQuestionInserter
Accepts a JSON file with an array of jobjects in the following format:
```json
{
  "category": "HISTORY", 
  "air_date": "2004-12-31", 
  "question": "'For the last 8 years of his life, Galileo was under house arrest for espousing this man's theory'", 
  "value": "$200", 
  "answer": "Copernicus", 
  "round": "Jeopardy!", 
  "show_number": "4680"
}
```
Then it adds the categories, rounds, and questions to their own respective database tables.

## Jeopardy
Presentation layer created using ReactJS.

## JeopardyApi
Interface for the Jeopardy Service using the Refit library.

## JeopardyService
Service to retreive the game data from the database.
