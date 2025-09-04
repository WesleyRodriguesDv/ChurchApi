using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IDepartamentInterface
{
    Task<ResponseModel<List<DepartamentModel>>> GetDepartaments();
    Task<ResponseModel<DepartamentModel>> GetDepartamentById(int departamentId); 
}