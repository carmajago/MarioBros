using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{


    public float fallMultuplier;
    public float velocidadSalto;
    public float tiempoSalto;

    private float fuerzasalto;
    private float tiempo = 0;
    private Rigidbody2D rb2D;
    private IsSueloController sueloController;
    private bool bandera = false;

    void Awake()
    {
        fuerzasalto = velocidadSalto;

        sueloController = GetComponentInChildren<IsSueloController>();

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            tiempo = Time.time;
            bandera = false;
        }


        if (rb2D.velocity.y < 0)
        {
            if (!bandera)
            {


              //  Debug.Log("Tiempo: " + (Time.time - tiempo));
                bandera = true;
            }
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultuplier - 1) * Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Jump") && sueloController.isSuelo )//&& Time.time < (tiempo + tiempoSalto) && sueloController.isSuelo)
            {
                if (rb2D.velocity.y >= 0)
                {
                    rb2D.velocity -= Vector2.up * Physics2D.gravity.y * (fuerzasalto - 1) * Time.deltaTime;
                    Debug.Log(rb2D.velocity.y); 
                    // fuerzasalto = 0;
                }
            }
        }






    }

    IEnumerator calcularFuerzaSalto()
    {
        fuerzasalto = velocidadSalto;

        //float aux = fuerzasalto / (tiempoSalto * 10);
        //while (fuerzasalto > 0)
        //{   
        //    fuerzasalto -= aux;
        //    yield return new WaitForSeconds(0.1f);
        //}
        //fuerzasalto = 0;
        yield return null;
    }

}


