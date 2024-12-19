using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Rope : MonoBehaviour
{
    public enum State
    {
        Swing,
        Extension,
        Takeback

    }

    public State Mystate;
    private float Speed = 60f;
    private Vector3 V3;
    private float Length=1;
    private float LSpeed=10.0f;
    public GameObject Hook;
    private GamingUI UI;

    void Start()
    {
        V3 = Vector3.forward;//Vector3.forward:Z轴正方向。 因为2D都是绕Z轴旋转！
        //找到Canvas下的GamingUI.CS脚本:
        UI = GameObject.Find("Canvas").GetComponent<GamingUI>();
    }

    void Update()
    {
        if (Mystate == State.Swing)
        {
            OnSwing();
            if (Input.GetMouseButtonDown(0))
            {
                Mystate =State.Extension;
            }
        }
        else if(Mystate==State.Extension)
        {
            OnExtension();

           
        }
        else
        {
            OnTakeBack();

        }

    }

    private void OnSwing()
    {
        transform.Rotate(V3 * Speed * Time.deltaTime);
        if (transform.localRotation.z > 0.6f)
        {
            V3 = Vector3.back;//Vector3.back:Z轴负方向
        } else if(transform.localRotation.z < -0.6f)
        {
            V3 = Vector3.forward; //Vector3.forward:Z轴正方向
        }

    }

    private void OnExtension()
    {
        Length += Time.deltaTime * LSpeed;
        transform.localScale = new Vector3(transform.localScale.x, Length, transform.localScale.z);//沿Y轴的缩放设置为Length，而X轴和Z轴的缩放保持不变
        if (Length > 10)
        {
            Mystate = State.Takeback;
        }
    }

    private void OnTakeBack()
    {
        Length -= Time.deltaTime * LSpeed;
        transform.localScale = new Vector3(transform.localScale.x, Length, transform.localScale.z); 
        if (Length <= 1)
        {
            Length = 1;
            Mystate = State.Swing;
            if (Hook.transform.childCount == 1)
            {
                Destroy(Hook.transform.GetChild(0).gameObject);
                //调用函数、传参：获取Gold.cs脚本，然后取里面的value参数值
                UI.OnMoney(Hook.transform.GetChild(0).GetComponent<Gold>().value);
            }
        }
    }




}
