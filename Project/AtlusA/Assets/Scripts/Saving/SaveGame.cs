using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        instance = this;
    }

    public SaveDatabase saveDB;
}

[System.Serializable]
public class SaveGame {
    public int value;
}

[System.Serializable]
public class SaveDatabase
{
    public List<SaveGame> list = new List<SaveGame>();
}