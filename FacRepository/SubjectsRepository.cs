using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        ProjectContext db = new ProjectContext();
        public SubjectsRepository()
        {

        }

        public SubjectsRepository(ProjectContext context)
        {
            this.db = context;
        }

        public List<SubjectsDTO> GetSubjects()
        {
            Subject sub = new Subject();
            var query = db.Subjects.Select(e => new SubjectsDTO
            {
                SubjectId = e.SubjectId,
                SubjectName = e.SubjectName
            }).ToList();

            return query;
        }
        public void addSubjects(Subject newsubjects)
        {
            db.Subjects.Add(newsubjects);
            db.SaveChanges();
        }
        public void deleteSubjects(Subject newsubjects)
        {
            db.Subjects.Remove(newsubjects);
            db.SaveChanges();
        }
        public void updateSubjects(short id, Subject udtSubject)
        {
            var subjects = db.Subjects.Find(id);
            if (subjects != null)
            {
                subjects.SubjectId = udtSubject.SubjectId;
                subjects.SubjectName = udtSubject.SubjectName;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error Found");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
