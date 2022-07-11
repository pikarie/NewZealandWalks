namespace NZWalks.API.Models.Domain
{
	public class Review
	{
		public Guid Id { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public int Rating { get; set; }
		public string? LikedComment { get; set; }
		public string? DislikedComment { get; set; }
		public Guid TrailId { get; set; }
		public Trail Trail { get; set; }
	}
}
