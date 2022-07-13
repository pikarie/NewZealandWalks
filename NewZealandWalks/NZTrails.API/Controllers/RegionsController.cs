using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController : ControllerBase
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
			if (!ValidateAddRegion(addRegionDto))
			{
				//return BadRequest(ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)));
				return BadRequest(ModelState);
			}

			var region = mapper.Map<Region>(addRegionDto);
			var newRegion = await regionRepository.AddAsync(region);
			var regionDto = mapper.Map<RegionDto>(newRegion);

			return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateRegionAsync(Guid id, UpdateRegionDto updateRegionDto)
		{
			if (!ValidateUpdateRegion(updateRegionDto))
			{
				//return BadRequest(ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)));
				return BadRequest(ModelState);
			}

			var updatedRegion = await regionRepository.UpdateAsync(id, updateRegionDto);

			if (updatedRegion == null)
			{
				return NotFound();
			}

			return Ok(updateRegionDto);
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

		/// <summary>
		/// O.O; Doing it by hand at first (video 77). I wonder when we will use FluentValidator or Annotations.
		/// </summary>
		/// <param name="regionDto"></param>
		private bool ValidateAddRegion(AddRegionDto regionDto)
		{
			if (regionDto == null)
			{
				ModelState.AddModelError(nameof(regionDto.Code), $"(custom message!) Region data is required.");
			}

			if (string.IsNullOrWhiteSpace(regionDto.Code))
			{
				ModelState.AddModelError(nameof(regionDto.Code), $"(custom message!) {nameof(regionDto.Code)} cannot be null, empty or white space.");
			}

			if (string.IsNullOrWhiteSpace(regionDto.Name))
			{
				ModelState.AddModelError(nameof(regionDto.Name), $"(custom message!) {nameof(regionDto.Name)} cannot be null, empty or white space.");
			}

			if (regionDto.Area <= 0)
			{
				ModelState.AddModelError(nameof(regionDto.Area), $"(custom message!) {nameof(regionDto.Area)} cannot be less than or equal to zero.");
			}

			if (regionDto.Latitude < -90 || regionDto.Latitude > 90)
			{
				ModelState.AddModelError(nameof(regionDto.Latitude), $"(custom message!) {nameof(regionDto.Latitude)} cannot be less than -90 or more than 90.");
			}

			if (regionDto.Longitude < -180 || regionDto.Longitude > 180)
			{
				ModelState.AddModelError(nameof(regionDto.Longitude), $"(custom message!) {nameof(regionDto.Longitude)} cannot be less than -90 or more than 90.");
			}

			if (regionDto.Population < 0)
			{
				ModelState.AddModelError(nameof(regionDto.Population), $"(custom message!) {nameof(regionDto.Population)} cannot be less than zero.");
			}

			return ModelState.ErrorCount < 0;
		}

		/// <summary>
		/// O.O;;; why are we copying all validation from the <see cref="ValidateAddRegion"/>?
		/// </summary>
		/// <param name="updateRegionDto"></param>
		/// <returns></returns>
		private bool ValidateUpdateRegion(UpdateRegionDto regionDto)
		{
			if (regionDto == null)
			{
				ModelState.AddModelError(nameof(regionDto), $"(custom message!) Region data is required.");
			}

			if (string.IsNullOrWhiteSpace(regionDto.Code))
			{
				ModelState.AddModelError(nameof(regionDto.Code), $"(custom message!) {nameof(regionDto.Code)} cannot be null, empty or white space.");
			}

			if (string.IsNullOrWhiteSpace(regionDto.Name))
			{
				ModelState.AddModelError(nameof(regionDto.Name), $"(custom message!) {nameof(regionDto.Name)} cannot be null, empty or white space.");
			}

			if (regionDto.Area <= 0)
			{
				ModelState.AddModelError(nameof(regionDto.Area), $"(custom message!) {nameof(regionDto.Area)} cannot be less than or equal to zero.");
			}

			if (regionDto.Latitude < -90 || regionDto.Latitude > 90)
			{
				ModelState.AddModelError(nameof(regionDto.Latitude), $"(custom message!) {nameof(regionDto.Latitude)} cannot be less than -90 or more than 90.");
			}

			if (regionDto.Longitude < -180 || regionDto.Longitude > 180)
			{
				ModelState.AddModelError(nameof(regionDto.Longitude), $"(custom message!) {nameof(regionDto.Longitude)} cannot be less than -90 or more than 90.");
			}

			if (regionDto.Population < 0)
			{
				ModelState.AddModelError(nameof(regionDto.Population), $"(custom message!) {nameof(regionDto.Population)} cannot be less than zero.");
			}

			return ModelState.ErrorCount < 0;
		}
	}
}
