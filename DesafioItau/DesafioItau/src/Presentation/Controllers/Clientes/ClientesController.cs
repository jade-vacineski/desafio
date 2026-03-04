using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Application.Clientes.AlterarValorMensal;
using DesafioItau.src.Application.Clientes.CriarClientes;
using DesafioItau.src.Application.Clientes.SaidaClientes;
using DesafioItau.src.Application.Clientes.SaidaClientes.DesafioItau.src.Application.Clientes.SaidaClientes;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Domain.exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioItau.src.Presentation.Controllers.Clientes
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : Controller
    {

        private readonly CriarAdesaoUseCase _useCase;

        private readonly SaidaClienteUseCase _saidaClienteUseCase;

        private readonly AlterarValorMensalUseCase _alterarValorMensalUseCase;


        public ClientesController(CriarAdesaoUseCase useCase, SaidaClienteUseCase saidaClienteUseCase, AlterarValorMensalUseCase alterarValorMensalUseCase)
        {
            _useCase = useCase;
            _saidaClienteUseCase = saidaClienteUseCase;
            _alterarValorMensalUseCase = alterarValorMensalUseCase;
        }

        [HttpPost("adesao")]
        public async Task<IActionResult> CriarCliente([FromBody] CriarClienteRequest request)
        {
            var response = await _useCase.ExecuteAsync(request);
            return Created("/api/clientes/adesao", response);
        }

        [HttpPost("{clienteId}/saida")]
        public async Task<IActionResult> SairCliente(long clienteId)
        {
            try
            {
                var request = new SaidaClienteRequest(clienteId);

                var response = await _saidaClienteUseCase.ExecuteAsync(request);

                return Ok(response);
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(new
                {
                    erro = ex.Message,
                    codigo = "CLIENTE_NAO_ENCONTRADO"
                });
            }
            catch (ClienteJaInativoException ex)
            {
                return BadRequest(new
                {
                    erro = ex.Message,
                    codigo = "CLIENTE_JA_INATIVO"
                });
            }

        }

        [HttpPut("{clienteId}/valor-mensal")]
        public async Task<IActionResult> AlterarValorMensal(long clienteId, [FromBody] AlterarValorMensalRequest request)
        {
            try
            {
                var response = await _alterarValorMensalUseCase.ExecuteAsync(clienteId, request);
                return Ok(response);
            }
            catch (ClienteNaoEncontradoException ex)
            {
                return NotFound(new
                {
                    erro = ex.Message,
                    codigo = "CLIENTE_NAO_ENCONTRADO"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    erro = ex.Message,
                    codigo = "VALOR_INVALIDO"
                });
            }
        }
    }
}
