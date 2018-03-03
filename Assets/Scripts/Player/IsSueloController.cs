using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSueloController : MonoBehaviour {

    public bool isSuelo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSuelo = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isSuelo = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isSuelo = false;
    }
    private void Update()
    {
        if (!isSuelo)
        {

        }
    }
}
