using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public interface IAdministratorRepository
    {
        List<FacultyDTO> GetFaculties();

        void addFaculty(Faculty newFaculty);
        void deleteFaculty(Faculty delFaculty);
        void updateFaculty(short id, Faculty udtFaculty);

        List <Course>GetCourses();

        void addCourses( Course newcourses);

       void  deleteCourses( Course delCourses);

        void updateCourses( short id,  Course udtCourses);


        List<SubjectsDTO>GetSubjects();

        void addSubjects( Subject newSubjects );

        void deleteSubjects( Subject deleteSubjects);

        void updateSubjects( short id, Subject newSubjects );
        void addDepartments(Department newDepartment);
    }
}
