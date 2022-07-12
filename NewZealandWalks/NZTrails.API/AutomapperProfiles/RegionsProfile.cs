using AutoMapper;
using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.AutomapperProfiles
{
	public class RegionsProfile : Profile
	{
		public RegionsProfile()
		{
			CreateMap<Region, RegionDto>()
				//.ForMember(destination => destination.Id, options => options.MapFrom(source => source.IdWithAnotherPropertyName));
				.ReverseMap();
		}
	}
}
