using UnityEngine;
using System.Collections;

public class Movimentador : MonoBehaviour {


	private Transform comp_selecionado = null;

	void Update(){
		
		//TODO: criar pequeno menu para o componente ao clica-lo com opcoes
		//Arrastar, valores etc....
		if (Input.GetMouseButtonDown (1)) { //Botao esquerdo clicado
			 comp_selecionado = selecionarComponente();
		}

		if (comp_selecionado != null) {
			arrastar (comp_selecionado);
		}
			

	}

	private void arrastar(Transform componente){
		
		//WARNING: o metodo abaixo nao funciona mto bem com camera perspectiva
		Vector3 curposition = Camera.main
			.ScreenToWorldPoint (Input.mousePosition); //posicao do mouse
		curposition.z = 0; //corige para o z valer 0
		componente.position = curposition; //move para a posicao atual
	}

	private Transform selecionarComponente(){
		//se tiver alguem selecionado solta ele
		if (comp_selecionado != null) {
			return null;
		}
			
		RaycastHit hit; //objeto que sera atingido pelo raio
		Ray ray = Camera.main
			.ScreenPointToRay (Input.mousePosition); //lança um raio

		//se atingiu um componente
		if (Physics.Raycast (ray, out hit) &&
			hit.collider.gameObject.transform.parent
			.tag.Equals("Componente"))
		{
			return hit.collider.gameObject.transform.parent;
		}

		return null; //se nao del ali em cima então retorn null
	}

}
