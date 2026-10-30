# Limitations and Future Improvements

## Current Limitations

1. In-memory storage is used, so data is lost when the application restarts.
2. The application supports only one course offering.
3. Student details are preloaded rather than managed through a separate student API.
4. The prerequisite check uses a Boolean property.
5. The lock statement protects only operations within the same service instance and process.
6. Authentication and authorization are not implemented.
7. There is no persistent transaction management.

## Future Improvements

1. Introduce database persistence using SQL Server or PostgreSQL.
2. Support multiple course offerings.
3. Implement distributed concurrency control for multiple application instances.
4. Introduce authentication and role-based authorization.
5. Add structured logging and centralized exception handling.
6. Improve API responses using structured response models.