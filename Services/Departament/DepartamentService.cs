using ChurchApi.Data;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace ChurchApi.Services.Departament;

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

    public async Task<ResponseModel<DepartamentModel>> GetDepartamentById(int departamentId)
    {
        ResponseModel<DepartamentModel> response = new ResponseModel<DepartamentModel>();
        try
        {
            var departament = await _context.Departaments.FirstOrDefaultAsync(x => x.Id == departamentId);
            if (departament == null)
            {
                response.Message = "Departamento não encontrado";
                return response;
            }

            response.Data = departament;
            response.Message = "Departamento Encontrado";
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