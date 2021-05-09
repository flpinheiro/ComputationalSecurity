using AutoMapper;
using System.Numerics;
using UnB.Security.Domain;
using UnB.Security.WebApi.Dto;

namespace UnB.Security.WebApi.Config.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PrivateKey, PrivateKeyDto>()
                .ForMember(pkDto => pkDto.N, opt => opt.MapFrom(pk => pk.N.ToString()))
                .ForMember(pkDto => pkDto.D, opt => opt.MapFrom(pk => pk.D.ToString()))
                .ReverseMap()
                .ForMember(pk => pk.N, opt => opt.MapFrom(pkDto => BigInteger.Parse(pkDto.N)))
                .ForMember(pk => pk.D, opt => opt.MapFrom(pkDto => BigInteger.Parse(pkDto.D)));

            CreateMap<PublicKey, PublicKeyDto>()
                .ForMember(pkDto => pkDto.N, opt => opt.MapFrom(pk => pk.N.ToString()))
                .ForMember(pkDto => pkDto.E, opt => opt.MapFrom(pk => pk.E.ToString()))
                .ReverseMap()
                .ForMember(pk => pk.N, opt => opt.MapFrom(pkDto => BigInteger.Parse(pkDto.N)))
                .ForMember(pk => pk.E, opt => opt.MapFrom(pkDto => BigInteger.Parse(pkDto.E)));
        }
    }
}
