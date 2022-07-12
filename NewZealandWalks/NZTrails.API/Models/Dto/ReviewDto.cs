using NZWalks.API.Models.Domain;
using System.Text.Json.Serialization;

namespace NZTrails.API.Models.Dto
{
	public class ReviewDto
	{
		public Guid Id { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public int Rating { get; set; }
		public string? LikedComment { get; set; }
		public string? DislikedComment { get; set; }
		public Guid TrailId { get; set; }
	}
}
