using ChurchApi.Models;

namespace ChurchApi.DTOs.Member;

public class MemberCreateDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentModel DepartamentId { get; set; }
}