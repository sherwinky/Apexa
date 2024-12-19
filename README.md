# Apexa Project
## ApexaSolution:Asp.net core api solution
- Apexa.Data: dto projects, contains DTOs difination
- Apexa.IDAL, the interface of dal
-Apexa.DAL, the implentaiton of Apexa.IDAL, AdvisorContext also implenmented in this projects
- Apexa.IService, service interface
- Apexa.Service, implentation of IService
- UnitTest,UnitTest project
- APexa, API project
### implenmented function:
- Creation, Update, Delete, Read, Search advisor
- server side validation
### Todo: 
- currently only implenmented in-memory dal, in the future, can be easily switch to other db provider: sql server, oracle, etc.
- authorization and autentication
- use async/await in time comsuming function call
## Apexa.App AngularUI project
- In current implentation, only implented the search function and delete function
### Project structure:
- Components: UI Components
- advisor-list: advisor list Components, show the list of advisor, implented function: serch advisor by name, delete advisor
- models: models difination
- services: services difination
- environments: environment's setting of the project, the api's url can be setup here
### todo: 
- modify advisor
- add new advisor, client side validation
            
