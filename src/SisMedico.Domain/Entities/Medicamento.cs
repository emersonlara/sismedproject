﻿using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Medicamento : EntityBase
{
    public Medicamento() { }

    //MedicamentoId;Descricao;Generico;IdGenerico

    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public string Generico { get; set; }
    public int CodigoGenerico { get; set; }


}
