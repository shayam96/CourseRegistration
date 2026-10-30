
using CourseRegistration.Model;


namespace CourseRegistration.Services
{
    public class EnrollmentService
    {
        private readonly Course _course;
        private readonly List<Student> _students;
        private readonly List<Enrollment> _enrollments;
        private readonly List<WaitlistEntry> _waitlist;

        private readonly object _lock = new object();

        public EnrollmentService(Course course, List<Student> students)
        {
            _course = course;
            _students = students;

            _enrollments = new List<Enrollment>();
            _waitlist = new List<WaitlistEntry>();
        }

        public IReadOnlyList<Enrollment> Enrollments => _enrollments;
        public IReadOnlyList<WaitlistEntry> Waitlist => _waitlist;

        // 1. Enroll a student or add them to the waitlist
        public string EnrollStudent(int studentId)
        {
            lock (_lock)
            {
                var student = _students.FirstOrDefault(
                    s => s.StudentId == studentId);

                if (student == null)
                    return "Student not found.";

                if (!student.HasCompletedPrerequisite)
                    return "Prerequisite not completed.";

                bool alreadyEnrolled = _enrollments.Any(
                    e => e.StudentId == studentId);

                bool alreadyWaiting = _waitlist.Any(
                    w => w.StudentId == studentId);

                if (alreadyEnrolled || alreadyWaiting)
                    return "Student is already enrolled or waitlisted.";

                if (_enrollments.Count < _course.Capacity)
                {
                    _enrollments.Add(new Enrollment
                    {
                        StudentId = studentId,
                        CourseId = _course.CourseId,
                        EnrollmentDate = DateTime.UtcNow
                    });

                    return "Student enrolled successfully.";
                }

                _waitlist.Add(new WaitlistEntry
                {
                    StudentId = studentId,
                    CourseId = _course.CourseId,
                    CreatedAt = DateTime.UtcNow,
                    QueuePosition = _waitlist.Count + 1
                });

                return "Course is full. Student added to waitlist.";
            }
        }

        // 2. Drop an enrolled student
        public string DropStudent(int studentId)
        {
            lock (_lock)
            {
                var enrollment = _enrollments.FirstOrDefault(
                    e => e.StudentId == studentId);

                if (enrollment == null)
                    return "Student is not currently enrolled.";

                _enrollments.Remove(enrollment);

                PromoteWaitlistedStudent();

                return "Student dropped successfully.";
            }
        }

        // 3. Promote the earliest eligible waitlisted student
        private void PromoteWaitlistedStudent()
        {
            for (int i = 0; i < _waitlist.Count; i++)
            {
                var entry = _waitlist[i];

                var student = _students.FirstOrDefault(
                    s => s.StudentId == entry.StudentId);

                // Skip and remove an ineligible student
                if (student == null ||
                    !student.HasCompletedPrerequisite)
                {
                    _waitlist.RemoveAt(i);
                    i--;
                    continue;
                }

                // Promote the first eligible student
                _enrollments.Add(new Enrollment
                {
                    StudentId = student.StudentId,
                    CourseId = _course.CourseId,
                    EnrollmentDate = DateTime.UtcNow
                });

                _waitlist.RemoveAt(i);

                break;
            }
        }
    }
}
