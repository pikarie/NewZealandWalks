using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZTrails.API.Models.Dto;
using NZTrails.API.Repositories;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrailsController : ControllerBase
	{
		private readonly ITrailRepository trailRepository;
		private readonly IMapper mapper;

		public TrailsController(ITrailRepository trailRepository, IMapper mapper)
		{
			this.trailRepository = trailRepository;
			this.mapper = mapper;
		}

		// GET: api/Trails
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Trail>>> GetTrails()
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
		public async Task<ActionResult<Trail>> GetTrail(Guid id)
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
		public async Task<ActionResult<Trail>> PostTrail(AddTrailDto addTrailDto)
		{
			var trail = mapper.Map<Trail>(addTrailDto);
			var newTrail = await trailRepository.AddAsync(trail);
			var trailDto = mapper.Map<TrailDto>(newTrail);

			return CreatedAtAction(nameof(GetTrail), new { id = trailDto.Id }, trailDto);
		}

		// PUT: api/Trails/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//TODO: not working at the moment, not sure why. something about the mapping?! We will refactor the mapping soon.
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> PutTrail(Guid id, UpdateTrailDto updateTrailDto)
		{
			var trail = mapper.Map<Trail>(updateTrailDto);

			var updatedTrail = await trailRepository.UpdateAsync(id, trail);

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
	}
}
