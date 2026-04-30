using AmazonEcommerce_BusinessEntities.Entities;
using AmazonEcommerce_BusinessEntities.Interfaces;
using AmazonEcommerce_DbConnectivity;
using Microsoft.EntityFrameworkCore;

//using AmazonEcommerce_DbConnectivity.Migrations.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_RepositoryLayer
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DepartmentContext _departmentContext;
        public DepartmentRepository(DepartmentContext departmentContext)
        {
            _departmentContext = departmentContext;
        }
        public async Task<int> AddDepartments(Department deptdetail)
        {
            await _departmentContext.Departments.AddAsync(deptdetail);
            _departmentContext.SaveChanges();
            return 1;

        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            Department rm = _departmentContext.Departments.Where(e => e.deptid == deptid).SingleOrDefault();
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _departmentContext.Departments.Remove(rm);
                _departmentContext.SaveChanges();//similart to commit
                return true;


            }
            else return false;

        }
        public async Task<Department> GetDepartmentById(int deptid)
        {
            var rm = await _departmentContext.Departments.Where(e => e.deptid == deptid).FirstOrDefaultAsync();
            var rm1 = await _departmentContext.Departments.FirstOrDefaultAsync(e => e.deptid == deptid);

            if (rm == null)
                return null;
            else
                return rm;

        }

        public async Task<List<Department>> GetDepartments()
        {
            var result = _departmentContext.Departments.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            _departmentContext.Update(deptdetail);
            await _departmentContext.SaveChangesAsync();
            return true;

        }
    }
}
