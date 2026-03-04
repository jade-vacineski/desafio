using System;
using System.Transactions;
using System.Threading.Tasks;
using DesafioItau.src.Application.Clientes.CriarClientes;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Domain.ContasGraficas.entities;
using DesafioItau.src.Domain.Clientes.Entities;
using DesafioItau.src.Domain.exceptions;
using DesafioItau.src.Domain.Custodias.Entities;
using DesafioItau.src.Domain.ContasGraficas.repositories;
using DesafioItau.src.Domain.Custodias.repositories;

public class CriarAdesaoUseCase
{
    private readonly IClienteRepository clienteRepository;
    private readonly IContaGraficaRepository contaRepository;
    private readonly ICustodiaRepository custodiaRepository;

    public CriarAdesaoUseCase(
        IClienteRepository clienteRepository,
        IContaGraficaRepository contaRepository,
        ICustodiaRepository custodiaRepository)
    {
        this.clienteRepository = clienteRepository;
        this.contaRepository = contaRepository;
        this.custodiaRepository = custodiaRepository;
    }

    public async Task ExecuteAsync(CriarClienteRequest request)
    {
    
        if (await clienteRepository.ExisteCpfAsync(request.Cpf))
            throw new ClienteCpfDuplicadoException();

        var cliente = Cliente.Criar(
            request.Nome,
            request.Cpf,
            request.Email,
            request.ValorMensal
        );

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await clienteRepository.AddAsync(cliente);

            var contaFilhote = ContaGrafica.CriarFilhote(cliente.Id, GerarNumeroConta());
            await contaRepository.AddAsync(contaFilhote);


            var custodiaFilhote = new Custodia(contaFilhote, "FILHOTE");
            await custodiaRepository.AddAsync(custodiaFilhote);

            scope.Complete();
        }
    }

    private string GerarNumeroConta()
    {
        return Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
    }
}
