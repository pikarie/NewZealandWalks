namespace NZTrails.API.Models.Dto
{
	public class UpdateRegionDto
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public double Area { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public long? Population { get; set; }
	}
}
