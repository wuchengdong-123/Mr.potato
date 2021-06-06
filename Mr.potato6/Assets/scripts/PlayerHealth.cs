using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    float health=100f;
    public float hurtBloodPoint = 20f;
    public AudioClip[] ouchClips;
    public float hurtForce = 100f;
    SpriteRenderer healthbar;
    Vector3 healthbarScale;
    public float damageRepeat = 0.5f;
    private float lastHurt;
    private Animator anim;


    void Start()
    {
        healthbar = GameObject.Find("Health").GetComponent<SpriteRenderer>();
        healthbarScale = healthbar.transform.localScale;

        lastHurt = Time.time;//出生的状态

        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHurt + damageRepeat)
            {
                if (health > 0)
                {
                    //减血
                    takeDamage(collision.gameObject.transform);
                    //更新血条状态
                    lastHurt = Time.time;
                    if (health <= 0)
                    {
                        anim.SetTrigger("die");
                        Collider2D[] colliders = GetComponents<Collider2D>();
                        foreach (Collider2D c in colliders)
                            c.isTrigger = true;
                        SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                        foreach (SpriteRenderer s in sp)
                            s.sortingLayerName = "ui";

                        GetComponent<PlayerControl>().enabled = false;
                        GetComponentInChildren<Gun>().enabled = false;
                    }
                }
                else
                {
                    anim.SetTrigger("die");
                    Collider2D[] colliders = GetComponents<Collider2D>();
                    foreach (Collider2D c in colliders)
                        c.isTrigger = true;
                    SpriteRenderer[] sp = GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer s in sp)
                        s.sortingLayerName = "ui";

                    GetComponent<PlayerControl>().enabled = false;
                    GetComponentInChildren<Gun>().enabled = false;
                }
            }
            
            
        }
    }
    // Update is called once per frame
    void takeDamage(Transform enemy)
    {
        health -= hurtBloodPoint;//更新血条状态
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(hurtVector* hurtForce);

        UpdateHealthBar();
        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }

    void UpdateHealthBar()
    {
        healthbar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthbar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
    }
    void Update()
    {
        
    }
}
