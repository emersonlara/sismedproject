﻿using SisMedico.Domain.Base;

namespace SisMedico.Domain.Farmacia.Entities;

public class Produto : EntityBase
{
    public Guid FornecedorId { get; set; }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    /* EF Relations */
    public Fornecedor Fornecedor { get; set; }
}
