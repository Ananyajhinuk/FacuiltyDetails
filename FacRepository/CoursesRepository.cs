using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public class CoursesRepository:ICoursesRepository
    {

        ProjectContext db = new ProjectContext();
        public CoursesRepository(ProjectContext context)
        {
            {
                this.db = context;

            }
        }
        public List<Course> GetCourses()
        {
            Course cou = new Course();
            var query = db.Courses.Select(e => new Course
            {
                CourseId = e.CourseId,
                CourseName = e.CourseName,
                CourseCredits = e.CourseCredits,
                DeptId = e.DeptId

            }).ToList();

            return query;
        }
        public void addCourses( Course newcourses)
        {
            db.Courses.Add(newcourses);
            db.SaveChanges();
        }

        public void deleteCourses(Course delCourse)
        {
            db.Courses.Remove(delCourse);
            db.SaveChanges();
        }

        public void updateCourses(short id, Course udtCourses)
        {
            var courses = db.Courses.Find(id);
            if (courses != null)
            {
                courses.CourseId = udtCourses.CourseId;
                courses.CourseName = udtCourses.CourseName;
                courses.CourseCredits = udtCourses.CourseCredits;
                db.SaveChanges();

            }
            else
            {
                Console.WriteLine("Error Found");
            }
        }

        List<Course> ICoursesRepository.GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
