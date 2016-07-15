using UnityEngine;
using System.Collections;

public class FonteCC : MonoBehaviour {
    public enum FonteCCType
    {
        Corrente,
        Tensao
    }
    FonteCCType type = FonteCCType.Tensao;
    public float corrente = 0;
    public float tensao = 0;
    public FonteCC(float Corrente = 0,float Tensao = 0)//se o valor nao for passado considera-se 0
    {
        this.corrente = Corrente;
        this.tensao = Tensao;
    }


}
