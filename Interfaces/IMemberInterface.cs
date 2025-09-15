using ChurchApi.DTOs.Member;
using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IMemberInterface
{
    Task<ResponseModel<List<MemberModel>>> GetMembers();

    Task<ResponseModel<MemberModel>> GetMemberById(int memberId);

    Task<ResponseModel<List<MemberModel>>> CreateMember(MemberCreateDto memberCreateDto);

    Task<ResponseModel<MemberModel>> EditMember(MemberEditDto memberEditDto);
}