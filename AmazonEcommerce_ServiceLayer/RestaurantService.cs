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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            this._mapper = mapper;
        }

        public async Task<bool> AddRestaurant(RestaurantDto Objres)
        {
            Restaurant objres = new Restaurant();
            _mapper.Map(Objres, objres);
            var res = await _restaurantRepository.AddRestaurant(objres);
            return res;

        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            await _restaurantRepository.DeleteRestaurant(Id);
            return true;

        }

        public async Task<List<RestaurantDto>> GetallRestaurants()
        {
            var getrestaurants = await _restaurantRepository.GetallRestaurants();
            return _mapper.Map<List<RestaurantDto>>(getrestaurants);
        }

        public async Task<RestaurantDto> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            return _mapper.Map<RestaurantDto>(res);

        }

        public async Task<bool> UpdateRestaurant(RestaurantDto Objres)
        {
            Restaurant res = new Restaurant();
            _mapper.Map(Objres, res);
            await _restaurantRepository.UpdateRestaurant(res);
            return true;

        }
    }
}
