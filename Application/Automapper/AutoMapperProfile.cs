using AutoMapper;
using PruebaTecnica.Domain.DTOs;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Automapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Productos, ProductoDTO>().ReverseMap();
        }

    }
}

