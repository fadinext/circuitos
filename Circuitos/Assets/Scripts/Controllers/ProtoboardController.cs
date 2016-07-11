using UnityEngine;
using System.Collections;

public class ProtoboardController : MonoBehaviour {


	public Sprite furoSprite; //a imagem de um furo
	public int linhas = 3;
	public int colunas = 5;
	Protoboard protoboard;

	// Use this for initialization
	void Start () {
		protoboard = new Protoboard(linhas,colunas);

		//criando GameObjects para cada furo
		for (int x = 0; x < protoboard.Largura; x++) {
			for (int y = 0; y < protoboard.Altura; y++) {
				Furo furo_data = protoboard.GetFuroAt (x, y);
				GameObject furo_go = new GameObject ();
				furo_go.name = "Furo_" + x + "_" + y;
				furo_go.transform.position = new Vector3 (
					furo_data.X-8f, 16.6f, furo_data.Y-3f);
				furo_go.transform.SetParent (this.transform, true);
				furo_go.AddComponent<SpriteRenderer>();
				furo_go.GetComponent<SpriteRenderer>().sprite = furoSprite;
				furo_go.transform.Rotate(new Vector3 (
					90f, 0f, 0f));
			}
		}

	}


	// Update is called once per frame
	void Update () {
	}

}