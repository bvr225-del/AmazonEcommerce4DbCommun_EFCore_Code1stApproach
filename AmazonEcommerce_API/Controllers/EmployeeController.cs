using AmazonEcommerce_BusinessEntities.Dtos;
using AmazonEcommerce_BusinessEntities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonEcommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.AddEmployes(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if (empid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.DeleteEmployesById(empid);
                if (empdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _employeeService.GetEmployees();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _employeeService.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] EmployeeDto empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _employeeService.UpdateEmploye(empdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

    }
}
/*
 * ======syntax for code first approcah updations=======
 Go to Tools=>NugetPackageManger=>PackageManagerConsole=>It will open one console window=>execute below comands stepby step.
Synatx:(if you have multiple dbcontext class then you need to specify the context class name in below commands otherwise you can skip that part)
==========

PM>Add-Migration MigrationName -Context ContextClassName
 
PM>update-database -Context ContextClassName
================use below commands for generting the database============================================
====this migration used for DepartmentContext================

Add-Migration Department -Context DepartmentContext
 
update-database -Context DepartmentContext

====this migration used for EmployeeContext==========

Add-Migration Employee -Context EmployeeContext
 
update-database -Context EmployeeContext

====this migration used for OrderContext==========

Add-Migration order -Context OrderContext
 
update-database -Context OrderContext


====this migration used for RestaurantContext===========

Add-Migration Resterent -Context RestaurantContext
 
update-database -Context RestaurantContext
=================
note:
======
MigrationName should not duplicate,if you want to change the name of migration you can change it but it should not duplicate with existing migration name.
before running the above commands you need to build your solution,otherwise you will get error like "unable to create an object of type 'ContextClassName'".if you want to remove the existing migration you can use below command.
if you have mutilplecontext classes,you need to specify the correct context class name,while running the Add-migration command.

*/