// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Linq; 

// public class DataPeristenceManager : MonoBehaviour
// {
//    [Header("File Storage Config")]
//     [SerializeField] private string fileName;  
//     private GameData gameData;
//     private List<DataPeristence> dataPeristenceObjects;
//     public static DataPeristenceManager instance {get; private set;}
//     private FileDataHandler fileDataHandler;
//     private void Awake(){
//         // if(instance !=null)
//         instance=this;
//     }
//     private void Start(){
//         // fileDataHandler= new FileDataHandler(Application.persistentDataPath,fileName);
//         // dataPeristenceObjects = FindAllDataPeristenceObjects();
//         // loadGame();
//     }
//     public void newGame(){
//         this.gameData=new GameData();
//     }
//     public void loadGame(){
//         gameData=fileDataHandler.load();
//         if(gameData==null) newGame();
//         foreach(DataPeristence  dataPeristence in dataPeristenceObjects){
//             dataPeristence.loadData(gameData);
//         }
//     }
//     public void saveGame(){
//         gameData.firstTime=false;
//         foreach(DataPeristence  dataPeristence in dataPeristenceObjects){
//             dataPeristence.saveData(ref gameData);
//         }
//         fileDataHandler.save(gameData);
//     }
//     private void OnApplicationQuit() {
//         saveGame();
//     }
//     private List<DataPeristence> FindAllDataPeristenceObjects(){
//         IEnumerable<DataPeristence> dataPeristenceObjects= FindObjectsOfType<MonoBehaviour>().OfType<DataPeristence>();
//         return new List<DataPeristence>(dataPeristenceObjects);
//     }
// }
