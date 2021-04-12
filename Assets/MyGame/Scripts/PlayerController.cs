using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Jump = "Jump";
    private const string Ground = "Ground";
    private const string Obstacle = "Obstacle";
    private const string SantaDeath = "SantaDeath";
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float jumpForce;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver && !gameOver && !gameOver)
        {
            if (grounded == true)
            {
                jump();
            }
        }
    }

    bool grounded;
    bool gameOver = false;

    void jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger(Jump);

        GameManager.instance.IncrementScore();
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   {
        if(collision.gameObject.tag == Ground)
        {
            grounded = true;}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == Obstacle)
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play(SantaDeath);
            gameOver = SetGameOverTrue();
        }
    }
}
