using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uitest : MonoBehaviour
{
    // Start is called before the first frame update
    public Button pauseBtn;
    bool isPause = false;
    void Start()
    {
        
    }

    public void PauseGame()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
