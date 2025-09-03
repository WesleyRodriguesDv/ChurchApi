namespace ChurchApi.Models;

public class DepartamentModel
{
    public string Name { get; set; }
    public int Id { get; set; }
    public ICollection<MemberModel> Members { get; set;}
}
