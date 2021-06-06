using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f;
    public Sprite damagedEnemy;
    public Sprite deadEnemy;
    public int HP = 2;
    public float maxSpinForce = 200;
    public float minSpinForce = -200;
    public GameObject UI_100Points;

    private Rigidbody2D enemyBody;
    private Transform frontCheck;
    private bool isDead = false;
    private SpriteRenderer curBody;//当前身体
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontcheck");
        curBody = transform.Find("body").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(transform.localScale.x * moveSpeed, enemyBody.velocity.y);

        Collider2D[] colliders = Physics2D.OverlapPointAll(frontCheck.position);

        foreach(Collider2D c in colliders)
        {
            if(c.tag == "Wall")
            {
                flip();
                break;
            }
        }

        if(HP == 1&& damagedEnemy!=null)
        {
            curBody.sprite = damagedEnemy;
        }
        if(HP <= 0 && !isDead)
        {
            death();
            isDead = true;
        }
    }
    public void Hurt()
    {
        HP--;
    }
    void death()
    {
        isDead = true;
        SpriteRenderer[] Sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in Sprites)
            s.enabled = false;
        curBody.enabled = true;
        curBody.sprite = deadEnemy;

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
            c.isTrigger = true;
        //给一个随机旋转按钮
        enemyBody.freezeRotation = false;
        enemyBody.AddTorque(Random.Range(minSpinForce, maxSpinForce));

        Vector3 UI100Pos = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(UI_100Points, transform.position, Quaternion.identity);
        Debug.Log(Quaternion.identity);
    }

    void flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
    void Update()
    {
        
    }
}
