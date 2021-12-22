using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    public static bool ready = false;
    public static bool canCreate=true;

    // ������������һ��
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
        //����������ʱ��Ӧ�÷���
        else if (canCreate && Input.GetMouseButtonDown(0))
        {
            //�����Ϊԭ�㴴��һ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //������ײ����Ϸ����ʱ
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = hit.point + (float)0.5 * hit.normal;
            }
        }
    }
}
