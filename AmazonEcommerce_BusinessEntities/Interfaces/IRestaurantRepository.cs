using AmazonEcommerce_BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<bool> AddRestaurant(Restaurant Objres);
        Task<bool> UpdateRestaurant(Restaurant Objres);
        Task<bool> DeleteRestaurant(int Id);
        Task<List<Restaurant>> GetallRestaurants();
        Task<Restaurant> GetRestaurantById(int Id);

    }
}
