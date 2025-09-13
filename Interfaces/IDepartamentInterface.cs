using ChurchApi.DTOs.Departament;
using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IDepartamentInterface
{
    Task<ResponseModel<List<DepartamentModel>>> GetDepartaments();
    Task<ResponseModel<DepartamentModel>> GetDepartamentById(int departamentId);

    Task<ResponseModel<DepartamentModel>> CreateDepartament(DepartamentCreateDTO departamentCreateDto);
    
    Task<ResponseModel<DepartamentModel>> EditDepartament(DepartamentEditDTO departamentEditDto);
    
    Task<ResponseModel<DepartamentModel>> DeleteDepartament(int departamentId);
    
}