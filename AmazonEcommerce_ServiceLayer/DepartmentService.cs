using AmazonEcommerce_BusinessEntities.Dtos;
using AmazonEcommerce_BusinessEntities.Entities;
using AmazonEcommerce_BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        //constructor injection
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            dept.deptid = deptdetail.deptid;
            dept.deptname = deptdetail.deptname;
            dept.deptlocation = deptdetail.deptlocation;
            var res = await _repository.AddDepartments(dept);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<DepartmentDto> GetDepartmentById(int deptid)
        {
            var res = await _repository.GetDepartmentById(deptid);
            DepartmentDto deptdto = new DepartmentDto();
            deptdto.deptid = res.deptid;
            deptdto.deptname = res.deptname;
            deptdto.deptlocation = res.deptlocation;
            return deptdto;
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {
            List<DepartmentDto> lstdeptdto = new List<DepartmentDto>();
            var res = await _repository.GetDepartments();
            foreach (Department dept in res)
            {
                DepartmentDto deptDto = new DepartmentDto();
                deptDto.deptid = dept.deptid;
                deptDto.deptname = dept.deptname;
                deptDto.deptlocation = dept.deptlocation;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            dept.deptid = deptdetail.deptid;
            dept.deptname = deptdetail.deptname;
            dept.deptlocation = deptdetail.deptlocation;
            await _repository.UpdateDepartment(dept);
            return true;
        }
    }
}
