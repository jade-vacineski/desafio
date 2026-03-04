using System.Threading.Tasks;
using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Domain.exceptions;

namespace DesafioItau.src.Application.Clientes.CriarClientes
{
    public class CriarClienteUseCase
    {
        public readonly IClienteRepository repository;

        public CriarClienteUseCase(IClienteRepository repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(CriarClienteRequest request)
        {
            if (await repository.ExisteCpfAsync(request.Cpf))
            {
                throw new ClienteCpfDuplicadoException();
            }

            var cliente = Cliente.Criar(
                request.Nome,
                request.Cpf,
                request.Email,
                request.ValorMensal
            );

            await repository.AddAsync(cliente);
        }
    }
}
