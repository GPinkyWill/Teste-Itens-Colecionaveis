using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrescimentoPlanta : MonoBehaviour
{
    float a = 0.15f;
    float i;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3 (a,a,a);
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 0.80f)
        {
            transform.localScale = new Vector3 (a + i,a + i,a + i);
            Debug.Log ("Cresceu");
            i = i + 0.01f;
        }
    }
}
