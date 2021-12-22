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
        //实例化一个Texture2D，宽和高设置可以是任意的，因为当使用LoadImage方法会对Texture2D的宽和高会做相应的调整
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
