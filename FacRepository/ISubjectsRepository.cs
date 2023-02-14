using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public interface ISubjectsRepository
    {
        public List<SubjectsDTO> GetSubjects();

        public void addSubjects(Subject newSubject);
        public void deleteSubjects(Subject delSubject);
        public void updateSubjects(short id, Subject udtSubject);
    }
}
