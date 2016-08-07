using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public List<ComponenteEletrico> Componentes = new List<ComponenteEletrico>();

	public List<int> nos = new List<int>();

	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	public void AdicionarComponente(ComponenteEletrico componente){
		if(!Componentes.Contains(componente)) {
			Componentes.Add (componente);
		}
	}

	public void UnirNos(int no1, int no2){
		Debug.Log ("Unir o " + no1.ToString () + " com o " + no2.ToString ());
		foreach (ComponenteEletrico comp in Componentes) {
			Debug.Log (comp.name);
			//no1 agr substituira todas as posicoes de no1
			if (comp.noPositivo.Equals (no2)) {
				comp.noPositivo = no1;
			}
			if (comp.noNegativo.Equals (no2)) {
				comp.noNegativo = no1;
			}
		}
	}


	public void AdicionarNo(int noId){
		if(!nos.Contains(noId)) {
			nos.Add (noId);
		}
	}

	public int GerarNovoNo(){
		int novo_no;
		novo_no = Random.Range (1, 1000);
		int tentativas = 0;
		while (nos.Contains (novo_no) || tentativas > 500) {
			novo_no = Random.Range (1, 1000);
			tentativas = tentativas + 1;
		}
		return novo_no;
	}
}
