using UnityEngine;
using System.Collections;

public class resistorController : MonoBehaviour {
    public float x = 0.0f;
    public float y = 0.0f;
    public float z = 0.0f;
    GameObject res = new GameObject();
    Vector3 pos,inicio;
    void OnMouseDown()
    {
        if (pos != new Vector3(-0.5f, 0, -6))
        {
            
            pos = new Vector3(-0.5f,0, -6);
            transform.Translate(pos);
        }
      
    }
    // Use this for initialization
    void Start ()
    {
       
        pos = new Vector3(x, y, z);
        transform.Translate(pos);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    
}
