using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    List<Player> dummyPlayers = new List<Player>()//ダミーデータ
    {
        new Player {Name = "Player1",Score = 100},
        new Player {Name = "Player2",Score = 50},
        new Player {Name = "Player3",Score = 48},
        new Player {Name = "Player4",Score = 19},
    };
    private void Awake()
    {
        DataService.InitDatabase("SampleDb");//データベース作成
        DataService.CreateTable();//テーブル作成
    }

    private void Start()
    {
        //ダミーデータ登録
        //InsertDummyData();
        //ShowPlayers();
    }


    public void InsertDummyData()
    {
        foreach(Player player in dummyPlayers)
        {
            DataService.InsertPlayer(player);//Playerデータ登録
        }
    }

    private void ShowPlayers()
    {
        foreach(Player player in DataService.GetAllPlayers())
        {
            Debug.Log($"ID:{player.Id} / NAME : {player.Name} / SCORE : {player.Score}\n");//Playerデータ表示
        }
    }

    public void InsertPlayer(Player player)
    {
        Player existingPlayer = DataService.GetPlayerByName(player.Name);
        if(existingPlayer != null)
        {
            if(player.Score > existingPlayer.Score)
            {
                existingPlayer.Score = player.Score;
                DataService.UpdatePlayerData(existingPlayer);
            }
        }
        else
        {
            DataService.InsertPlayer(player);
        }
    }

    public List<Player> GetAllPlayers()
    {
        return DataService.GetAllPlayers();
    }

    public void DeletePlayers()
    {
        DataService.DeletePlayers();
    }
}
