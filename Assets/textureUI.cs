using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEditor;

public class textureUI : MonoBehaviour
{
    Button btn;

    void setText(string text)
    {
        Text t = btn.transform.Find("Text").GetComponent<Text>();
        t.text = text;
    }

    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (Press.canCreate)
        {
            Press.canCreate = false;
            setText("���Ҫ������ͼ������");
        }
    }

    void Update()
    {
        if (!Press.canCreate && Input.GetMouseButtonDown(0))
        {
            //�����Ϊԭ�㴴��һ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //������ײ����Ϸ����ʱ
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                //ѡ����ͼ
                string path = EditorUtility.OpenFilePanel("����ļ�", "D:/", string.Empty);
                modTexture.setTexture(obj, path);
            }
            setText("������ͼ");
            Press.canCreate = true;
            Press.ready = true;
        }
    }
}
