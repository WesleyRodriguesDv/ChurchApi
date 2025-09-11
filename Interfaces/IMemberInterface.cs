using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IMemberInterface
{
    Task<ResponseModel<List<MemberModel>>> GetMembers();

    Task<ResponseModel<MemberModel>> GetMemberById(int memberId);
}