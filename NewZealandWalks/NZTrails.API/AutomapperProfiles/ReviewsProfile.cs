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
			CreateMap<Review, AddReviewDto>().ReverseMap();
			CreateMap<Review, UpdateReviewDto>().ReverseMap();
		}
	}
}
