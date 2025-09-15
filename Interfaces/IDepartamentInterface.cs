using ChurchApi.DTOs.Departament;
using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IDepartamentInterface
{
    Task<ResponseModel<List<DepartamentModel>>> GetDepartaments();
    Task<ResponseModel<DepartamentModel>> GetDepartamentById(int departamentId);

    Task<ResponseModel<DepartamentModel>> CreateDepartament(DepartamentDTO departamentCreateDto);
    
    Task<ResponseModel<DepartamentModel>> EditDepartament(DepartamentDTO departamentDto);
    
    Task<ResponseModel<DepartamentModel>> DeleteDepartament(int departamentId);
    
}