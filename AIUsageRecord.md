# AI-Assisted Engineering Usage Record

## 1. Purpose

AI tools were used as engineering assistants during the development of the Course Registration application.

The generated suggestions were reviewed and adapted before implementation.

## 2. AI Activities

### Activity 1: Understanding Requirements

Prompt:
"Help me break down the course registration assignment into models, services, APIs, and testing requirements."

AI Contribution:
Suggested a modular implementation covering enrollment, dropping, waitlist management, and automated testing.

Decision:
Accepted the suggested task decomposition.

Verification:
Compared the implementation plan against the assignment acceptance criteria.

### Activity 2: Service Implementation

Prompt:
"Help me implement enrollment, drop, duplicate validation, prerequisite validation, and FIFO waitlist promotion in C#."

AI Contribution:
Suggested an EnrollmentService implementation using in-memory collections and synchronization.

Decision:
Used the suggested implementation as a starting point and reviewed the business rules.

Verification:
Tested enrollment, dropping, and automatic waitlist promotion.

### Activity 3: Automated Testing

Prompt:
"Help me write xUnit test cases for course enrollment, duplicate requests, prerequisite failure, and FIFO promotion."

AI Contribution:
Suggested unit test scenarios using Arrange, Act, and Assert.

Decision:
Adapted the test cases to the project's models and service methods.

Verification:
Executed the tests using Visual Studio Test Explorer.

## 3. Independent Review

The following areas were reviewed:

- Course capacity validation.
- Duplicate enrollment handling.
- Prerequisite validation.
- FIFO waitlist promotion.
- Invalid drop handling.
- Unit test results.

## 4. Conclusion

AI was used to support requirement understanding, code development, and test case preparation.

The generated suggestions were reviewed and verified through code inspection, API testing, and automated tests.