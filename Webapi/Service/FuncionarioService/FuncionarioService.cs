using Microsoft.EntityFrameworkCore;
using Webapi.DataContext;
using Webapi.Models;

namespace WebAPI.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiseResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novofuncionario)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = new ServiseResponse<List<FuncionarioModel>>();

            try
            {
                if (novofuncionario == null)
                {
                    serviseResponse.Dados = null;
                    serviseResponse.Mensagem = "Informar dados!";
                    serviseResponse.Sucesso = false;
                    
                    return serviseResponse;
                }

                _context.Add(novofuncionario);
                await _context.SaveChangesAsync();

                serviseResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }
            return serviseResponse;
        }

        public async Task<ServiseResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = new ServiseResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);


                if (funcionario == null)
                {
                    serviseResponse.Dados = null;
                    serviseResponse.Mensagem = "Usuário não localizado!";
                    serviseResponse.Sucesso = false;

                    return serviseResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviseResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }

            return serviseResponse;

        }

        public async Task<ServiseResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiseResponse<FuncionarioModel>serviseResponse = new ServiseResponse<FuncionarioModel>();
            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviseResponse.Dados = null;
                    serviseResponse.Mensagem = "Usuário não localizado!";
                    serviseResponse.Sucesso = false;
                }
                serviseResponse.Dados = funcionario;

            }
            catch(Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }
            return serviseResponse;
        }

        public async Task<ServiseResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = new ServiseResponse<List<FuncionarioModel>>();

            try
            {
                serviseResponse.Dados = _context.Funcionarios.ToList();

                if(serviseResponse.Dados.Count == 0)
                {
                    serviseResponse.Mensagem = "Nenhuma dado encontrado!";
                }


            }catch(Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }

            return serviseResponse;
        }

        public async Task<ServiseResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = new ServiseResponse<List<FuncionarioModel>>();

            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                
                if(funcionario == null)
                {
                    serviseResponse.Dados = null;
                    serviseResponse.Mensagem = "Usuário não localizado!";
                    serviseResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario); 
                await _context.SaveChangesAsync();

                serviseResponse.Dados = _context.Funcionarios.ToList();

            }
            catch(Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }

            return serviseResponse;
        }

        public async Task<ServiseResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = new ServiseResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviseResponse.Dados = null;
                    serviseResponse.Mensagem = "Usuário não localizado!";
                    serviseResponse.Sucesso = false;

                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviseResponse.Dados = _context.Funcionarios.ToList();
            }
            catch(Exception ex)
            {
                serviseResponse.Mensagem = ex.Message;
                serviseResponse.Sucesso = false;
            }

            return serviseResponse;

        }
    }
}
