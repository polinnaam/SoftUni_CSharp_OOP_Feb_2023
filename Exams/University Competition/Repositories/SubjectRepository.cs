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
    public class SubjectRepository : IRepository<ISubject>
    {
        public SubjectRepository ()
        {
            models = new List<ISubject>();
        }
        private List<ISubject> models;
        public IReadOnlyCollection<ISubject> Models
        { 
        get { return models.AsReadOnly(); }
        }

        public void AddModel(ISubject model)
        {
            ISubject subject = null;
            if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(models.Count + 1, model.Name);
            }
            else if (model is TechnicalSubject)
            {
                subject = new TechnicalSubject(models.Count + 1, model.Name);
            }
            else if (model is HumanitySubject)
            {
                subject = new HumanitySubject(models.Count + 1, model.Name);
            }
            models.Add(subject);
        }

        public ISubject FindById(int id)
        {
            return models.Where(s => s.Id == id).FirstOrDefault();
        }

        public ISubject FindByName(string name)
        {
            return models.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
