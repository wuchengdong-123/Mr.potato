using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    void Start()
    {
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rotationZ = Random.Range(0, 360);
        if(collision.tag != "Player"&&collision.tag !="Rocket")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, rotationZ)));
            Destroy(gameObject);
        }

        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hurt();
        }
    }
    void Update()
    {
        
    }
}
