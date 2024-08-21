namespace AdessoWorldLeague.Models;

public class Group : BaseEntity
{
    public string GroupName { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
}
