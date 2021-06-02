using AutoMapper;
using CinemaApi.Dtos;
using CinemaCore.Models;

namespace CinemaApi.MappingConfigurations
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}
