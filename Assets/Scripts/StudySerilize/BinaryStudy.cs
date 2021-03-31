using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public class BinaryStudy : MonoBehaviour
{
    private string binPath;
    SerilizeStudy serilizeStudy;



    private void Awake()
    {
        binPath = Application.dataPath + "/Resources/Data/TestByBin.bytes";
        serilizeStudy = new SerilizeStudy()
        {
            ID = 1,
            Name = "二进制测试",
            IDLst = new List<int>(),
        };
        serilizeStudy.IDLst.Add(1);
        serilizeStudy.IDLst.Add(2);
    }

    private void Start()
    {
        Debug.Log(BinaryDeserilize(binPath).Name);
    }


    //二进制序列化
    private void BinarySerilize(SerilizeStudy serilizeStudy)
    {
        //创建文件流 创建文件
        FileStream fs = new FileStream(binPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        //创建一个二进制格式化程序
        BinaryFormatter bf = new BinaryFormatter();
        //序列化文件
        bf.Serialize(fs, serilizeStudy);
        //关闭文件流
        fs.Close();
    }

    //二进制序列化
    private SerilizeStudy BinaryDeserilize(string binPath)
    {
        //以TextAsset格式获取文件 注意：AD只适用于编辑器内使用且需要完整的项目路径【不能使用Application.dataPath从盘符开始读取的路径】
        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Resources/Data/TestByBin.bytes");
        //读取文件
        MemoryStream ms = new MemoryStream(textAsset.bytes);
        //读取文件的其他方式
        FileStream fileStream= File.Open(binPath, FileMode.Open);
        using (fileStream)
        {
            //二进制转化器
            BinaryFormatter bf = new BinaryFormatter();
            //关闭文件流 如果后面还要用到 千万别关闭，这里如果关闭，则return的时候就没有文件流使用了
            //fileStream.Close();
            return bf.Deserialize(ms) as SerilizeStudy;
        } 
        
    }
}
