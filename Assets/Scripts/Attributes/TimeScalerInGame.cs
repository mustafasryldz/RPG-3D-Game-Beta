using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalerInGame : MonoBehaviour
{
    public int scale;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activate)
        {
            ScaleTime(); // scale time 
            activate = false;
        }
    }
    void ScaleTime()
    {
        Time.timeScale = scale;
    }
}
