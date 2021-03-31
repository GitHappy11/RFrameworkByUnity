using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//多种资源加载方式
public class ResourcesStudy : MonoBehaviour
{
    public GameObject prefabs;



    private void Start()
    {
        //ResByInstantiate(prefabs);

        //GameObject.Instantiate(ResByPath("Attack"));

        //GameObject.Instantiate(ResByAB(Application.streamingAssetsPath + "/attack_ab", "Attack"));

        //GameObject.Instantiate(ResByAD("Assets/Resources/Attack.FBX"));
    }



    //Unity加载生成. 一般不使用。
    public GameObject ResByInstantiate(GameObject obj)
    {
        return obj = Instantiate(prefabs); 
    }

    //通过Resource文件夹进行路径加载 (Resource文件夹有容量上限【约为2G】)，不经常使用，基本放一些配置表。
    public GameObject ResByPath(string path)
    {
        return Resources.Load(path) as GameObject;
    }
    
    //AB包资源加载 需先打包好资源 详情请查看BundleEditor脚本 【效率高，占用低，大部分商业项目使用】
    public GameObject ResByAB(string abPath,string objName) 
    {
        AssetBundle ab = AssetBundle.LoadFromFile(abPath);
        GameObject obj = ab.LoadAsset<GameObject>(objName);
        return obj;
    }

    //AD加载，编辑器加载，做框架使用 需要项目完整路径且需要后缀名，不能使用Application.dataPath从盘符开始读取
    public GameObject ResByAD(string adPath)
    {
        GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(adPath);
        return obj;
    }
}
