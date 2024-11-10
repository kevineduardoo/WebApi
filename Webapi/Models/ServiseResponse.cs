using WebAPI.Service.FuncionarioService;

namespace Webapi.Models
{
    public class ServiseResponse<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;

        
    }
}
