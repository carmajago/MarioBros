using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float aceleracion=10f;
    public float fuerzaSalto = 10f;
    public float velMaximaX=4f;
    public float velMaximaY = 4f;


    private Rigidbody2D rb2D;
    private Animator animator;
    private Vector3 escalaMario;
    void Awake () {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        escalaMario = transform.localScale;
	}
	
    
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");



        animator.SetFloat("VelocidadX", Mathf.Abs(rb2D.velocity.x));
        animator.SetFloat("VelocidadY", Mathf.Abs(rb2D.velocity.y));


        if (rb2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(escalaMario.x,escalaMario.y,escalaMario.z);
        }
        else if(rb2D.velocity.x <0)
        {
            transform.localScale = new Vector3(-escalaMario.x, escalaMario.y, escalaMario.z);
        }

        mover(x);
     
        rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -velMaximaX, velMaximaX), Mathf.Clamp(rb2D.velocity.y, -velMaximaY, velMaximaY));

    }


    private void mover(float x)
    {
        rb2D.AddForce(Vector2.right * x * Time.deltaTime * aceleracion * 100f);

    }





}
