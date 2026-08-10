LeafTrace (Clean Architecture)

src
│
├── LeafTrace.Domain
│   ├── Entities
│   ├── Common
│   ├── Enums
│   ├── ValueObjects
│   ├── Events
│   └── Exceptions
│
├── LeafTrace.Application
│   ├── DTOs
│   │   ├── Request
│   │   └── Response
│   ├── Interfaces
│   │   ├── Services
│   │   ├── Repositories
│   │   └── IUnitOfWork          ✅ (MISSING → ADD)
│   ├── Services
│   ├── Mappings
│   ├── Validators
│   └── DependencyInjection
│
├── LeafTrace.Persistence
│   ├── Data
│   │   ├── ApplicationDbContext  
│   │   └── Configurations
│   ├── Repositories
│   │   ├── Generic
│   │   └── Specific
│   ├── UnitOfWork
│   ├── Migrations
│   └── DependencyInjection
│
├── LeafTrace.Infrastructure
│   ├── Authentication
│   ├── Identity
│   ├── JWT
│   ├── Logging
│   ├── Email
│   ├── FileStorage
│   ├── ExternalServices
│   └── DependencyInjection
│
├── LeafTrace.API
│   ├── Controllers
│   ├── Middleware
│   ├── Filters
│   ├── Extensions
│   ├── Configurations
│   ├── Properties
│   └── Program.cs
│
└── LeafTrace.Shared
    ├── Responses
    ├── Constants
    ├── Helpers
    ├── Extensions
    └── Exceptions
