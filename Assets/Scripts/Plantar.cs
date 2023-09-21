using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantar : MonoBehaviour
{
    public GameObject Plantacao;
    // public int Inventario.NumberOfSeeds;
    Vector3 plantPosition;
    public PlayerInventory Inventario;

    void Start()
    {
        Inventario = GetComponent<PlayerInventory>();
        
    }
    void Update()
    {
        // Inventario.NumberOfSeeds = GetComponent<PlayerInventory>().Inventario.NumberOfSeeds;
        if (Input.GetKeyDown("space") && Inventario.GetNumSeeds() > 0)
        {
            Debug.Log("Plantou");
            plantPosition = transform.TransformPoint(2, 0, 0);
            Instantiate(Plantacao, plantPosition, transform.rotation);
            Inventario.ReduceSeeds(1);

        }
    }
}
