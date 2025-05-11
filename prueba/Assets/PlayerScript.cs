using UnityEngine;

public class PlayerScript : MonoBehaviour{
    //MOvimiento y sprint
    public float speed;
    public float minSpeed=15f;
    public float maxSpeed=25f;

    //Salto
    public float JumpForce=5f;
    private Rigidbody getJump;

    //Parche para evitar salto infinito
    public bool isGrounded;

    //MOver la cámara
    public float sensibility = 2f;
    public float limitX = 45;
    public Transform camara;
    public float rotationX;
    public float rotationY;

    // Start es llamado en el primer frame
    void Start(){
        getJump = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;//Puntero del ratón en el medio de la pantalla
        Cursor.visible = false;//Esconder puntero
    }

    // Update es llamado cada frame
    void Update(){
        // Movimiento
        float forwardBackwards = Input.GetAxis("Horizontal");
        float rightOrleft = Input.GetAxis("Vertical");
        
        if(Input.GetKey(KeyCode.LeftControl)){
            speed=maxSpeed;
        }else{
            speed=minSpeed;
        }
        transform.Translate(new Vector3(forwardBackwards, 0, rightOrleft) *Time.deltaTime*speed);

        //Salto
        if (Input.GetKeyDown(KeyCode.Space)){
            jump();
        }

        //Cámara
        rotationX += -Input.GetAxis("Mouse Y") * sensibility;//Restar a X el inverso de Y
        rotationX=Mathf.Clamp(rotationX, -limitX, limitX);//Estabilizar la cámara para que no haya drift
        camara.localRotation = Quaternion.Euler(rotationX, 0, 0);//Para que sepa sobre el eje que debe girar
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X")*sensibility, 0);//Para el eje y, rotamos al propio jugador

    }
    
    public void jump(){
        if (isGrounded){//Comprobar que esté en el suelo para volver a saltar
            getJump.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    //Arrglo de bug para que no salte infinitamente
    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Ground"){//Este tag se agrega en unity en el objeto ground
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
}
