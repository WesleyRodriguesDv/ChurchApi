using ChurchApi.DTOs.Departament;
using ChurchApi.Models;

namespace ChurchApi.DTOs.Member;

public class MemberEditDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentRelationDto Departament { get; set; }
}