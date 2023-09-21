using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public  float velocidade = 5f;
    public float rotvelocidade = 1f;
    public float gravidade = 5f;
    CharacterController charactercontroller;

    void Start ()
    {
       // charactercontroller = GetComponent<CharacterController>();

    }
  



    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Horizontal") ;
        float x = Input.GetAxis("Vertical") ;
       
        Vector3 dir = new Vector3 (x,0,0) * velocidade;

        transform.Translate (dir * Time.deltaTime);
        transform.Rotate (new Vector3 (0 , y * rotvelocidade , 0));




    }
}
