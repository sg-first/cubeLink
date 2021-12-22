using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public static bool ready = false;
    public static bool canCreate=true;

    // 程序启动调用一次
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            ready = false;
        }
        //按下鼠标左键时响应该方法
        else if (canCreate && Input.GetMouseButtonDown(0))
        {
            //摄像机为原点创建一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //射线碰撞到游戏地形时
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = hit.point + (float)0.5 * hit.normal;
            }
        }
    }
}
