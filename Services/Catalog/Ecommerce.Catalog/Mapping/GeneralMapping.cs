using AutoMapper;
using Ecommerce.Catalog.Dtos.CategoryDtos;
using Ecommerce.Catalog.Dtos.ProductDetailDtos;
using Ecommerce.Catalog.Dtos.ProductDtos;
using Ecommerce.Catalog.Dtos.ProductImageDtos;
using Ecommerce.Catalog.Entities;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Dtos.OfferDiscountDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Mapping
{ 
    public class GeneralMapping:Profile   // Maplemenin amacı bizim entitilweimizden nesne örneği oluşturmak yerine (newlemek)                                
    {                                       // Entitiylerimizin proportieslerini DTO'daki proportieslerle eşleştirmektir.
        public GeneralMapping() 
        {
            // kategori için mapleme
            CreateMap<Category, ResultCategoryDto>().ReverseMap();  // reverse map ile tam tersi şekildede mapleme gerçekleşebileceğini belitrrik
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            // Ürünler için mapleme
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();
            
            //Ürün detayları için Mapleme
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            // ürün resimleri için mapleme
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            // Feature Slider(ana sayfadaki kayan öne çıkanlar) için mapleme
            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            // Special Offer için mapleme
            CreateMap<SpecialOffer, ResultSpeacialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            // Feature için mapleme
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            // Offer Discount için mapleme
            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();

            // Brands için mapleme
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

            //About için mapleme
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            // Contact için Mapleme
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
        }
    }
}
