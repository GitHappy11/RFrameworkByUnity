using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="TestAssets",menuName="CreatAssets",order =0)]
public class ScriptableObjectEditor : ScriptableObject
{
    public int id;
    public new string name;
    public List<int> idLst;
}
