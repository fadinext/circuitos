using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	public void UI_StartClicked(){
		Application.LoadLevel("Room");
	}
	public void UI_AboutClicked(){
		//TODO: Implementar cena
		//Application.LoadLevel("SubMenu_About");
		Debug.Log("Falta Implementar Scene_About.");
	}
	public void UI_ExitClicked(){
		Debug.Log("Se tiver numa build isso vai sair, no modo de teste nao..");
		Application.Quit();
	}
}
