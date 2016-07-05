using UnityEngine;
using System.Collections;

public class Protoboard {
    
	Furo[,] furos;
	int largura;
	int altura;

	public Protoboard(int largura = 20, int altura = 5) {
		this.largura = largura;
		this.altura = altura;

		furos = new Furo[largura,altura];

		for (int x =0; x < largura; x++) {
			for(int y = 0; y < altura; y++) {
				furos[x,y] = new Furo(this,x,y);
			}
		}
		Debug.Log ("Protoboard criada com " + (largura*altura) 
			+ " furos.");
	}
	public Furo GetFuroAt(int x, int y){
		if (x > largura || x < 0 ||
		    y > altura || y < 0) {
			Debug.LogError ("Furo(" + x + "," + y + ")" +
			" fora de alcance.");
			return null;
		}
		return furos [x, y];
	}
}
