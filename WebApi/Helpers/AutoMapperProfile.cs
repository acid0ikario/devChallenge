using AutoMapper;
using DataAccess.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    /// <summary>
    /// Esta Clase se utiliza unicamente para crear los mapas de automapper. Siempre debe heredar de Profile
    /// </summary>
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Items, ItemsDTO>();
            CreateMap< ItemsDTO, Items>();
        }
    }
}
