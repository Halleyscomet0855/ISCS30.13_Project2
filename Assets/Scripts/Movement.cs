using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool Grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float HoriInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(HoriInput*speed, body.linearVelocity.y);
        
        if(HoriInput > 0.01f)
            transform.localScale = new Vector3(5,5,1);
        else if ((HoriInput < -0.01f))
            transform.localScale = new Vector3(-5,5,1);
    
        if(Input.GetKey(KeyCode.Space) && Grounded)
            Jump();


        anim.SetBool("Walk", HoriInput != 0);
        anim.SetBool("Grounded", Grounded);
    }
    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
            Grounded = true;
    }
}
