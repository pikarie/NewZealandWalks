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
		public async Task<IActionResult> GetAllRegionsAsync()
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

		[HttpGet]
		[Route("{id:guid}")]
		[ActionName(nameof(GetRegionAsync))]
		public async Task<IActionResult> GetRegionAsync(Guid id)
		{
			var region = await regionRepository.GetAsync(id);

			if (region == null)
			{
				return NotFound();
			}

			var regionDto = mapper.Map<RegionDto>(region);

			return Ok(regionDto);
		}

		[HttpPost]
		public async Task<IActionResult> AddRegionAsync(AddRegionDto addRegionDto)
		{
			var region = mapper.Map<Region>(addRegionDto);
			var newRegion = await regionRepository.AddAsync(region);
			var regionDto = mapper.Map<RegionDto>(newRegion);

			return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
		}

		//TODO: not working at the moment, not sure why. something about the mapping?! We will refactor the mapping soon.
		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateRegionAsync(Guid id, UpdateRegionDto updateRegionDto)
		{
			//var region = mapper.Map<Region>(updateRegionDto);
			var region = new Region()
			{
				Id = id,
				Code = updateRegionDto.Code,
				Name = updateRegionDto.Name,
				Area = updateRegionDto.Area,
				Latitude = updateRegionDto.Latitude,
				Longitude = updateRegionDto.Longitude,
				Population = updateRegionDto.Population
			};
			var updatedRegion = await regionRepository.UpdateAsync(id, region);

			if (updatedRegion == null)
			{
				return NotFound();
			}

			var regionDto = mapper.Map<RegionDto>(updatedRegion);
			return Ok(regionDto);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteRegionAsync(Guid id)
		{
			var region = await regionRepository.DeleteAsync(id);
			if (region == null)
			{
				return NotFound();
			}

			var regionDto = mapper.Map<RegionDto>(region);
			return Ok(regionDto);
		}
	}
}
