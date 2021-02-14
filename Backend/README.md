# Perfect Channel - Technical Test

## How long did you spend on your solution?

It took me a bit more that 5 hours for implementing the current state. I am not sure about the exact timing as I did some breaks for lunch, shopping etc.

## How do you build and run your solution?

### Backend

To run the Backend, you will use the default commands for a .Net Core app.

### Frontend

The frontend is implemented in the `frontend-vue` folder. It is a Vue 2 application implemented with JavaScript. In order to run the app you will need to:

* Install the Vue CLI: https://cli.vuejs.org/guide/installation.html
* Navigate to the `frontend-vue` folder
* Run `npm install`
* Run `npm run serve`

To run the `Mocha` `Chai` tests implemented for the Vue app, you will need to run `npm run test`.

## What technical and functional assumptions did you make when implementing your solution?

* I have assumed the Todos should be persisted. Therefore, I have implemented an SQLServer code-firs DB with Entity Framework Core.

## Explain briefly your technical design and why do you think is the best approach to this problem

### Backend

The backend implementation uses an SQLServer DB which runs on SQLExpress instance. In has been created using code-first approach with EF Core.

To access the DB I have implemented a Service. This way I am separating the DB access logic from the Controller. Separation in this case would allow easy extensibility of the system.

The Controller actions implement GET (for Read), POST (for Create) and PUT (for Update) actions.

To pass data to/from remote calls, I have implemented a ViewModel class. This way the entity model, which belongs to the data layer is separated from the ViewModel with is intended to serve any remote calls.

Tests cover all controller actions, all service methods and the ToEntity() method in the ViewModel.

I have also implemented a `DBInitializer` which is a helper that allows the DB to be populated with predefined entities and to clear the DB. That utility is only for dev purposes.

### Frontend

Front end implements a Vue JavaScript app.

To access remote data, the app uses `axios`.

To keep the state of the application, I have introduced a `vuex` store.

The app has two components implemented:
* `Main` which holds the the two tables, and the create new Todo form;
* `TodoTable` which holds the actual table implementation;

Unit test are implemented with `Mocha` and `Chai`.

## If you were unable to complete any user stories, outline why and how would you have liked to implement them

I have implemented the three user stories, even if it took me a bit more time. Nevertheless, there are the following deficits (mainly in the frontend) that I would identify in the implementation:

* There is no proper error reporting in the UI. Errors are passed to the state store object, but are not displayed to the user
* The UI lacks any styling
* The tests that run on the UI are very few (in fact there is only one test on that)
* There are no integration tests for the remote calls to the backend