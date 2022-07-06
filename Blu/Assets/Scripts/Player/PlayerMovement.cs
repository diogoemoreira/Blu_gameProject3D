using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charControl;
    
    public float speed = 2.5f;
    public float gravity = -0.45f;
    public float jumpHeight = 3f;

    public Transform groundCheck; //center of the ground check sphere
    public float groundDistance = 0.4f; //radius of the sphere which will check if we are on the ground
    public LayerMask groundMask; //to control what objects the sphere should check for
    public Animator camAnim;
    
    public bool onGround=true;    
    private bool crouched = false;
    private Animator anim;
    private Vector3 velocity;
    private AudioSource audioSrc;


    private void Awake() {
        this.anim = this.GetComponent<Animator>();
        this.audioSrc = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charControl.enabled){
             onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(onGround && velocity.y <0){
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
                    camAnim.Play("Uncrouch");
                    crouched=false;
                }
                else{
                    charControl.center = new Vector3(0, -0.5f, 0);
                    charControl.height = 1.5f;
                    crouched=true;
                    camAnim.Play("Crouch");
                }
            }

            velocity.y += gravity ;

            charControl.Move(velocity * Time.deltaTime);

            bool isMoving = move != Vector3.zero;
            if (isMoving)
            {
                if (audioSrc!=null && !audioSrc.isPlaying)
                    audioSrc.Play();
                if (crouched)
                {
                    anim.Play("Crouch Walk");
                }
                else
                {
                    anim.Play("WalkBlu");
                    if(camAnim.GetBool("fade") && !camAnim.GetBool("crouching"))
                        camAnim.Play("CameraWalking");
                }
            }
            else
            {
                audioSrc.Stop();
                if (crouched)
                {
                    anim.Play("Crouched Idle");
                } else
                {
                    anim.Play("IdleBlu");
                    if(camAnim.GetBool("fade") && !camAnim.GetBool("crouching"))
                        camAnim.Play("CameraIdle");
                }
            }
        }
       
    }
}
