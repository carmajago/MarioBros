using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditarMapa : MonoBehaviour {

    public  GameObject prefab;
    public float escalaObjetos = 0.8f;
    public Vector3 offset;
	void Start () {

      

    }

    // Update is called once per frame
    void Update () {


        Vector3 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = posicion.x % escalaObjetos;
        float y = posicion.y % escalaObjetos;
        Debug.Log(posicion);
        Vector3 pos;
        if (posicion.x < 0 && posicion.y<0)
        {
             pos = new Vector3((posicion.x - x) - (escalaObjetos / 2), (posicion.y - y) - (escalaObjetos / 2), 0);
        }
        else if (posicion.x >= 0 && posicion.y >= 0)
        {
            pos = new Vector3((posicion.x - x) + (escalaObjetos / 2), (posicion.y - y) + (escalaObjetos / 2), 0);
        }
        else if (posicion.x < 0 && posicion.y > 0)
        {
            pos = new Vector3((posicion.x - x) - (escalaObjetos / 2), (posicion.y - y) + (escalaObjetos / 2), 0);
        }
        else 
        {
            pos = new Vector3((posicion.x - x) + (escalaObjetos / 2), (posicion.y - y) - (escalaObjetos / 2), 0);
        }

            prefab.transform.position= pos+offset;

        if (Input.GetMouseButtonDown(0))
        {
           
          
            Instantiate(prefab,pos+offset,Quaternion.identity);
        }

        
	}
}
