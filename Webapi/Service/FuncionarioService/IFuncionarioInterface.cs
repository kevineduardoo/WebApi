using Webapi.Models;

namespace WebAPI.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiseResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiseResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novofuncionario);
        Task<ServiseResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServiseResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<ServiseResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServiseResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
    }
}
