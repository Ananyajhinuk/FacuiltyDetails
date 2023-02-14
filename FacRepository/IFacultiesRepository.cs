using FacRepository.DTO;
using FacRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public interface IFacultiesRepository
    {
        List<FacultyDTO> GetFaculties();
        List<Course> GetCourses();

        void addFaculty(Faculty newFaculty);
        void deleteFaculty(Faculty delFaculty); 
        void updateFaculty(short id, Faculty udtFaculty);
    }
}
