using UnityEditor;
using UnityEngine;

public class ScriptableObjectStudy : MonoBehaviour
{
    private string scrObjPath;

    private void Awake()
    {
        scrObjPath = Application.dataPath+ "/Scripts/ObjectScript/TestAssets.asset";
    }

    private void Start()
    {
        Debug.Log(ReadAssets(scrObjPath).name);
    }

    private ScriptableObjectEditor ReadAssets(string scrObjPath)
    {
        //AD读取只能从项目路径开始读取，不能使用Application.dataPath从盘符开始读取
        ScriptableObjectEditor soe = AssetDatabase.LoadAssetAtPath<ScriptableObjectEditor>("Assets/Scripts/ObjectScript/TestAssets.asset");
        return soe;
    }
}
