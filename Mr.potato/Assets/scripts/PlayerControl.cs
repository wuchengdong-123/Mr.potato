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
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
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

    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < maxspeed)
            heroBody.AddForce(finput * moveForce * Vector2.right);
        if (Mathf.Abs(heroBody.velocity.x) > maxspeed)
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxspeed, heroBody.velocity.y);
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
