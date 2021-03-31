using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class XMLStudy : MonoBehaviour
{

    private string xmlPath;

    private SerilizeStudy serilizeStudy;


    private void Awake()
    {
        xmlPath = Application.dataPath + "/Resources/Data/TestByXML.xml";
        serilizeStudy = new SerilizeStudy()
        {
            ID = 0,
            Name = "测试",
            IDLst = new List<int>(),
        };
        serilizeStudy.IDLst.Add(1);
        serilizeStudy.IDLst.Add(2);
    }

    private void Start()
    {
        //XMLSerilize(serilizeStudy);

        //Debug.Log(XMLDeSerilize().Name);


    }

    //创建并将已经序列化好的类写入XML【正向序列化】
    void XMLSerilize(SerilizeStudy serilizeStudy)
    {
        //创建文件流 进行创建文件【路径，文件模式，是否可读写】
        FileStream fileStream = new FileStream(xmlPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        //写入文件流  UTF-8格式
        StreamWriter sw = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
        //获取XML类型
        XmlSerializer xml = new XmlSerializer(serilizeStudy.GetType());
        //使用这个类型的序列化API 进行序列化
        xml.Serialize(sw, serilizeStudy);

        //关闭写入流
        sw.Close();
        //关闭文件流
        fileStream.Close();
    }

    //反向序列化 读取XML
    SerilizeStudy XMLDeSerilize()
    {
        //创建文件流 进行读取文件【路径，文件模式，是否可读写】
        FileStream fileStream = new FileStream(xmlPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        //获取XML类型
        XmlSerializer xs = new XmlSerializer(typeof(SerilizeStudy));

        //反向序列化
        return xs.Deserialize(fileStream) as SerilizeStudy;
    }

}
