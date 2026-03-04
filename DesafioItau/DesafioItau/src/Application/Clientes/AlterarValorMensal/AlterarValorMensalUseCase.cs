using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Domain.exceptions;

namespace DesafioItau.src.Application.Clientes.AlterarValorMensal
{
    public class AlterarValorMensalUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public AlterarValorMensalUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<AlterarValorMensalResponse> ExecuteAsync(long clienteId, AlterarValorMensalRequest request)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);
            if (cliente == null)
                throw new ClienteNaoEncontradoException("Cliente não encontrado.");

            var valorAnterior = cliente.ValorMensal;

            cliente.AlterarValorMensal(request.NovoValorMensal);

            await _clienteRepository.AtualizarAsync(cliente);

            return new AlterarValorMensalResponse
            {
                ClienteId = cliente.Id,
                ValorMensalAnterior = valorAnterior,
                ValorMensalNovo = cliente.ValorMensal,
                DataAlteracao = DateTime.UtcNow,
                Mensagem = "Valor mensal atualizado. O novo valor sera considerado a partir da proxima data de compra."
            };
        }
    }
}
