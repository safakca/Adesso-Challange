namespace AdessoWorldLeague.Models;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
}