using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    Animator anim;
    float timeNow;
    public float timeBetweenSwitches;
    Vector3 pos;
    Transform tr;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timeNow = 0;
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        if(timeNow > timeBetweenSwitches)
        {
            bool s = !anim.GetBool("switch");
            anim.SetBool("switch", s);
            timeNow = 0;
        }
        pos = tr.position;
        // a += 2;  that would be the same as a = a + 2;
        // a -= 2;  that would be the same as a = a - 2;
        pos.x += speed * Time.deltaTime;
       
        if (pos.x > 12.5 )
        {
            speed *= -1;
            pos.x = 12.4f;
        }
        if(pos.x < -12.5)
        {
            speed *= -1;
            pos.x = -12.4f;
        }
        tr.position = pos;
    }

    public void OnSpeedUp()
    {
        if(Mathf.Abs(speed) <= 16)
        {
            speed *= 2;
        }
        
    }
}
