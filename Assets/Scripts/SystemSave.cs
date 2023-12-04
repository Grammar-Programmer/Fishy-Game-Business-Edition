using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;
public static class SystemSave{
    public static void saveGame(){
        // BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data=new GameData();
        StreamWriter writer=new StreamWriter(stream);
        writer.Write(JsonUtility.ToJson(data,true));
        // formatter.Serialize(stream, data);
        stream.Close(); 
    }
    public static GameData loadGame(){
        string path = Application.persistentDataPath + "/player.txt";
        if(File.Exists(path)){
            // BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader reader=new StreamReader(stream);
            return JsonUtility.FromJson<GameData>(reader.ReadToEnd());
            // (DataSave) reader.ReadToEnd();
            // return (DataSave)formatter.Deserialize(stream);
        }else{
            Debug.LogError("Save file dont exists");
            return null;
        }
    }
}