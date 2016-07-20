using UnityEngine;
using System.Collections;

public class Instanciador : MonoBehaviour {

	public GameObject resistor;
	public GameObject fonte;
	public GameObject jumper;

	public Vector3 posicaoInicial;

	private int qntResistores;
	private int qntFontes;
	private int qntJumpers;

	private bool colocandoJumper;
	private bool terminal1Selected = false;
	private Vector3 posicao1;
	private Vector3 posicao2;

	public Instanciador (){
		qntResistores = 0;
		qntFontes = 0;
		qntJumpers = 0;
	}
	public void NovoResitor_Clicked(){
		InserirComponente (resistor, ++qntResistores, posicaoInicial);
	}

	public void NovaFonte_Clicked(){
		InserirComponente (fonte, ++qntFontes,posicaoInicial );
	}

	public void NovoJumper_Clicked(){
		colocandoJumper = true;
	}

	public void InserirComponente(GameObject componete, int id, Vector3 position) {
		GameObject goinserido = (GameObject) Instantiate (
			componete,
			position,
			Quaternion.identity);

		goinserido.name = componete.name + " " + id.ToString ();
	}

	void Update(){
		if (colocandoJumper) {
			
			if (Input.GetMouseButtonDown (0)) {
				if (!terminal1Selected) {
					Debug.Log ("Selecione o local do primeiro terminal");

					//WARNING: o metodo abaixo nao funciona mto bem com camera perspectiva
					posicao1 = Camera.main
						.ScreenToWorldPoint (Input.mousePosition); //posicao do mouse
					posicao1.z = 0;
					terminal1Selected = true;

				} else {
					Debug.Log ("Selecione o local do segundo terminal");

					posicao2 = Camera.main
						.ScreenToWorldPoint (Input.mousePosition); //posicao do mouse
					posicao2.z = 0;
					//Para cada item dentro do jumper
					foreach (Transform item in jumper.GetComponentsInChildren<Transform>()) {
						if (item.name.Equals ("Fio")) {
							Debug.Log ("Fio");
							item.position = new Vector3(
								(posicao1.x+posicao2.x)/2,
								(posicao1.y+posicao2.y)/2,
								-1f);

							item.localScale = new Vector3 (
								0.25f,Vector3.Distance(posicao1,posicao2) / 2, 0.25f);				
							//TODO: Rotacionar Jumper
//							Debug.Log(Vector3.Angle(posicao1,posicao2));
//							item.rotation = new Quaternion(0f,0f,
//								90f,
//								0f);

						} else if (item.name.Equals ("Terminal Positivo")) {
							item.position = posicao1;
						} else if (item.name.Equals ("Terminal Negativo")) {
							item.position = posicao2;
						}

					}

					InserirComponente(
							jumper,
							++qntJumpers,
						new Vector3(0f,0f,0f));
					
					colocandoJumper = false;
				}
				
			}

		}

	}
}
