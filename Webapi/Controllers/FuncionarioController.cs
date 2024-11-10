using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;
using WebAPI.Service.FuncionarioService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiseResponse<List<FuncionarioModel>>>> GetFuncionaSrios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiseResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            ServiseResponse<FuncionarioModel> serviseResponse = await _funcionarioInterface.GetFuncionarioById(id);

            return Ok(serviseResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiseResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novofuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novofuncionario));
        }

        [HttpPut]

        public async Task<ActionResult<ServiseResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadofuncionario)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = await _funcionarioInterface.UpdateFuncionario(editadofuncionario);

            return Ok(serviseResponse);
        }


        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiseResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = await _funcionarioInterface.InativaFuncionario(id); 

            return Ok(serviseResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiseResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiseResponse<List<FuncionarioModel>> serviseResponse = await _funcionarioInterface.DeleteFuncionario(id); 

            return Ok(serviseResponse);

        }


    }
}
