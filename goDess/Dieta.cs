using System;
using System.Collections.Generic;
public class Dieta
{
    private string nome { get; set; }
    private string descricao { get; set; }
    private List<int> receitas { get; set; }
    private int id { get; set; }

    public Dieta(string nome, string descricao, List<int> receitas, int id)
	{
        this.nome = nome;
        this.descricao = descricao;
        this.receitas = receitas;
        this.id = id;
	}
}
