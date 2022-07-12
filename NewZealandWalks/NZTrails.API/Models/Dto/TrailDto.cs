using Newtonsoft.Json;
using NZWalks.API;
using NZWalks.API.Models.Domain;

namespace NZTrails.API.Models.Dto
{
	public class TrailDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double? Length { get; set; }
		public long? TimeInSeconds { get; set; }
		public TrailDifficulty? TrailDifficulty { get; set; }
		public Guid RegionId { get; set; }
		public List<ReviewDto> Reviews { get; set; }
	}
}
