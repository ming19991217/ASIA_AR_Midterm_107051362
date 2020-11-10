using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("騎士")]
    public Transform knight01;
    public Transform knight02;

    [Header("旋轉速度"), Range(0.1f, 20f)]
    public float turn;
    [Header("縮放速度"), Range(0.01f, 10f)]
    public float scaleSpeed;
    [Header("縮放最大最小值")]
    public float min;
    public float max;
    //動畫
    Animator knight01Anim;
    Animator knight02Anim;

    public FixedJoystick joystick;

    bool isRunning = true;


    void Start()
    {
        knight01Anim = knight01.GetComponent<Animator>();
        knight02Anim = knight02.GetComponent<Animator>();
    }
    void Update()
    {
        knight01.Rotate(0, joystick.Horizontal * turn, 0);
        knight02.Rotate(0, joystick.Horizontal * turn, 0);



        knight01.localScale += new Vector3(1, 1, 1) * joystick.Vertical * scaleSpeed;
        knight01.localScale=new Vector3(1,1,1)*Mathf.Clamp(knight01.localScale.x,min,max);
        knight02.localScale += new Vector3(1, 1, 1) * joystick.Vertical * scaleSpeed;
        knight02.localScale=new Vector3(1,1,1)*Mathf.Clamp(knight02.localScale.x,min,max);
    }
    public void attackAnim()
    {
        knight01Anim.SetTrigger("attack");
        knight02Anim.SetTrigger("attack");

    }
    public void runAnim()
    {
        knight01Anim.SetBool("run", isRunning);
        knight02Anim.SetBool("run", isRunning);
        isRunning = !isRunning;
    }

}


