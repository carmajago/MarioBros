using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float aceleracion=10f;
    public float fuerzaSalto = 10f;
    public float velMaximaX=4f;
    public float velMaximaY = 4f;


    private Rigidbody2D rb2D;
    private IsSueloController pies;

    private double tiempoSubida;
    private double tiempobajada;
    private bool bandera = false;
    private bool bandera2 = false;


    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
        pies = GetComponentInChildren<IsSueloController>();
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");


        
        tiempoSalto();
        mover(x);
        if (Input.GetButtonDown("Jump") && pies.isSuelo)
        {
            
            tiempoSubida = Time.time;
            saltar();
            
        }
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -velMaximaX, velMaximaX), Mathf.Clamp(rb2D.velocity.y, -velMaximaY, velMaximaY));

    }


    private void mover(float x)
    {
        rb2D.AddForce(Vector2.right * x * Time.deltaTime * aceleracion * 100f);

    }

    private void saltar()
    {
        rb2D.AddForce(Vector2.up  * Time.deltaTime * fuerzaSalto * 100f,ForceMode2D.Impulse);
        bandera2 = true;
    }

    void tiempoSalto()
    {
        if(rb2D.velocity.y<0 && !pies.isSuelo && !bandera)
        {
            bandera = true;
            tiempoSubida = Time.time - tiempoSubida;
            
           tiempobajada = Time.time;
            //Debug.Log("subida:" + tiempoSubida);
            tiempoSubida = 0;
        }
        if (pies.isSuelo && bandera2)
        {
            bandera = false;
            bandera2 = false;
            tiempobajada = Time.time - tiempobajada;
        
           // Debug.Log("bajada: "+tiempobajada);
        }
        if (rb2D.velocity.y != 0)
            Debug.Log(rb2D.velocity);
    }

}
