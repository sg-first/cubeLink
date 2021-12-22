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
            setText("点击要设置贴图的物体");
        }
    }

    void Update()
    {
        if (!Press.canCreate && Input.GetMouseButtonDown(0))
        {
            //摄像机为原点创建一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //射线碰撞到游戏地形时
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                //选择贴图
                string path = EditorUtility.OpenFilePanel("浏览文件", "D:/", string.Empty);
                modTexture.setTexture(obj, path);
            }
            setText("设置贴图");
            Press.canCreate = true;
            Press.ready = true;
        }
    }
}
