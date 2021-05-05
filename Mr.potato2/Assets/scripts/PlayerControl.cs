using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D heroBody;
    public float moveForce = 100;
    private float finput=0.0f;
    public float maxspeed = 5;
    private bool bFaceRight = true;
    private bool bGrounded = false;
    public float jumpforce = 500;
    Transform mGroundcheck;
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGroundcheck = transform.Find("Groundcheck");
    }

    // Update is called once per frame
    void Update()
    {
        finput = Input.GetAxis("Horizontal");
        if (finput < 0 && bFaceRight)
            flip();
        else if (finput > 0 && !bFaceRight)
            flip();
        //if (Input.GetAxis("Horizontal"))
        ///heroBody.AddForce(Vector2.right * h * moveForce);
        bGrounded = Physics2D.Linecast(transform.position, mGroundcheck.position, 1 << LayerMask.NameToLayer("Ground"));//射线检测
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < maxspeed)
            heroBody.AddForce(finput * moveForce * Vector2.right);
        if (Mathf.Abs(heroBody.velocity.x) > maxspeed)
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxspeed, heroBody.velocity.y);
        bool bJump = false;
        if(bGrounded)//判断是否在地上
        {
            bJump = Input.GetKeyDown(KeyCode.Space);
            Vector2 upForce = new Vector2(0, 1);
            if (bJump)
                heroBody.AddForce(upForce * jumpforce);
        }
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
