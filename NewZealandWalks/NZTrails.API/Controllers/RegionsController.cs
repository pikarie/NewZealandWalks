using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegionsController : Controller
	{
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;

		public RegionsController(IRegionRepository regionRepository, IMapper mapper)
		{
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRegions()
		{
			var regions = await regionRepository.GetAllAsync();

			//var regionsDto = new List<RegionDto>();
			//regions.ToList().ForEach(region =>
			//{
			//	var regionDto = new RegionDto()
			//	{
			//		Id = region.Id,
			//		Code = region.Code,
			//		Name = region.Name,
			//		Area = region.Area,
			//		Latitude = region.Latitude,
			//		Longitude = region.Longitude,
			//		Population = region.Population,
			//	};

			//	regionsDto.Add(regionDto);
			//});

			var regionsDto = mapper.Map<List<RegionDto>>(regions);

			return Ok(regionsDto);
		}
	}
}
