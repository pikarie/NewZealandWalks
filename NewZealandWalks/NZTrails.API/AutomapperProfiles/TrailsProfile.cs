using AutoMapper;
using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.AutomapperProfiles
{
	public class TrailsProfile : Profile
	{
		public TrailsProfile()
		{
			CreateMap<Trail, TrailDto>().ReverseMap();
			CreateMap<Trail, AddTrailDto>().ReverseMap();
			CreateMap<Trail, UpdateTrailDto>().ReverseMap();
		}
	}
}
