using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

	public int valor = -1;
	void Start(){
		Debug.Log ("oie sou o " + gameObject.name);
	}

	void OnCollisionEnter (Collision col){
		Debug.Log ("Eu colidi");
		if (col.gameObject.name.StartsWith ("Furo")) {
			Debug.Log(col.transform.parent.name.ToString());
		}
	}
}
