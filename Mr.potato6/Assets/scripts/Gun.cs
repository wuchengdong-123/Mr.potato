using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    PlayerControl playerControl;
    private Animator gun;
    private AudioSource ac;
    void Start()
    {
        playerControl = transform.root.GetComponent<PlayerControl>();
        gun = transform.root.GetComponent<Animator>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0)) 
        if (Input.GetButtonDown("Fire1"))
        {
            gun.SetTrigger("shot");
            ac.Play();
            Vector3 direction = new Vector3(0, 0, 0);
            if(playerControl.bFaceRight)
            {
                Rigidbody2D RocketInstance = Instantiate(rocket,transform.position,Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RocketInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }
    }
}
