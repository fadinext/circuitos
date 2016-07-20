using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Circuito {


	public string nome { get; set; }
	public IList<ComponenteEletrico> componentes { get;	set; }
	public SimuladorCircuito simulador;


	public Circuito(string Nome) {
		componentes = new List<ComponenteEletrico> ();
		simulador = new SimuladorCircuito (this);
		this.nome = Nome;
	}

	//TODO: metodo para verificar circuito aberto

	public void resolverCircuito(){
		
	}


}
