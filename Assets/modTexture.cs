using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class modTexture : MonoBehaviour
{
    public static Texture2D loadTexture(string imagePath)
    {
        FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        byte[] thebytes = new byte[fs.Length];
        fs.Read(thebytes, 0, (int)fs.Length);
        //ʵ����һ��Texture2D����͸����ÿ���������ģ���Ϊ��ʹ��LoadImage�������Texture2D�Ŀ�͸߻�����Ӧ�ĵ���
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(thebytes);
        return texture;
    }

    public static void setTexture(GameObject obj, string imagePath)
    {
        var mat = obj.GetComponent<MeshRenderer>().material;
        mat.SetTexture("_MainTex", loadTexture(imagePath));
    }
}
