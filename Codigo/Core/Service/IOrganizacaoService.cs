﻿using Core.DTO;
using System.Collections.Generic;

namespace Core.Service
{
    public interface IOrganizacaoService
    {
        int Inserir(Organizacao organizacao);
        Organizacao Obter(int IdOrganizacao);
        IEnumerable<Organizacao> ObterTodos();
        void Atualizar(Organizacao organizacao);
        void Remover(int IdOrganizacao);

        IEnumerable<OrganizacaoDTO> ObterPorNomeOrdenadoDescending(string NomeFantasia);

    }
}
