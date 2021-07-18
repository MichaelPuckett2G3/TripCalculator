using Specky.Attributes;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Dal;
using TripCalculator.Models;

namespace TripCalculator.ViewModels
{
    [Speck]
    public sealed class ManageStudentsViewModel
    {
        private readonly ITripDb tripDb;
        private readonly IList<Student> students;

        public ManageStudentsViewModel(ITripDb tripDb)
        {
            this.tripDb = tripDb;
            students = tripDb.Students.ToList();
        }
        public IEnumerable<Student> Students => students;

        public void AddStudent(Student student)
        {
            student.Id = tripDb.Students.Count + 1;
            students.Add(student);
        }

        public void CommitChanges()
        {
            foreach (var student in Students) tripDb.Students.Add(student);
        }

        public void RemoveAllStudents()
        {
            tripDb.Students.Clear();
            students.Clear();
        }
    }
}
