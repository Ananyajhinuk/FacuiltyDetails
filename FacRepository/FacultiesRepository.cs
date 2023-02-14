using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;

namespace FacRepository
{

    public class FacultiesRepository : IFacultiesRepository
    {
        ProjectContext db = new ProjectContext();


        public FacultiesRepository(ProjectContext context)
        {
            this.db = context;
        }

        public FacultiesRepository()
        {

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
            return null;
        }

        List<FacultyDTO> IFacultiesRepository.GetFaculties()
        {
            throw new NotImplementedException();
        }

        //List<Course> IFacultiesRepository.GetCourses()
        //{
        //    throw new NotImplementedException();
        //}

        void IFacultiesRepository.addFaculty(Faculty newFaculty)
        {
            throw new NotImplementedException();
        }

        void IFacultiesRepository.deleteFaculty(Faculty delFaculty)
        {
            throw new NotImplementedException();
        }

        void IFacultiesRepository.updateFaculty(short id, Faculty udtFaculty)
        {
            throw new NotImplementedException();
        }

        //List<Course> IFacultiesRepository.GetCourses()
        //{
        //    throw new NotImplementedException();
        //}
    }
    }
