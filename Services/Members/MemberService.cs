using ChurchApi.Data;
using ChurchApi.DTOs.Member;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace ChurchApi.Services.Members;

public class MemberService: IMemberInterface
{
    private readonly AppDbContext _context;

    public MemberService(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<ResponseModel<List<MemberModel>>> GetMembers()
    {
        ResponseModel<List<MemberModel>> response = new ResponseModel<List<MemberModel>>();
        try
        {
            var members = await _context.Members.ToListAsync();
            response.Data = members;
            response.Message = "Todos os membros foram listados com sucesso!";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<MemberModel>> GetMemberById(int memberId)
    {
        ResponseModel<MemberModel> response = new ResponseModel<MemberModel>();
        try
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == memberId);
            if (member == null)
            {
                response.Message = "Membro não encontrado";
                response.Status = false;
                return response;
            }

            response.Data = member;
            response.Message = "Membro encontrado com sucesso!";
            return response;

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public Task<ResponseModel<MemberModel>> CreateMember(MemberCreateDTO memberCreateDto)
    {
        throw new NotImplementedException();
    }
}