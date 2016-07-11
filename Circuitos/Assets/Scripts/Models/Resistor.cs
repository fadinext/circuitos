using UnityEngine;
using System.Collections;

public class Resistor {

	public float resistencia;
	public float tolerancia;
	public Furo[] terminais;

	//TODO: criar propriedades corrente e tensao
	//Colocar no setter prase alterar 1 alterar o outro
	public double corrente = 0;
	public double tensao = 0;



	public Resistor(float Resistencia, float Tolerancia, Furo[] Terminais = null){
		this.resistencia = Resistencia;
		this.tolerancia = Tolerancia;
		this.terminais = Terminais;
	}
}
