using ChallengeBackEnd5.Data.DTOs.Video;
using ChallengeBackEnd5.Models;
using AutoMapper;
using ChallengeBackEnd5.Data.DTOs.Categoria;
using ChallengeBackEnd5.Data.DTOs;

namespace ChallengeBackEnd5.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateVideoDTO, Video>().ReverseMap();
            CreateMap<PatchVideoDTO, Video>().ReverseMap();
            CreateMap<Video, ReadVideoDTO>().ReverseMap();
                

            CreateMap<CreateCategoriaDTO, Categoria>().ReverseMap();
            CreateMap<PatchCategoriaDTO,Categoria>().ReverseMap();
            CreateMap<Categoria, ReadCategoriaDTO>()
                .ForMember(categoira => categoira.videos, opts => opts
               .MapFrom(categoira => categoira.videos.Select
               (v => new {  v.Title, v.url })));
        }
    }
}
