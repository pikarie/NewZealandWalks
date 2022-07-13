using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrailsController : ControllerBase
	{
		private readonly ITrailRepository trailRepository;
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;

		public TrailsController(ITrailRepository trailRepository, IRegionRepository regionRepository, IMapper mapper)
		{
			this.trailRepository = trailRepository;
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}

		// GET: api/Trails
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TrailDto>>> GetTrails()
		{
			var trails = await trailRepository.GetAllAsync();

			if (trails == null)
			{
				return NotFound();
			}

			return Ok(mapper.Map<List<TrailDto>>(trails));
		}

		// GET: api/Trails/5
		[HttpGet("{id:guid}")]
		[ActionName(nameof(GetTrail))]
		public async Task<ActionResult<TrailDto>> GetTrail(Guid id)
		{
			var trail = await trailRepository.GetAsync(id);

			if (trail == null)
			{
				return NotFound();
			}

			return Ok(mapper.Map<TrailDto>(trail));
		}

		// POST: api/Trails
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		[ActionName(nameof(GetTrail))]
		public async Task<ActionResult<TrailDto>> PostTrail(AddTrailDto addTrailDto)
		{
			//Validating FK with the context + fluentValidator for properties.
			if (!(await ValidateAddTrailAsync(addTrailDto)))
			{
				//return BadRequest(ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)));
				return BadRequest(ModelState);
			}

			var trail = mapper.Map<Trail>(addTrailDto);
			var newTrail = await trailRepository.AddAsync(trail);
			var trailDto = mapper.Map<TrailDto>(newTrail);

			return CreatedAtAction(nameof(GetTrail), new { id = trailDto.Id }, trailDto);
		}

		// PUT: api/Trails/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> PutTrail(Guid id, UpdateTrailDto updateTrailDto)
		{
			//Validating FK with the context + fluentValidator for properties.
			if (!(await ValidateUpdateTrailAsync(updateTrailDto)))
			{
				//return BadRequest(ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)));
				return BadRequest(ModelState);
			}

			var updatedTrail = await trailRepository.UpdateAsync(id, updateTrailDto);

			if (updatedTrail == null)
			{
				return NotFound();
			}

			return Ok(updateTrailDto);
		}

		// DELETE: api/Trails/5
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteTrail(Guid id)
		{
			var trail = await trailRepository.DeleteAsync(id);
			if (trail == null)
			{
				return NotFound();
			}

			var trailDto = mapper.Map<TrailDto>(trail);
			return Ok(trailDto);
		}

		private async Task<bool> ValidateAddTrailAsync(AddTrailDto trailDto)
		{
			//if (trailDto == null)
			//{
			//	ModelState.AddModelError(nameof(trailDto), $"(custom message!) Trail data is required.");
			//}

			//if (string.IsNullOrWhiteSpace(trailDto.Name))
			//{
			//	ModelState.AddModelError(nameof(trailDto.Name), $"(custom message!) {nameof(trailDto.Name)} cannot be null, empty or white space.");
			//}

			var region = await regionRepository.GetAsync(trailDto.RegionId);
			if (region == null)
			{
				ModelState.AddModelError(nameof(trailDto.RegionId), $"(custom message!) {nameof(trailDto.RegionId)} is invalid.");
			}

			return ModelState.ErrorCount < 0;
		}

		private async Task<bool> ValidateUpdateTrailAsync(UpdateTrailDto trailDto)
		{
			//if (trailDto == null)
			//{
			//	ModelState.AddModelError(nameof(trailDto), $"(custom message!) Trail data is required.");
			//}

			//if (string.IsNullOrWhiteSpace(trailDto.Name))
			//{
			//	ModelState.AddModelError(nameof(trailDto.Name), $"(custom message!) {nameof(trailDto.Name)} cannot be null, empty or white space.");
			//}

			var region = await regionRepository.GetAsync(trailDto.RegionId);
			if (region == null)
			{
				ModelState.AddModelError(nameof(trailDto.RegionId), $"(custom message!) {nameof(trailDto.RegionId)} is invalid.");
			}

			return ModelState.ErrorCount < 0;
		}
	}
}
