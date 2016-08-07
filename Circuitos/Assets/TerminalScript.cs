using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

	public int no_id = -1;
	public bool terminalisPositivo = false;
	void OnCollisionEnter(Collision col){

		if (col.gameObject.name.StartsWith ("Furo")) {
			string nome = col.transform.parent.name;

			//Se colidi com um componente adiciono ele ao GM
			if (col.transform.parent.tag.Equals ("Componente")) {
				ComponenteEletrico colidido = col.transform.parent.GetComponent<ComponenteEletrico> ();
				GM.instance.AdicionarComponente (colidido);

				if (col.transform.name.Contains ("Positivo")) {
					no_id = GM.instance.GerarNovoNo();
					colidido.noPositivo = no_id;
					GM.instance.AdicionarNo (no_id);

				} else if(col.transform.name.Contains("Negativo") ){
					no_id = GM.instance.GerarNovoNo();
					colidido.noNegativo = no_id;
					GM.instance.AdicionarNo (no_id);
				}
					
			}

			//se foi com a protoboard obtenho o numero do no da protoboard
			if (nome.Contains("Coluna")) {
				int.TryParse (
					nome.Substring (
						nome.IndexOf ("(") + 1,
						nome.IndexOf (")") - nome.IndexOf ("(") - 1),
					out no_id);
				GM.instance.AdicionarNo (no_id);
			}


			//Se eu sou um componente vou me adicionar ao manager
			if (transform.parent.tag.Equals ("Componente")) {
				ComponenteEletrico myself = transform.parent.GetComponent<ComponenteEletrico> ();
				GM.instance.AdicionarComponente (myself);
			}

			if (transform.parent.tag.Equals ("Fio")) {
				transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo? no_id:-no_id);
				transform.parent.BroadcastMessage ("UnirNos");
			}
			else {
				transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo? no_id:-no_id);
			}
	
		}
	}
}
