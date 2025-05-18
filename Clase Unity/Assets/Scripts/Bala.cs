
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 5f;
    public float posZ = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.z > posZ)
        {
            Destroy(this.gameObject);
        }
    }
}
