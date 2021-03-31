
using UnityEditor;
using UnityEngine;

public class BundleEditor
{
   [MenuItem("Tools/Packaging")]
   public static void Bulid()
    {
        Debug.Log("正在打包...");
        //AB包打包要先在资源上New一个AB包并命名
        //进行打包   打包目录  打包方式 打包平台【当前Unity平台】
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
        //编辑器刷新
        AssetDatabase.Refresh();
    }
}
