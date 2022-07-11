using System;

namespace NZWalks.API.Models.Domain
{
	public class Trail
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double? Length { get; set; }
		public long? TimeInSeconds { get; set; }
		public TrailDifficulty? TrailDifficulty { get; set; }
		public Guid RegionId { get; set; }
		public Region Region { get; set; }
		public List<Review> Reviews { get; set; }
	}
}
