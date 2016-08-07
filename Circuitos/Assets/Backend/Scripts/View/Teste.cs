using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

	private Gerenciador gerenciador;
	void Start () {
		gerenciador = new Gerenciador ();
		gerenciador.AddComponente (ComponenteEletrico.Tipos.Resistor);
		gerenciador.AddComponente (ComponenteEletrico.Tipos.Resistor);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
