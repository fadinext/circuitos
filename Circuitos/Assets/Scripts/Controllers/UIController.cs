using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject Resistor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	
	}

	void UI_InserirClicked() {
		Instantiate (Resistor, Resistor.transform.position,
			Resistor.transform.rotation);
	}
}
