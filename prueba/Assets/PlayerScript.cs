using UnityEngine;

public class PlayerScript : MonoBehaviour{
    public float speed;
    public float minSpeed=15f;
    public float maxSpeed=25f;

    // Start es llamado en el primer frame
    void Start()
    {
        
    }

    // Update es llamado cada frame
    void Update(){
        // Movimiento
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        if(Input.GetKey(KeyCode.LeftControl)){
            speed=maxSpeed;
        }else{
            speed=minSpeed;
        }

        transform.Translate(new Vector3(x, 0, y)*Time.deltaTime*speed);

    }
}
