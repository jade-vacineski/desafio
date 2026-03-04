using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioItau.src.Domain.Clientes.repositories;
using DesafioItau.src.Domain.Clientes.Entities;


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
            throw new Exception("CPF já cadastrado");

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