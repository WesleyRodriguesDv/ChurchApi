namespace ChurchApi.Models;

public class DepartamentModel
{
    public string Name { get; set; }
    public int Id { get; set; }
    private ICollection<MemberModel> Members { get; set;}
}
