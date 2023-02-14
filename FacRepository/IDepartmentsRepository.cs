using FacRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacRepository
{
    public interface IDepartmentsRepository
    {
        List<Department> GetDepartments();
        void addDepartments(Department newDepartment);
    }
}
