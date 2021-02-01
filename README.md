# InfoTrack.SEO

This solution intend to demonstrate How a .NEt core  API is constructed adhiring to modern design principals and how a client app(React) can utilize the API. It demonstrate layered application architecture with DDD best practices. Implements NLayer Hexagonal architecture(Core, application, Infra, API layers) and Domain Driven Design. The solution follows clean architecture with SOLID principals. Below are the main components of the solution

### Project Structure
  - **InfoTrack.SEO.Core**: Entities, Interfaces, Exceptions
  - **InfoTrack.SEO.Infrastructure**: Logging, Data, Exceptions
  - **InfoTrack.SEO.Application**: Interfaces, Services, Dtos
  - **InfoTrack.SEO.API**:  Services, Mappers

# Note
 - Some test cases are ommited deliberately to finish the solution
 - React client is made simple due to time limitation
