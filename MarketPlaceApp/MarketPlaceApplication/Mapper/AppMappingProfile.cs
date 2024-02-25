using AutoMapper;
using MarketPlace.Application.Dto;
using MarketPlace.Data.Persistent.Classes;
using MarketPlace.Data.Persistent.Entities;

namespace MarketPlace.Application.Mapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

        CreateMap<Product, ProductDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
            .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
    }
}