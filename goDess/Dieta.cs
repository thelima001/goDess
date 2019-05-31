using System;
using System.Collections.Generic;
public class Dieta
{
    private string nome { get; set; }
    
    private List<int> receitas { get; set; }
    private int id { get; set; }

    public Dieta(int id, string nome) {
        this.id = id;
        this.nome = nome;
    }
    public Dieta(string nome, List<int> receitas, int id)
	{
        this.nome = nome;
        this.receitas = receitas;
        this.id = id;
	}
    public int getid()
    {
        return this.id;
    }
    public string getnome()
    {
        return this.nome;
    }
}
