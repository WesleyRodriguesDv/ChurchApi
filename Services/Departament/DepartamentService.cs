using Azure.Identity;
using ChurchApi.Data;
using ChurchApi.DTOs.Departament;
using ChurchApi.Interfaces;
using ChurchApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public async Task<ResponseModel<DepartamentModel>> CreateDepartament(DepartamentDTO departamentDTO)
    {
        ResponseModel<DepartamentModel> response = new ResponseModel<DepartamentModel>();
        try
        {
            var departament = new DepartamentModel()
            {
                Name = departamentDTO.Name
            };

            _context.Add(departament);
            await _context.SaveChangesAsync();
            response.Message = "Departamento criado com sucesso! ";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }            
    }
    
    public async Task<ResponseModel<DepartamentModel>> EditDepartament(DepartamentDTO departamentDto)
    {
        ResponseModel<DepartamentModel> response = new ResponseModel<DepartamentModel>();
        try
        {
            var departament = await _context.Departaments.FirstOrDefaultAsync(x => x.Id == departamentDto.Id);
            if (departament == null)
            {
                response.Message = "Departamento não encontrado!";
                response.Status = false;
            }

            departament.Name = departamentDto.Name;
            _context.Update(departament);
            await _context.SaveChangesAsync();

            response.Message = "Departamento alterado com sucesso";
            return response;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<DepartamentModel>> DeleteDepartament(int departamentId)
    {
        ResponseModel<DepartamentModel> response = new ResponseModel<DepartamentModel>();
        try
        {
            var departament = await _context.Departaments.FirstOrDefaultAsync(x => x.Id == departamentId);
            if (departament == null)
            {
                response.Message = "Departamento não encontrado";
                response.Status = false;
            }

            _context.Remove(departament);
            await _context.SaveChangesAsync();
            response.Message = "Departamento deletado com sucesso!";
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