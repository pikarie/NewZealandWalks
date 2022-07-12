using AutoMapper;
using NZTrails.API.Models.Dto;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.AutomapperProfiles
{
	public class ReviewsProfile : Profile
	{
		public ReviewsProfile()
		{
			CreateMap<Review, ReviewDto>().ReverseMap();
		}
	}
}
