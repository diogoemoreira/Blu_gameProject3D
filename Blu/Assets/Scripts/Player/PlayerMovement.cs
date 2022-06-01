using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charControl;
    
    public float speed = 3f;
    public float gravity = -0.05f;
    public float jumpHeight = 3f;

    public Transform groundCheck; //center of the ground check sphere
    public float groundDistance = 0.4f; //radius of the sphere which will check if we are on the ground
    public LayerMask groundMask; //to control what objects the sphere should check for
    
    public bool onGround=true;    
    private bool crouched = false;
    private Animator anim;
    private Vector3 velocity;

    private void Awake() {
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(onGround && velocity.y <0){
            Debug.Log("in");
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charControl.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Crouch")){
            if(crouched){
                charControl.center = Vector3.zero;
                charControl.height = 3f;
                anim.Play("Uncrouch");
                crouched=false;
            }
            else{
                charControl.center = new Vector3(0, -0.5f, 0);
                charControl.height = 1.5f;
                anim.Play("Crouch");
                crouched=true;
            }
        }

        velocity.y += gravity ;

        charControl.Move(velocity * Time.deltaTime);
    }
}
