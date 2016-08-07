using UnityEngine;
using System.Collections;

public class ComponenteConector : MonoBehaviour {

	//gerado automaticamente ao inserir
	public string nome;

	//Ao se conectar a um no
	public int noPrincipal = -1;
	public int noParaUnir = -1;

	public double corrente;

	void Start(){

	}

	public void UpdateNos(int no_id){
		if (no_id > 0) {
			noPrincipal = no_id;
		} else {
			noParaUnir = -no_id;
		}
	}

	public void UnirNos(){
		if (noPrincipal != -1 && noParaUnir != -1) {
			GM.instance.UnirNos (noPrincipal, noParaUnir);
		}
	}
}
