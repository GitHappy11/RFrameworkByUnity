
using System;
using UnityEngine;
using System.Xml.Serialization;
using System.Collections.Generic;

[Serializable]
public class SerilizeStudy
{
    [XmlAttribute("ID")]
    public int ID { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlElement("List")] 
    public List<int> IDLst { get; set; }
    


    


}
