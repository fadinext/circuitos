using UnityEngine;
using System.Collections;

public class Gerenciador {

	public Circuito circuito;
	// Use this for initialization
	public Gerenciador () {
		circuito = new Circuito ("meucircuito");

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
