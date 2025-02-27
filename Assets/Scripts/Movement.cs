using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;
    private int Jumps;
    private bool Walled;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Jumps = 2;
    }

    private void Update()
    {
        float HoriInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(HoriInput*speed, body.linearVelocity.y);
        
        if(HoriInput > 0.01f)
            transform.localScale = new Vector3(5,5,1);
        else if ((HoriInput < -0.01f))
            transform.localScale = new Vector3(-5,5,1);

        
        
        if(Grounded && Jumps<2) {
            Jumps = 2;
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && Jumps > 0 && !Walled) {
            Jump();
               
            Debug.Log(Jumps);
            
        }
        Debug.Log(Walled);
           
        Walled = false;
        Debug.Log(Jumps);
        anim.SetBool("Walk", HoriInput != 0);
        anim.SetBool("Grounded", Grounded);
    }
    private void Jump()
    {
        
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        Grounded = false;
        Jumps = Jumps - 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Bounce")
            Grounded = true;
        if(collision.gameObject.tag=="Walls"){
            body.linearVelocity = new Vector2(0, 0);
            Walled = true;
        }
        if(collision.gameObject.tag=="Bounce"){
            body.linearVelocity = new Vector2(0, 50);
        }
        if(collision.gameObject.tag=="Bounce2"){
            body.linearVelocity = new Vector2(0, speed*0.75f);
        }
    }     
}
