using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject miObjeto;
    public GameObject miOtroObjeto;
    public bool cambiaObjeto = false;

    //Mover camara
    public float sensibilidad = 1000f;
    private float rotX = 0f;
    private float rotY = 0f;

    //Cambio de Color
    public Color colorNuevo = Color.red; 
    private Renderer rend;



    public float distanciaDash = 5f;      // Qué tan lejos hace el dash
    public float duracionDash = 0.2f;     // Duración del dash en segundos
    private bool estaDashing = false;
    private float tiempoDash = 0f;

    private Vector3 direccionDash;
    private Rigidbody rb;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("No se encontró Renderer en el objeto.");
        }

        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cambiaMiObjeto();
        }



        if (Input.GetMouseButton(1)) 
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

            rotX -= mouseY;
            rotY += mouseX;

            rotX = Mathf.Clamp(rotX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
        }

        if (!estaDashing && Input.GetKeyDown(KeyCode.Space))
        {
            // Iniciar dash hacia adelante según la orientación del personaje
            direccionDash = transform.forward.normalized;
            estaDashing = true;
            tiempoDash = 0f;
        }

        if (estaDashing)
        {
            tiempoDash += Time.deltaTime;
            if (tiempoDash < duracionDash)
            {
                // Mover personaje rápidamente hacia adelante
                rb.MovePosition(rb.position + direccionDash * (distanciaDash / duracionDash) * Time.deltaTime);
            }
            else
            {
                estaDashing = false; // Finalizar dash
            }
        }
    }

    private void cambiaMiObjeto()
    {
        if (cambiaObjeto)
        {
            miOtroObjeto.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
            Instantiate(miOtroObjeto);
        }
        else
        {
            miObjeto.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.7f);
            Instantiate(miObjeto);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boton"))
        {
            if (rend != null)
            {
                rend.material.color = colorNuevo;
            }
        }
        
    }
}
