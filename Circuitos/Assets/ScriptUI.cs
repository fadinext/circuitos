using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptUI : MonoBehaviour {
    public Dropdown dropdown;
    public GameObject res;
    public GameObject fonte;
    public GameObject opcaoC;
    public void Click(Dropdown target)
    {
        if (target.value == 0)
        {
            resistor(res);
        }
        if (target.value == 1)
        {
            Fontecc(fonte);
        }
        if (target.value == 2)
        {
            opcaoc(opcaoC);
        }
    }
    private void resistor(GameObject res)
    {
        Debug.Log("colocar o resistor");
    }
    private void Fontecc(GameObject fonte)
    {
        Debug.Log("colocar a fonte");
    }
    private void opcaoc(GameObject opcaoc)
    {
        Debug.Log("colocar o elemento c");
    }

	void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (0);
		}
	}
}
