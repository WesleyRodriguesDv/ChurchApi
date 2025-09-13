namespace ChurchApi.Models;

public class MemberModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentModel DepartamentId { get; set; }
}