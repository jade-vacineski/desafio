using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Application.Clientes.CriarClientes;
using DesafioItau.src.Domain.Clientes.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioItau.src.Presentation.Controllers.Clientes
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {

        private readonly CriarAdesaoUseCase _useCase;



        public ClientesController(CriarAdesaoUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteRequest request)
        {
            await _useCase.ExecuteAsync(request);
            return Created("ok", null);
        }

    }
}