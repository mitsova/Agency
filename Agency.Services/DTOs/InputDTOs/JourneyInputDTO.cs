namespace Agency.Web.Fetching_models
{
    public class JourneyInputDTO
    {
        public string StartLocation { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public decimal TravelCosts { get; set; }

        public int VehicleId { get; set; }
    }
}
