using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitedTime;
    public float starWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("s")){
            waitedTime=starWaitTime;
        }
        if (Input.GetKey("s"))
        {
            if (waitedTime<=0)
            {
                effector.rotationalOffset= 180f;
                waitedTime=starWaitTime;
            }
        }
        else {
            waitedTime -=Time.deltaTime;
        }
        if (Input.GetKey("space")){
            effector.rotationalOffset=0;
        }
    }
}
