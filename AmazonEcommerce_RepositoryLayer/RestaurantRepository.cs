using AmazonEcommerce_BusinessEntities.Entities;
using AmazonEcommerce_BusinessEntities.Interfaces;
using AmazonEcommerce_DbConnectivity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_RepositoryLayer
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public RestaurantRepository(RestaurantContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public async Task<bool> AddRestaurant(Restaurant Objres)
        {
            await _restaurantContext.Restaurants.AddAsync(Objres);
            _restaurantContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            Restaurant result = _restaurantContext.Restaurants.Where(e => e.Id == Id).FirstOrDefault();
            if (result != null)
            {//Here Remove() method is used for removing the data from database.

                _restaurantContext.Restaurants.Remove(result);
                _restaurantContext.SaveChanges();//similart to commit
                return true;
            }
            else return false;

        }

        public async Task<List<Restaurant>> GetallRestaurants()
        {
            var result = await _restaurantContext.Restaurants.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<Restaurant> GetRestaurantById(int Id)
        {
            var result = await _restaurantContext.Restaurants.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result == null)
            {//if result having no data i am returning null here.null means nothing.
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateRestaurant(Restaurant Objres)
        {
            _restaurantContext.Restaurants.Update(Objres);
            await _restaurantContext.SaveChangesAsync();
            return true;
        }
    }
}
