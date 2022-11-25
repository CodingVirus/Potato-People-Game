using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

public class PlayerData{

    public int playerPosition;
    public string nowDate;
    public string nowTime;

    // public PlayerData(int playerPosition){
    //     this.playerPosition = playerPosition;
    // }
}

class Monster{

}

public class SLManager : MonoBehaviour
{
    public static SLManager instance;

    public PlayerData nowPlayer = new PlayerData();

    public Text tx;
    //public List<PlayerData> nowPlayer = new List<PlayerData>();
    public string path;
    public int nowSlot;

    //싱글톤
    private void Awake() {

        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.dataPath + "/PayOffData.json"; // 경로 지정
        print(path);
    }
    //List<people> data = new List<people>();

    //Dictionary<string, people> data = new Dictionary<string, people>();

    //Dictionary<string, int> data = new Dictionary<string, int>();

    private void Start(){
        
        // data.Add(new people("철수", 20));
        // data.Add(new people("유리", 18));
        // data.Add(new people("맹구", 23));

        // data["p1"] = new people("철수", 15);
        // data["p2"] = new people("유리", 18);
        // data["p3"] = new people("맹구", 23);

        // data["철수"] = 15;
        // data["유리"] = 12;
        // data["맹구"] = 42;

        // string jdata = JsonConvert.SerializeObject(data);
        // print(jdata);

    }

    public void _save(){

        // string jdata = JsonUtility.ToJson(nowPlayer);
        // File.WriteAllText(path, jdata);

        string jdata = JsonConvert.SerializeObject(nowPlayer);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(path + nowSlot.ToString(), format);

    }

    public void _load(){

        // string jdata = File.ReadAllText(path);
        // nowPlayer = JsonUtility.FromJson<PlayerData>(jdata);

        string jdata = File.ReadAllText(path + nowSlot.ToString());
        byte[] bytes = System.Convert.FromBase64String(jdata);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        //tx.text = reformat;
        nowPlayer = JsonConvert.DeserializeObject<PlayerData>(reformat);

    }

    //데이터 비우기
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}