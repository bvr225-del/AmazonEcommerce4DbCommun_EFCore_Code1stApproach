using AmazonEcommerce_BusinessEntities.Dtos;
using AmazonEcommerce_BusinessEntities.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_ServiceLayer.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        //create the constructor for this class and inside the constructor we will create
        //the mapping configuration for the source and destination objects using the CreateMap method of the AutoMapper library.
        public AutoMapperProfile()
        {
            //=================syntax for creating the mapping configuration=================
            // CreateMap<SourceClass, DestinationClass>();
            // Example:
            // CreateMap<UserEntity, UserDTO>();
            //===========================================
            CreateMap<EmployeeDto, Employee>();//this is used to map the data of EmployeeDto class object to Employee class object
            CreateMap<Employee, EmployeeDto>();//this is used to map the data of Employee class object to EmployeeDto class object
            CreateMap<DepartmentDto, Department>();//this is used to map the data of DepartmentDto class object to Department class object
            CreateMap<Department, DepartmentDto>();//this is used to map the data of Department class object to DepartmentDto class object
            CreateMap<OrderDto, Order>();//this is used to map the data of OrdersDto class object to Orders class object
            CreateMap<Order, OrderDto>();//this is used to map the data of Orders class object to OrdersDto class object
            CreateMap<RestaurantDto, Restaurant>();//this is used to map the data of RestaurantDto class object to Restaurant class object
            CreateMap<Restaurant, RestaurantDto>();//this is used to map the data of Restaurant class object to RestaurantDto class object



        }

    }
}
