using UnityEngine;
using System.Collections;

public class ComponenteEletrico : MonoBehaviour {

	//gerado automaticamente ao inserir
	public string nome;

	//Ao se conectar a um no
	public int noPositivo = -1;
	public int noNegativo = -1;


	public enum Tipos
	{
		FonteDC,
		FonteCC,
		Resistor,
		Jumper
	}

	//selecionado ao inserir
	public Tipos tipo;

	//definido em funcao de definicao
	public double valor;

	//Dados retornados da simulacao
	public double corrente;
	public double tensao;

	void Start(){
		
	}

	public void UpdateNos(int no_id){
		if (no_id > 0) {
			noPositivo = no_id;
		} else {
			noNegativo = -no_id;
		}
	}

	public void UnirNos(){
		if (noPositivo != -1 && noNegativo != -1) {
			GM.instance.UnirNos (noPositivo, noNegativo);
		}
	}
}
