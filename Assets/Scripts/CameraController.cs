using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float distZoomMin = 20f;
    public float distZoomMax = 75f;
    public float zoomSpeed = 20f;
    public float rotSpeed = 30f;
    public float cameramovspeed = 20f;

    private const float tempoPradraoClique = 0.2f;
    private float ultimoClique;
    private Camera cam;

    // Start is called before the first frame update
    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
        CamRotate();
    }

    void Move ()
    {
        if (Input.GetMouseButton(0))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            Vector3 pos = transform.forward * -mx + transform.right * my;

            transform.position += pos * cameramovspeed * Time.deltaTime;
        }
    }
    void CamRotate ()
    {
        if (Input.GetMouseButton(1))
        {
            float rx = Input.GetAxis("Mouse X");
            float rz = Input.GetAxis("Mouse Y");
            transform.Rotate (new Vector3 (0,rx,rz ) * rotSpeed * Time.deltaTime, Space.Self); 
            
            
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            float tempoDesdeUltimoClique = Time.time - ultimoClique;
             if ( tempoDesdeUltimoClique <= tempoPradraoClique)
        {
            Vector3 rotInicial = new Vector3 (0,0,0);
            //Quaternion rotation = Quaternion.Euler(rotInicial);
            transform.rotation = Quaternion.Euler(rotInicial);
            //transform.rotation = Quaternion.eulerAngles( new Vector3 (0,0,0));
            Debug.Log("DoubleClick");
        }
        ultimoClique = Time.time;
        }
       
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis ("Mouse ScrollWheel");
        float dist = Vector3.Distance (transform.position , cam.transform.position);

        if (dist < distZoomMin && scrollInput > 0.0f )
            {
                return;
            }
        else if (dist > distZoomMax && scrollInput < 0.0f)
            {
                return;
            }
            cam.transform.position += cam.transform.forward * zoomSpeed * scrollInput;
         
    }

    public void FocusOnPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
