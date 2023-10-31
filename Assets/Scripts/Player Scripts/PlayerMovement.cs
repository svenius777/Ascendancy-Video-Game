using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody; //da možemo micat playera
    //private Player_Base playerBase;

    private float moveSpeed = 4f;
    private BoxCollider2D boxCollider2d;//radimo referencu na komponentu BoxCollider2D
    [SerializeField] private LayerMask platformsLayerMask; //serializeField nam omogućuje da stavimo layer u Player

    void Awake() //awake se zove prije starta i biti će pozvana čak i ako je neka komponenta skripte isključena
    {
        //playerBase = gameObject.GetComponent<PlayerBase>();
        myBody = GetComponent<Rigidbody2D>(); //GetComponent je referenca na komponentu Rigidbody2D
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate() //FixedUpdate se koristi za pomicanje objekta sa Rigidbody
    {
        Move();
        Jump();
    }
    
    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f)  //za micanje u desno, "Horizonal" znaci ako stisnemo ili d ili a ce se pomaknuti, pomićemo se u desno ako je veće od 0 a u lijevo ako je manje
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }

        if(Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }

        
    }

    void Jump()
    {
        if (IsGrounded() && Input.GetButton("Jump"))
        {
            float jumpVelocity = 10f;
            myBody.velocity = Vector2.up * jumpVelocity;
        }
    }

    //ovo je za naše moving platforme kako bi pomicali playera
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

    private bool IsGrounded()
    {
        //boxCollider2d.bounds.center je naš origin
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null; //ako nije null znaci da smo nesto dotakli znaci da smo grounded
    }
}
