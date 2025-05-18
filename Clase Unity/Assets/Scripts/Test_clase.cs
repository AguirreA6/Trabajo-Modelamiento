using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_clase : MonoBehaviour
{
    public float posX = -2.75f;
    public float posY = 3.5f;
    public float posZ = -21.74f;
    void Start()
    {
        
        //Debug.Log("Hola Mundo Unity Engine");
        //Debug.Log("Mi nombre es:" + name);
        //Debug.Log("Mi posicion en x es:" + transform.position.x);
        //Debug.Log("Mi posicion actual es:" + transform.position);

        transform.position = new Vector3(posX,posY,posZ);
        Debug.Log("Nueva posicion camara:" + transform.position);
    }

    void Update()
    {
        
    }
}
