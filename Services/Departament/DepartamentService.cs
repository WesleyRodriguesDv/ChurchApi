using Azure;
using ChurchApi.Data;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchApi.Services;

public class DepartamentService:IDepartamentInterface
{
    private readonly AppDbContext _context;

    public DepartamentService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<List<DepartamentModel>>> GetDepartaments()
    {
        ResponseModel<List<DepartamentModel>> response = new ResponseModel<List<DepartamentModel>>();
        try
        {
            var departaments = await _context.Departaments.ToListAsync();
            response.Data = departaments;
            response.Message = "Todos os Departamentos foram listados com sucesso!";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }    
        
    }

    
    
    
    
    
    public Task<ResponseModel<List<DepartamentModel>>> GetDepartamentsForIdMember(int MemberId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<DepartamentModel>> GetDepartamtsForId(int DepartamentId)
    {
        throw new NotImplementedException();
    }
}