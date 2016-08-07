using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gerenciador {

	public Circuito circuito;
	public IList<int> nos_de_conexao;


	public Gerenciador () {
		circuito = new Circuito ("meucircuito");//TODO: pensar num nome melhor
		nos_de_conexao = new List<int>();
	}


	public ComponenteEletrico AddComponente(ComponenteEletrico.Tipos tipo) {
		ComponenteEletrico componente;
		componente = new ComponenteEletrico ();

		circuito.componentes.Add (componente);

		componente.tipo = tipo;
		if (tipo.Equals(ComponenteEletrico.Tipos.Resistor))
			componente.nome = "r" + circuito.componentes.IndexOf(componente).ToString ();
		else
			componente.nome = "v" + circuito.componentes.IndexOf(componente).ToString ();

		return componente;
	}

}
