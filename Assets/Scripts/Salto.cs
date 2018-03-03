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



    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            tiempo = Time.time;
        }


        if (rb2D.velocity.y < 0)
        {
            Debug.Log("Tiempo: " + (Time.time - tiempo));
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultuplier - 1) * Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Jump"))//&& Time.time < (tiempo + tiempoSalto))
            {
                if (rb2D.velocity.y >= 0)
                {

                    rb2D.velocity -= Vector2.up * Physics2D.gravity.y * (velocidadSalto - 1) * Time.deltaTime;
                }
            }
        }






    }

    IEnumerator calcularFuerzaSalto()
    {
        fuerzasalto = velocidadSalto;
        while (fuerzasalto > 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

}


