using AutoMapper;
using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Dtos.OrderProductDTOs;
using E_Commerce.Bll.Dtos.PaymentDTOs;
using E_Commerce.Bll.Dtos.ProductDTOs;
using E_Commerce.Dal.Entities;

namespace E_Commerce.Bll.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Card, CardCreateDto>()
            .ReverseMap()
            .ForMember(dest => dest.SelectedForPayment, opt => opt.MapFrom(src => true));
        CreateMap<Card, CardGetDto>().ReverseMap(); 
        CreateMap<Card, CardUpdateDto>().ReverseMap(); 

        CreateMap<Cart, CartCreateDto>().ReverseMap(); 
        CreateMap<Cart, CartGetDto>().ReverseMap(); 

        CreateMap<CartProduct, CartProductCreateDto>().ReverseMap(); 
        CreateMap<CartProduct, CartProductGetDto>().ReverseMap(); 

        CreateMap<Customer, CustomerCreateDto>().ReverseMap(); 
        CreateMap<Customer, CustomerGetDto>().ReverseMap(); 
        CreateMap<Customer, CustomerUpdateDto>().ReverseMap(); 

        CreateMap<OrderProduct, OrderProductGetDto>().ReverseMap(); 

        CreateMap<Order, OrderGetDto>().ReverseMap();
        CreateMap<Order, OrderCreateDto>().ReverseMap();

        CreateMap<Payment, PaymentCreateDto>().ReverseMap(); 
        CreateMap<Payment, PaymentGetDto>().ReverseMap(); 
        CreateMap<Payment, PaymentUpdateDto>().ReverseMap(); 

        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
    }
}
