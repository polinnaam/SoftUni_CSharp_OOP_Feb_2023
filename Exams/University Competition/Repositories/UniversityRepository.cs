using Structure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace Structure.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }
        private List<IUniversity> models;
        public IReadOnlyCollection<IUniversity> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IUniversity model)
        {
            IUniversity university = new University(models.Count + 1, model.Name, model.Category, model.Capacity, model.RequiredSubjects.ToList());
            
            models.Add(university);
        }

        public IUniversity FindById(int id)
        {
            return models.Where(s => s.Id == id).FirstOrDefault();
        }

        public IUniversity FindByName(string name)
        {
            return models.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
