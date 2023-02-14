using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        ProjectContext db = new ProjectContext();
        public AdministratorRepository(ProjectContext context)
        {
            {
                this.db = context;

            }
             
        }
        public List<FacultyDTO> GetFaculties()
        {
            Faculty fac = new Faculty();
            var query = db.Faculties.Select(e => new FacultyDTO
            {
                FacultyId = e.FacultyId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                City = e.City,
                State = e.State,
                Pincode = e.Pincode,
                MobileNo = e.MobileNo,
                HireDate = e.HireDate,
                EmailAddress = e.EmailAddress,
                DateofBirth = e.DateofBirth,
                DeptId = e.DeptId,
                DesignationId = e.DesignationId

            }).ToList();


            return query;
        }

        public void addFaculty(Faculty newFaculty)
        {
            db.Faculties.Add(newFaculty);
            db.SaveChanges();
        }

        public void deleteFaculty(Faculty delFaculty)
        {
            db.Faculties.Remove(delFaculty);
            db.SaveChanges();
        }

        public void updateFaculty(short id, Faculty udtFaculty)
        {
            var fal = db.Faculties.Find(id);
            if (fal != null)
            {
                fal.FacultyId = udtFaculty.FacultyId;
                fal.FirstName = udtFaculty.FirstName;
                fal.LastName = udtFaculty.LastName;
                fal.Address = udtFaculty.Address;
                fal.City = udtFaculty.City;
                fal.State = udtFaculty.State;
                fal.Pincode = udtFaculty.Pincode;
                fal.MobileNo = udtFaculty.MobileNo;
                //  fal.HireDate = udtFaculty.HireDate;
                fal.EmailAddress = udtFaculty.EmailAddress;
                fal.DateofBirth = udtFaculty.DateofBirth;
                fal.DeptId = udtFaculty.DeptId;
                //  fal.DesignationId=udtFaculty.DesignationId;
                db.SaveChanges();
            }
            else
            {
                //Console.WriteLine(NotFound());
                Console.WriteLine("Error found");
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
        public void addCourses(Course newcourses)
        {
            db.Courses.Add(newcourses);
            db.SaveChanges();
        }

        public void deleteCourses(Course delCourse)
        {
            db.Courses.Remove(delCourse);
            db.SaveChanges();
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
        public void deleteSubjects(Subject delSubject) 
        {
            db.Subjects.Remove(delSubject);
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

        public void updateCourses(short id, Course udtCourses)
        {
            throw new NotImplementedException();
        }

        public void addDepartments(Department newDepartment)
        {
            throw new NotImplementedException();
        }
    }
    
}
