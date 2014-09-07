namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class StudentService
    {
        private readonly IStudentRepository repository;
        private Regex emailCheck = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        private Regex nameCheck = new Regex(@"^[a-zA-Z]+$");
        private Regex ssnregex = new Regex(@"(^\d{3}-?\d{2}-?\d{4}$|^XXX-XX-XXXX$)");

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void InsertStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
                throw new ArgumentException();
            }

            if (student.SSN == null) 
            {
                errors.Add("Null ssn");
                throw new ArgumentNullException();
            }

            if (this.nameCheck.IsMatch(student.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(student.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if (!this.ssnregex.IsMatch(student.SSN))
            {
                errors.Add("Invalid social security number");
                throw new ArgumentException();
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student ID");
                throw new ArgumentException();
            }

            if (!this.emailCheck.IsMatch(student.Email))
            {
                errors.Add("Invalid email");
                throw new ArgumentException();
            }

            this.repository.InsertStudent(student, ref errors);
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            if (student == null)
            {
                errors.Add("Student cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(student.StudentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            if (!this.ssnregex.IsMatch(student.SSN))
            {
                errors.Add("Invalid social security number");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(student.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(student.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if (student.StudentId.Length < 5)
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            if (!this.emailCheck.IsMatch(student.Email))
            {
                errors.Add("Invalid email");
                throw new ArgumentException();
            }

            this.repository.UpdateStudent(student, ref errors);
        }

        public Student GetStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            return this.repository.GetStudentDetail(id, ref errors);
        }

        public void DeleteStudent(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            this.repository.DeleteStudent(id, ref errors);
        }

        public List<Student> GetStudentList(ref List<string> errors)
        {
            return this.repository.GetStudentList(ref errors);
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            this.repository.EnrollSchedule(studentId, scheduleId, ref errors);
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId) || scheduleId < 0)
            {
                errors.Add("Invalid student id or schedule id");
                throw new ArgumentException();
            }

            this.repository.DropEnrolledSchedule(studentId, scheduleId, ref errors);
        }

        public List<Course> GetEnrollments(string studentId, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            return this.repository.GetEnrollments(studentId, ref errors);
        }

        public float CalculateGpa(string studentId, ref List<string> errors)
        {
            var sum = 0.0f;
            if (string.IsNullOrEmpty(studentId))
            {
                errors.Add("Invalid student id");
                throw new ArgumentException();
            }

            List<string> grades = this.repository.CalculateGPA(studentId, ref errors);

            foreach (var grade in grades)
            {
                if (grade.Equals("A+") || grade.Equals("A"))
                {
                    sum += 4;
                }
                else if (grade.Equals("A-"))
                {
                    sum += 3.7f;
                }
                else if (grade.Equals("B+"))
                {
                    sum += 3.3f;
                }
                else if (grade.Equals("B"))
                {
                    sum += 3;
                }
                else if (grade.Equals("B-"))
                {
                    sum += 2.7f;
                }
                else if (grade.Equals("C+"))
                {
                    sum += 2.3f;
                }
                else if (grade.Equals("C"))
                {
                    sum += 2;
                }
                else if (grade.Equals("C-"))
                {
                    sum += 1.7f;
                }
                else if (grade.Equals("D"))
                {
                    sum += 1;
                }
                else if (grade.Equals("F"))
                {
                    sum += 0;
                }
            }

            if (grades.Count > 0)
            {
                return sum / grades.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
