using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backGrounds;
    public float fParallax = 0.4f;
    public float layerFraction = 5f;
    public float fSmooth = 5f;
    Transform cam;
    Vector3 previousCamPros;
    
    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void Start()
    {
        previousCamPros = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPros.x - cam.position.x) * fParallax;
        float fParrlaxY = (previousCamPros.x - cam.position.x) * fParallax;
        for(int i=0; i<backGrounds.Length; i++)
        {
            float fNewX = backGrounds[i].position.x + fParrlaxX * (1 + i*layerFraction);
            float fNewY = backGrounds[i].position.y + fParrlaxY * (1 + i*layerFraction);
            Vector3 newPos = new Vector3(fNewX, fNewY, backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, newPos, fSmooth*Time.deltaTime);//time,daltatime代表两帧之间的时间间隔
        }
        previousCamPros = cam.position;
    }
}
