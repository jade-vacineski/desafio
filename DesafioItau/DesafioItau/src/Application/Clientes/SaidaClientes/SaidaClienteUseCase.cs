using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioItau.src.Application.Clientes.SaidaClientes
{
    using System;
    using System.Threading.Tasks;
    using global::DesafioItau.src.Domain.Clientes.repositories;
    using global::DesafioItau.src.Domain.Custodias.repositories;
    using global::DesafioItau.src.Domain.exceptions;

    namespace DesafioItau.src.Application.Clientes.SaidaClientes
    {
        public class SaidaClienteUseCase
        {
            private readonly IClienteRepository _clienteRepository;
            private readonly ICustodiaRepository _custodiaRepository;

            public SaidaClienteUseCase(
                IClienteRepository clienteRepository,
                ICustodiaRepository custodiaRepository)
            {
                _clienteRepository = clienteRepository;
                _custodiaRepository = custodiaRepository;
            }

            public async Task<SaidaClienteResponse> ExecuteAsync(SaidaClienteRequest request)
            {
                var cliente = await _clienteRepository.ObterPorIdAsync(request.ClienteId);
                if (cliente == null)
                {
                    throw new InvalidOperationException("Cliente não encontrado");
                }

               cliente.Desativar();

                await _clienteRepository.AtualizarAsync(cliente);

                return new SaidaClienteResponse
                {
                    ClienteId = cliente.Id,
                    Nome = cliente.Nome,
                    Ativo = cliente.Ativo,
                    DataSaida = DateTime.UtcNow,
                    Mensagem = "Adesao encerrada. Sua posicao em custodia foi mantida."
                };
            }
        }
    }
}