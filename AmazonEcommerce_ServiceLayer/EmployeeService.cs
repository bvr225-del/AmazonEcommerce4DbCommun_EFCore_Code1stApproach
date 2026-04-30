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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee emp = new Employee();            
            //destinationmodelclass object
            //This Code was replaced by above Automapper concept.
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object

            _mapper.Map(empdetail, emp);// sourceobject,destinationobject
            //Converting source modelobject to destination modelobject
            //Syntax:   _mapper.Map(SourceModelObject,DestinationModelObject)
            //once mapping is created, source model object can be converted to destination model object with less code and easy way.
            var res = await _employeeRepository.AddEmployes(emp);
            return 1;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _employeeRepository.DeleteEmployesById(empid);
            return true;

        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _employeeRepository.GetEmployeeById(empid);
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object        
            return _mapper.Map<EmployeeDto>(res);//entity to dto mapping
                                                 //in Service layer we are using Dto(Data transfer object) classes and return the data of Dto class object data.

        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var res = await _employeeRepository.GetEmployees();
            return _mapper.Map<List<EmployeeDto>>(res);//entity to dto mapping

        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            _mapper.Map(empdetail, emp);
            await _employeeRepository.UpdateEmploye(emp);
            return true;

        }
    }
}
/* 1.what is Automapper?
 1)Auto mapper is used to create a mapping between  to source model object to destination model object

 2)once mapping is created, source model object can be converted to destination model object with less code and easy way.
 
 3)Auto mapper can be instaled by using NUEGet Manage packager.
 
 4) This required two steps:

        1) creating mapping
         
      syntax: mapper.createmap < sourcemodel object,destination modelobject >();
            
           Here <> Means We called as a Placeholder .

         2) Converting source modelobject to destination modelobject

          destination modelclass Reference variable= Mapper.Map<destination modelclassname>(source modelclasspbject)

//===================================================

//Converting source modelobject to destination modelobject
//Syntax:   _mapper.Map(SourceModelObject,DestinationModelObject)
//once mapping is created, source model object can be converted to destination model object with less code and easy way.
================
*/