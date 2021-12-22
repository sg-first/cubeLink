using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movController : MonoBehaviour
{
    //�ƶ�
    public float moveSpeed = 10;  //ǰ�������ƶ��ٶ�
    public float maxHeigh = 10; //���߶�
    public float minHeigh = 1; //��С�߶�
    //�����ң���ת
    public float sensitivityX = 10F;
    //����Ե�ƶ�
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

        //����
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
            //��������ƶ��Ŀ���(����), ������������ת�ĽǶ�(����X)  
            float rotationX = this.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.sensitivityX;
            //��������һ������Ƕ�
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
        //����������ű���
        //int ZDirection = 0;
        //���������debug.log
        // ��W: ZDirection = 1;��S:  ZDirection = -1; 
        //if (ZDirection != 0)  transform.Translate(0, 0, ZDirection * move);
        float ScreenWidth = Screen.width; //��Ļ���
        float ScreenHeight = Screen.height; //��Ļ�߶�
        float X = Input.mousePosition.x; //���X
        float Y = Input.mousePosition.y; //���Y

        //�������Ե�ľ���С��(��Ļ���᳤��*this.acceptRatio)ʱ���ƶ�
        if (Y >= ScreenHeight - ScreenHeight * this.acceptRatio) //���������
            YDirection = 1;
        if (Y <= ScreenHeight * this.acceptRatio) //���������
            YDirection = -1;
        if (X >= ScreenWidth - ScreenWidth * this.acceptRatio) //������ұ�
            XDirection = 1;
        if (X <= ScreenWidth * this.acceptRatio)  //��������
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