using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Mapping;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region Client
            CreateMap<Client, SaveClientDTO>()
                .ReverseMap()
                .ForMember(x => x.Sales, opt => opt.Ignore());
        #endregion

        #region Product
        CreateMap<Product, SaveProductDTO>()
            .ReverseMap()
            .ForMember(x => x.SaleProducts, opt => opt.Ignore());
        #endregion

        #region Sales
        CreateMap<Sales, SalesDTO>()
            .ReverseMap()
            .ForMember(x => x.Client, opt => opt.Ignore());
        #endregion

        #region SaleProduct
            CreateMap<SaleProduct, SaveSaleProductDTO>()
                .ReverseMap()
                .ForMember(x => x.Sales, opt => opt.Ignore())
                .ForMember(x => x.Product, opt => opt.Ignore());
        #endregion   
    }
}