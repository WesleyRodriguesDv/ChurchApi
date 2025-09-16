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
            var members = await _context.Members
                .Include(x => x.Departament)
                .ToListAsync();
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
            var member = await _context.Members
                .Include(x => x.Departament)
                .FirstOrDefaultAsync(x => x.Id == memberId);
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

    public async Task<ResponseModel<List<MemberModel>>> CreateMember(MemberCreateDto memberCreateDto)
    {

        ResponseModel<List<MemberModel>> response = new ResponseModel<List<MemberModel>>();
        try
        {
            var departament = await _context.Departaments.FirstOrDefaultAsync(x => x.Id == memberCreateDto.Departament.Id);
            
            if (departament == null)
            {
                
                response.Message = "Departamento não encontrado! ";
                return response;
            }

            var member = new MemberModel()
            {
                Name = memberCreateDto.Name,
                LastName = memberCreateDto.LastName,
                Departament = departament
            };
            
            _context.Add(member);
            await _context.SaveChangesAsync();

            response.Data = await _context.Members
                .Include(x => x.Departament).ToListAsync();
            response.Message = "Membro cadastrado com sucesso";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<MemberModel>> EditMember(MemberEditDto memberEditDto)
    {
        ResponseModel<MemberModel> response = new ResponseModel<MemberModel>();
        try
        {
            var member = await _context.Members
                .Include(x => x.Departament)
                .FirstOrDefaultAsync(x => x.Id == memberEditDto.Id);

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(x => x.Id == memberEditDto.Departament.Id);

            if (member is null)
            {
                response.Message = "Membro não encontrado";
            }

            if (departament is null)
            {
                response.Message = "Departamento não encontrado";
            }

            member.Name = memberEditDto.Name;
            member.LastName = memberEditDto.LastName;
            member.Departament = departament;

            _context.Update(member);
            await _context.SaveChangesAsync();

            response.Data = member;
            response.Message = "Membro atualizado com sucesso!";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<MemberModel>> DeleteMember(int memberId)
    {
        ResponseModel<MemberModel> response = new ResponseModel<MemberModel>();
        try
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == memberId);
            if (member is null)
            {
                response.Message = "Departamento não encontrado!";
                return response;
            }

            _context.Remove(member);
            await _context.SaveChangesAsync();

            response.Message = "Membro excluído com sucesso!";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }
}