using AmazonEcommerce_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Interfaces
{
    public interface IRestaurantService
    {
        Task<bool> AddRestaurant(RestaurantDto Objres);
        Task<bool> UpdateRestaurant(RestaurantDto Objres);
        Task<bool> DeleteRestaurant(int Id);
        Task<List<RestaurantDto>> GetallRestaurants();
        Task<RestaurantDto> GetRestaurantById(int Id);

    }
}
