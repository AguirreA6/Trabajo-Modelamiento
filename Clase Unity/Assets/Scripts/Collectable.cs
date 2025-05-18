using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiona con " + other.name);

        move myobject = other.GetComponent<move>();
        myobject.cambiaObjeto = true;
        Destroy(this.gameObject);
    }
}
