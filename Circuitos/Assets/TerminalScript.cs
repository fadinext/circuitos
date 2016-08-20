﻿using UnityEngine;
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
			
				//Componente com componente
				if (col.transform.parent.tag.Equals ("Componente")) {
					//Adiciono o colidido ao GM. E atibuo valores aos nós
					ComponenteEletrico colidido = col.transform.parent.GetComponent<ComponenteEletrico> ();
					GM.instance.AdicionarComponente (colidido);

					if (col.transform.name.Contains ("Positivo")) {
						terminalisPositivo = true;
						if (colidido.noPositivo.Equals (-1)) {
							no_id = GM.instance.GerarNovoNo ();
							colidido.noPositivo = no_id;
							GM.instance.AdicionarNo (no_id);
						} else {
							no_id = colidido.noPositivo;
						}
						colidido.transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo ? no_id : -no_id);

					} else if (col.transform.name.Contains ("Negativo")) {
						terminalisPositivo = false;
						if (colidido.noNegativo.Equals (-1)) {
							no_id = GM.instance.GerarNovoNo ();
							colidido.noNegativo = no_id;
							GM.instance.AdicionarNo (no_id);
						} else {
							no_id = colidido.noNegativo;
						}
						colidido.transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo ? no_id : -no_id);
					}


					//Componente com fio:
				} else if (col.transform.parent.tag.Equals ("Fio")) {
					ComponenteConector colidido = col.transform.parent.GetComponent<ComponenteConector> ();

					if (colidido.noPrincipal.Equals (-1)) {
						no_id = GM.instance.GerarNovoNo ();
						colidido.noPrincipal = no_id;
						GM.instance.AdicionarNo (no_id);
					} else {
						no_id = colidido.noPrincipal;
					}
					transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo ? no_id : -no_id);
					colidido.transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo ? no_id : -no_id);
				}

				//Se sou um fio
			} else if (transform.parent.tag.Equals ("Fio")) {
				ComponenteConector myself = transform.parent.GetComponent<ComponenteConector> ();
				no_id = myself.noPrincipal.Equals (-1) ? GM.instance.GerarNovoNo () : myself.noPrincipal;
				GM.instance.AdicionarNo (no_id);

				//Fio com componente
				if (col.transform.parent.tag.Equals ("Componente")) {
					//TODO: Doing at this point
					ComponenteEletrico colidido = col.transform.parent.GetComponent<ComponenteEletrico> ();
					GM.instance.AdicionarComponente (colidido);

					if (col.transform.name.Contains ("Positivo")) {
						if (colidido.noPositivo.Equals (-1)) {
							colidido.noPositivo = no_id;
						} else {
							myself.noParaUnir = colidido.noPositivo;
							//TODO: Como vou uni-los?
							//myself.BroadcastMessage ("UnirNos");
						}

					} else if (col.transform.name.Contains ("Negativo")) {
						if (colidido.noNegativo.Equals (-1)) {
							colidido.noNegativo = no_id;
						} else {
							myself.noParaUnir = colidido.noNegativo;
							//TODO: Como vou uni-los?
							//myself.BroadcastMessage ("UnirNos");
						}
					}
					//Fio com fio
				} else if (col.transform.parent.tag.Equals ("Fio")) {
					ComponenteConector colidido = col.transform.parent.GetComponent<ComponenteConector> ();

					if (colidido.noPrincipal.Equals (-1)) {
						colidido.noPrincipal = no_id;
						colidido.transform.parent.BroadcastMessage ("UpdateNos", terminalisPositivo ? no_id : -no_id);
					} else {
						myself.noParaUnir = colidido.noPrincipal;
						//TODO: Como vou uni-los?
						//myself.BroadcastMessage ("UnirNos");
					}
				}
			}
		}
	}
}