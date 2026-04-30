using AmazonEcommerce_BusinessEntities.Dtos;
using AmazonEcommerce_BusinessEntities.Entities;
using AmazonEcommerce_BusinessEntities.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        //Don't create dirrect object of repository class here
        //create the onstructor of this service class and inject the repository interface into the constructor and assign it to the private readonly field of the repository interface type.

        //constructor injection
        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }
        //we called this process as dependency injection and this is the best practice to achieve loose coupling between the service and repository layers of the application.

        public async Task<int> AddDepartments(DepartmentDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
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
            return _mapper.Map<DepartmentDto>(res);
        }

        public async Task<List<DepartmentDto>> GetDepartments()
        {
            var res = await _repository.GetDepartments();
            return _mapper.Map<List<DepartmentDto>>(res);
        }

        public async Task<bool> UpdateDepartment(DepartmentDto deptdetail)
        {
            Department dept = new Department();
            _mapper.Map(deptdetail, dept);
            await _repository.UpdateDepartment(dept);
            return true;
        }
    }
}
