# Course Registration – Design Specification

## 1. Project Overview

The Course Registration application provides enrollment, dropping, and FIFO waitlist promotion functionality for a single course offering.

The application is developed using ASP.NET Core Web API and C#.

The main objective is to ensure that students can enroll only when seats are available and satisfy the prerequisite requirements.

## 2. Technology Stack

- Programming Language: C#
- Framework: .NET 8
- Backend: ASP.NET Core Web API
- Testing: xUnit
- Data Storage: In-memory collections
- API Testing: Swagger

## 3. Application Architecture

The application follows a simple layered architecture.

### Models
- Course: Stores course information and capacity.
- Student: Stores student information and prerequisite eligibility.
- Enrollment: Stores enrolled student information.
- WaitlistEntry: Stores students waiting for available seats.

### Services
EnrollmentService contains the core business logic:
- EnrollStudent()
- DropStudent()
- PromoteWaitlistedStudent()

### Controllers
EnrollmentController exposes HTTP endpoints and communicates with EnrollmentService.

## 4. API Design

| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Enrollment/enroll/{studentId} | Enroll or add student to waitlist |
| DELETE | /api/Enrollment/drop/{studentId} | Drop an enrolled student |
| GET | /api/Enrollment/status | Get enrollment and waitlist details |

## 5. Business Rules

1. A student can enroll only once in a course.
2. A student must complete the prerequisite before enrollment.
3. If seats are available, enrollment is successful.
4. If the course is full, eligible students are added to the waitlist.
5. When an enrolled student drops, the earliest eligible waitlisted student is promoted.
6. Ineligible students at the front of the waitlist are skipped and removed.
7. Duplicate enrollment and invalid drop requests are rejected.

## 6. Enrollment Workflow

When a student requests enrollment:

1. Validate whether the student exists.
2. Check prerequisite completion.
3. Check whether the student is already enrolled or waitlisted.
4. Check available course capacity.
5. Enroll the student if a seat is available.
6. Otherwise, add the student to the waitlist.

## 7. Drop and Promotion Workflow

When a student drops a course:

1. Check whether the student is enrolled.
2. Remove the enrollment record.
3. Check the waitlist in FIFO order.
4. Skip and remove ineligible students.
5. Promote the first eligible student.
6. Stop after one successful promotion.

## 8. Concurrency Handling

The service uses the C# lock statement to synchronize enrollment and drop operations within the same service instance.

This prevents multiple threads from modifying the in-memory enrollment and waitlist collections simultaneously.

## 9. Persistence Approach

The implementation uses in-memory collections such as List<T> to store course, student, enrollment, and waitlist information.

This approach keeps the implementation simple and avoids introducing an unnecessary database for the scoped assignment.

Data is not persisted after application restart.

## 10. Assumptions and Trade-offs

- Only one course offering is supported.
- Student information is preloaded.
- Prerequisite eligibility is represented using a Boolean property.
- Ineligible waitlisted students are skipped and removed.
- FIFO ordering is maintained through insertion order in the waitlist.
- The implementation is intended as a bounded service prototype rather than a complete registration platform.