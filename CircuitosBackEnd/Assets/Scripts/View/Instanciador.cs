using UnityEngine;
using System.Collections;

public class Instanciador : MonoBehaviour {

	public GameObject resistor;
	public GameObject fonte;
	public GameObject jumper;
	public GameObject voltimetro;

	public Vector3 posicaoInicial;

	private int qntResistores;
	private int qntFontes;
	private int qntJumpers;
	private int qntVoltimetros;

	private bool colocandoJumper;
	private bool terminal1Selected = false;
	private Vector3 posicao1;
	private Vector3 posicao2;

	public Instanciador (){
		qntResistores = 0;
		qntFontes = 0;
		qntJumpers = 0;
		qntVoltimetros = 0;
	}
	//TODO: Se necessario substituir botoes por uma comboBox
	public void NovoResitor_Clicked(){
		InserirComponente (resistor, ++qntResistores, posicaoInicial);
	}

	public void NovaFonte_Clicked(){
		InserirComponente (fonte, ++qntFontes,posicaoInicial );
	}

	public void NovoJumper_Clicked(){
		colocandoJumper = true;
		Debug.Log ("Selecione o local do primeiro terminal");
	}

	public void NovoVoltimetro_Clicked(){
		InserirComponente (voltimetro, ++qntVoltimetros,posicaoInicial );
	}
	public void InserirComponente(GameObject componete, int id, Vector3 position) {
		GameObject goinserido = (GameObject) Instantiate (
			componete,
			position,
			Quaternion.identity);
		//TODO: criar Parente e setar cada componete como uma Child
		goinserido.name = componete.name + " " + id.ToString ();
	}

	void Update(){
		if (colocandoJumper) {
			
			if (Input.GetMouseButtonDown (0)) {
				//TODO: Colocar codigo daqui em metodo separado
				if (!terminal1Selected) {
					Debug.Log ("Selecione o local do segundo terminal");

					//WARNING: o metodo abaixo nao funciona mto bem com camera perspectiva
					posicao1 = Camera.main
						.ScreenToWorldPoint (Input.mousePosition); //posicao do mouse
					posicao1.z = 0;
					terminal1Selected = true;

				} else {
					//TODO: Apos aprender rotacionar, fazer o terminal acompanhar o local do mouse enquanto seleciona
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
							//TODO: Rotacionar Jumper direito
							//WARNING: BUGADO:
							//float angulo = Mathf.Atan2((posicao2-posicao1).y,(posicao2-posicao1).x)*Mathf.Rad2Deg;
//							float angulo = Vector3.Angle(posicao1,posicao2);
//							Debug.Log(angulo);
//							item.rotation = Quaternion.identity;
//							item.Rotate(new Vector3(0f,0f,angulo));
//							item.RotateAround ((posicao1 + posicao2) / 2, new Vector3(0f,0f,1f), angulo-90);
							item.gameObject.SetActive(false); //deixa desligado enquanto ta bugado

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
					terminal1Selected = false;
				}
				
			}

		}

	}
}
