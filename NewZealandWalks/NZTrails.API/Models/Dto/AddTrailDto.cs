using NZWalks.API;

namespace NZTrails.API.Models.Dto
{
	public class AddTrailDto
	{
		public string Name { get; set; }
		public double? Length { get; set; }
		public long? TimeInSeconds { get; set; }
		public TrailDifficulty? TrailDifficulty { get; set; }
		public Guid RegionId { get; set; }
	}
}
