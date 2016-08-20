using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

	public int no_id = -1;
	public bool terminalisPositivo = false;
	void OnCollisionEnter(Collision col){

		if (col.gameObject.name.StartsWith ("Furo")) {
			
			//Se eu sou um componente
			if (transform.parent.tag.Equals ("Componente")) {
				ComponenteEletrico myself = transform.parent.GetComponent<ComponenteEletrico> ();
				GM.instance.AdicionarComponente (myself);


			

				//Se sou um fio
			} else if (transform.parent.tag.Equals ("Fio")) {
				ComponenteConector myself = transform.parent.GetComponent<ComponenteConector> ();
				no_id = myself.noPrincipal.Equals (-1) ? GM.instance.GerarNovoNo () : myself.noPrincipal;
				GM.instance.AdicionarNo (no_id);



			}
		}
	}
}
