using UnityEngine;
using System.Collections;

public class ComponenteEletrico {

	//gerado automaticamente ao inserir
	public string nome { get; set; }

	//Ao se conectar a um no
	public int noPositivo { get; set; }
	public int noNegativo { get; set; }


	public enum Tipos
	{
		FonteDC,
		FonteCC,
		Resistor,
	}

	//selecionado ao inserir
	public Tipos tipo { get; set; }

	//definido em funcao de definicao
	public double valor { get; set; }

	//Dados retornados da simulacao
	public double corrente { get; set; }
	public double tensao { get; set; }

	public ComponenteEletrico(){

	}
}
