using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{


    public float fallMultuplier;
    public float velocidadSalto;
    public float tiempoSalto=0.4f;

    private float fuerzasalto;
    private float tiempo = 0;
    private Rigidbody2D rb2D;
    private IsSueloController sueloController;
    private bool bandera = false;

    private bool yaSalto = false;

    void Awake()
    {
        fuerzasalto = velocidadSalto;

        sueloController = GetComponentInChildren<IsSueloController>();

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetButtonDown("Jump"))
        {
           
            tiempo = Time.time;
          //  StartCoroutine(calcularFuerzaSalto());
            bandera = false;
           
        }

        if (Input.GetButtonUp("Jump"))
        {
            fuerzasalto = velocidadSalto;
            yaSalto = false;
        }


        if (rb2D.velocity.y < 0)
        {
            yaSalto = true;
            if (!bandera)
            {


                 Debug.Log("Tiempo: " + (Time.time - tiempo));
                bandera = true;
            }
           // rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultuplier - 1) * Time.deltaTime;
        }
        




    }

    IEnumerator calcularFuerzaSalto()
    {

        while (rb2D.velocity.y >= 0)
        {
            if (Input.GetButton("Jump") && Time.time < (tiempo + tiempoSalto))// && sueloController.isSuelo)
            {



                  rb2D.AddForce(Vector2.up * fuerzasalto * Time.deltaTime * 10);
               // rb2D.velocity -=- Vector2.up * velocidadSalto * Time.deltaTime * 10;      
            //  Debug.Log(rb2D.velocity.y); 
                  //  fuerzasalto = fuerzasalto * 0.4f;

            }
            yield return new WaitForSeconds(0.1f);
        }
 
    }

}


