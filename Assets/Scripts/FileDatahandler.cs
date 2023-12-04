using System;
using System.IO;
using UnityEngine;

public class FileDataHandler{
    private String dataDirPath="";
    private String dataFileName="";
    public FileDataHandler(String dataDirPath, String dataFileName){
        this.dataDirPath=dataDirPath;
        this.dataFileName=dataFileName;
    }
    public GameData load(){
        string fullPath = Path.Combine(dataDirPath,dataFileName);
        GameData loadedData=null;
        if(File.Exists(fullPath)){
            try{
                string dataToLoad="";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using(StreamReader reader=new StreamReader(stream)){
                        dataToLoad=reader.ReadToEnd();
                    }
                    loadedData=JsonUtility.FromJson<GameData>(dataToLoad);
                }
            }catch(Exception e){
                 Debug.LogError("Error on load file");
            }
        }
        return loadedData;
    }
    public void save(GameData data){
        string fullPath = Path.Combine(dataDirPath,dataFileName);
        try{
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore= JsonUtility.ToJson(data,true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using(StreamWriter writer=new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        }catch(Exception e){
            Debug.LogError("Erro on saving Data");
        }
    }
}