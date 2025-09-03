using ChurchApi.Models;

namespace ChurchApi.Interfaces;

public interface IDepartamentInterface
{
    Task<ResponseModel<List<DepartamentModel>>> GetDepartaments();
    Task<ResponseModel<List<DepartamentModel>>> GetDepartamentsForIdMember(int MemberId);
    Task<ResponseModel<DepartamentModel>> GetDepartamtsForId(int DepartamentId); 
}