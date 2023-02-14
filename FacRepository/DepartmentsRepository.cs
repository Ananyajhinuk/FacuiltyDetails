using FacRepository.Data;
using FacRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        ProjectContext db = new ProjectContext();


        public DepartmentsRepository(ProjectContext context)
        {
            {
                this.db = context;
            }
        }
        public DepartmentsRepository()
        {

        }
        public List<Department> GetDepartments()
        {
            Department dep = new Department();
            var query = db.Departments.Select(e => new Department
            {
                DeptId = e.DeptId,
                DeptName = e.DeptName
            }
            ).ToList();
            return query;
        }

        public void addDepartments(Department newDepartment)
        {
            db.Departments.Add(newDepartment);
            db.SaveChanges();
        }

       
    }
}
