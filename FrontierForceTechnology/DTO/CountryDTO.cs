namespace ProjectB.DTO
{
    public class CountriesResponse
    {
        public List<CountryDTO> Countries { get; set; }
    }
    public class CountryDTO
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public int FFCountrySID { get; set; }
    }
}
