using Structure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace Structure.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            models = new List<IStudent>();
        }
        private List<IStudent> models;
        public IReadOnlyCollection<IStudent> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IStudent model)
        {
            IStudent student = new Student(models.Count + 1, model.FirstName, model.LastName);

            models.Add(student);
        }

        public IStudent FindById(int id)
        {
            return models.Where(s => s.Id == id).FirstOrDefault();
        }

        public IStudent FindByName(string name)
        {
            string[] splitted = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splitted[0];
            string lastName = splitted[1];
            return models.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();
        }
    }
}
