namespace AdessoWorldLeague.Models;

public class DrawResult : BaseEntity {

    public string DrawnBy { get; set; }
    public List<Group> Groups { get; set; } = new List<Group>();
}
