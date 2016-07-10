using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {

    private float speed = 2.0f;
    public float minX = -360.0f;
    public float maxX = 360.0f;
    private float zoomSpeed = 2.0f;
    public float sensX = 150.0f;
    public float sensY = 150.0f;
    float rotationY = -55.0f;
    float rotationX = 180.0f;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //rotação
        if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        //zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
        //movimento
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}
