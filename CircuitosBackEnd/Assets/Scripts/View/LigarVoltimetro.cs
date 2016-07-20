using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LigarVoltimetro : MonoBehaviour {

	public bool ligado = false;
	public Gerenciador gerenciador;

	private int no_atual;
	private int proximo_no;
	private IList<GameObject> Componentes;
	private GameObject Atual;

	void Start() {
		
	}
	// Use this for initialization
	void OnMouseDown(){
		Debug.Log ("Voltimetro ligado: "+ligado.ToString());
		ligado = !ligado; //switch on off

		if (ligado) { //se ligou ele
			gerenciador = new Gerenciador();

			//numero do no onde ta o gnd do voltimetro
			int no_de_conexao = 0;

			//TODO: WARNING: Usar o transform.root pode dar bugs dps
			GameObject voltimetro = transform.root.gameObject;
			GameObject terminal_negativo;
			GameObject terminal_positivo;

			//obtendo referencias de qm sao os terminais
			foreach (Transform item in voltimetro.GetComponentsInChildren<Transform>()) {
				if (item.name.EndsWith ("Negativo")) {
					Debug.Log ("O item: " + item.ToString () + " é o gnd.");
					terminal_negativo = item.gameObject;
				}
				else if (item.name.EndsWith ("Positivo")) {
					Debug.Log ("O item: " + item.ToString () + " é o gnd.");
					terminal_positivo = item.gameObject;
				}
			}
						
			/*Nó Atual = 0;
			 * 
			 * Cada x representa um componente(fonte ou resistor...)
			 * 'o' representa o voltimetro
			 * os numeros representa a id do nó
			 * 
			 * 				|-----x3----|
			 *     |---x2---|           |--|--x5-|
			 *     |		|-----x4----|  |     |
			 * 	|--|		   			   |     |
			 *  o  x1                      x6    x7       
			 *  |--|                       |     |        
			 *  '0'|-----------------x8----|-----|        
			 *
			 **********METODO PARA PERCORRER O CIRCUITO e ADICIONAR OS COMPONENTES********
			 *Começando no negativo do voltimetro
			 *Atual = o
			 *Componentes = x1 e x8
			 *Restantes = x2,x3,x4,x5,x6,x7
			 *
			 *Atual = x1
			 *Componentes = x8, x2
			 *Restantes = x3,x4,x5,x6,x7
			 *
			 *Atual = x8
			 *Componentes = x2, x6, x7
			 *Restantes = x3,x4,x5
			 *
			 *Atual = x2
			 *Componentes = x6, x7, x3, x4
			 *Restantes = x5
			 *
			 *Atual = x6
			 *Componentes = x7, x3,x4,x5
			 *Restantes = 0
			 *
			 *Atual = x7
			 *Componentes = x3,x4,x5
			 *Restantes = 0
			 *
			 *Atual = x3
			 *Componentes = x4,x5
			 *Restantes = 0
			 *
			 *Atual = x4
			 *Componentes = x5
			 *Restantes = 0
			 *
			 *Atual = x5
			 *Componentes = 0
			 *Restantes = 0
			 *
			 **********TODOS OS COMPONENTES FORAM ADICIONADOS***********
			 */

			 no_atual = 0;
			 proximo_no = no_atual+1;
			 Componentes = GetComponentesConectados(no_atual);
			 
			 while(Componentes.Count != 0){
			 	Atual = Componentes[0];
				AdicionarComponente(Atual.name,GetTipo(Atual), no_atual, proximo_no,GetValor(Atual));
			 	Componentes = GetComponentesConectados(proximo_no);
			 }
		}
	}

	//TODO: Implementar
	private IList<GameObject> GetComponentesConectados(int no_id){
		IList<GameObject> conectados = new List<GameObject> ();




		return conectados;
	}

	//TODO: Implementar
	private void AdicionarComponente(
		string nome,
		ComponenteEletrico.Tipos tipo,
		int no_negativo,
		int no_positivo,
		double valor) {



	}

	//TODO: Implementar
	private ComponenteEletrico.Tipos GetTipo(GameObject componente){
		ComponenteEletrico.Tipos tipo = ComponenteEletrico.Tipos.Resistor;


		return tipo;
	}

	//TODO: Implementar
	private double GetValor(GameObject componente){
		double valor = 2;


		return valor;
	}
}
