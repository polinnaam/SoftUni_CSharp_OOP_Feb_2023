using Structure.Models;
using Structure.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace Structure.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller ()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {             
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            IStudent student = new Student(0, firstName, lastName);

            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
            
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "EconomicalSubject" && subjectType != "TechnicalSubject"
                && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject currSubject = null;

            if (subjectType == "EconomicalSubject")
            {
                currSubject = new EconomicalSubject(0, subjectName);
            }
            else if (subjectType == "TechnicalSubject")
            {
                currSubject = new TechnicalSubject(0, subjectName);
            }
            else if (subjectType == "HumanitySubject")
            {
                currSubject = new HumanitySubject(0, subjectName);
            }
            subjects.AddModel(currSubject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, 
            List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> requiredSubjectsAsInt = requiredSubjects.Select(s => subjects.FindByName(s).Id).ToList();

            IUniversity university = new University(0, universityName, category, capacity, requiredSubjectsAsInt);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] splitted = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splitted[0];
            string lastName = splitted[1];

            IStudent student = students.FindByName(studentName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            
            foreach (var requiredExams in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(requiredExams))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }
            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName); ;
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            foreach (var coveredExam in student.CoveredExams)
            {
                if (coveredExam == subject.Id)
                {
                    return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, 
                        student.LastName, subject.Name);
                }
            }
            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, 
                student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            int studentsCount = 0;
            IUniversity university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            foreach (var student in students.Models)
            {
                if (student.University?.Id == universityId)
                {
                    studentsCount++;
                }                
            }
            int capacityUni = university.Capacity;
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");
            return sb.ToString().TrimEnd();
        }
    }
}
