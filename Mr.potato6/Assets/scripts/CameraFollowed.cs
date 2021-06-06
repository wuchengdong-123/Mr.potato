using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowed : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTran;//主角的Transfrom
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY = new Vector2(-8, 8);
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()
    {
        bool aMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > maxDistanceY)
            aMove = true;
        else
            aMove = false;
        return aMove;
    }
    void Start()
    {
        
    }

    private void Awake()
    {
        playerTran = GameObject.Find("hero").transform;//第一种方式
        //playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void TrackPlayer()
    {
        float newx = transform.position.x;
        float newy = transform.position.y;
        if (NeedMoveX())
            newx = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
        //newx = Mathf.Clamp(newx,minXandY)
        if (NeedMoveY())
            newy = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
        //newx = Mathf.Clamp(newx,minXandY)
        newx = Mathf.Clamp(newx, minXandY.x, maxXandY.x);
        newy = Mathf.Clamp(newy, minXandY.y, maxXandY.y);
        transform.position = new Vector3(newx,newy,transform.position.z);
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
