using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movController : MonoBehaviour
{
    //移动
    public float moveSpeed = 10;  //前后左右移动速度
    public float maxHeigh = 10; //最大高度
    public float minHeigh = 1; //最小高度
    //（左右）旋转
    public float sensitivityX = 10F;
    //鼠标边缘移动
    public float acceptRatio = 1 / 100;

    void Start()
    {
        //this.GetComponent<Renderer>().enabled = false;
    }

    void KeyUpdate()
    {
        int XDirection = 0;
        int YDirection = 0;
        int ZDirection = 0;
        float move = this.moveSpeed * Time.deltaTime;

        if (Input.GetKey("a"))
            XDirection = -1;
        if (Input.GetKey("d"))
            XDirection = 1;
        if (Input.GetKey("q"))
        {
            if (this.transform.position.y < this.maxHeigh)
                YDirection = 1;
        }
        if (Input.GetKey("z"))
        {
            if (this.transform.position.y > this.minHeigh)
                YDirection = -1;
        }
        if (Input.GetKey("w"))
            ZDirection = 1;
        if (Input.GetKey("s"))
            ZDirection = -1;

        //处理
        if (YDirection != 0)
            transform.Translate(0, YDirection * move, 0);
        if (XDirection != 0)
            transform.Translate(XDirection * move, 0, 0);
        if (ZDirection != 0)
            transform.Translate(0, 0, ZDirection * move);
    }

    void mouseRotUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)  
            float rotationX = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensitivityX;
            //总体设置一下相机角度
            var old1 = this.transform.localEulerAngles.x;
            var old3 = this.transform.localEulerAngles.z;
            this.transform.localEulerAngles = new Vector3(old1, rotationX, old3);
        }
    }

    void mouseMovUpdate()
    {
        int XDirection = 0;
        int YDirection = 0;
        float move = this.moveSpeed * Time.deltaTime;
        //下面这段留着备用
        //int ZDirection = 0;
        //调试输出是debug.log
        // 按W: ZDirection = 1;按S:  ZDirection = -1; 
        //if (ZDirection != 0)  transform.Translate(0, 0, ZDirection * move);
        float ScreenWidth = Screen.width; //屏幕宽度
        float ScreenHeight = Screen.height; //屏幕高度
        float X = Input.mousePosition.x; //鼠标X
        float Y = Input.mousePosition.y; //鼠标Y

        //当鼠标距边缘的距离小于(屏幕该轴长宽*this.acceptRatio)时，移动
        if (Y >= ScreenHeight - ScreenHeight * this.acceptRatio) //鼠标在上面
            YDirection = 1;
        if (Y <= ScreenHeight * this.acceptRatio) //鼠标在下面
            YDirection = -1;
        if (X >= ScreenWidth - ScreenWidth * this.acceptRatio) //鼠标在右边
            XDirection = 1;
        if (X <= ScreenWidth * this.acceptRatio)  //鼠标在左边
            XDirection = -1;

        if (XDirection != 0)
            transform.Translate(XDirection * move, 0, 0);
        if (YDirection != 0)
            transform.Translate(0, 0, YDirection * move);
    }

    void Update()
    {
        KeyUpdate();
        mouseRotUpdate();
        //mouseMovUpdate();
    }
}