namespace ChurchApi.Models;

public class MemberModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public ICollection<DepartamentModel> Departaments { get; set; }
}