using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public interface ICoursesRepository
    {
        List<Course> GetCourses();

        void addCourses(Course newCourses);
        void deleteCourses(Course newCourses);
        void updateCourses(short id, Course newCourse);
    }
}
