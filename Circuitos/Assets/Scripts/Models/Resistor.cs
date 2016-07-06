using UnityEngine;
using System.Collections;

public class Resistor {

	public float resistencia;
	public float tolerancia;
	public Furo[] terminais;



	public Resistor(float Resistencia, float Tolerencia, Furo[] Terminais = null){
		this.resistencia = Resistencia;
		this.tolerancia = tolerancia;
		this.terminais = Terminais;
	}
}
