using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    List<Player> dummyPlayers = new List<Player>()//�_�~�[�f�[�^
    {
        new Player {Name = "Player1",Score = 100},
        new Player {Name = "Player2",Score = 50},
        new Player {Name = "Player3",Score = 48},
        new Player {Name = "Player4",Score = 19},
    };
    private void Awake()
    {
        DataService.InitDatabase("SampleDb");//�f�[�^�x�[�X�쐬
        DataService.CreateTable();//�e�[�u���쐬
    }

    private void Start()
    {
        //�_�~�[�f�[�^�o�^
        //InsertDummyData();
        //ShowPlayers();
    }


    public void InsertDummyData()
    {
        foreach(Player player in dummyPlayers)
        {
            DataService.InsertPlayer(player);//Player�f�[�^�o�^
        }
    }

    private void ShowPlayers()
    {
        foreach(Player player in DataService.GetAllPlayers())
        {
            Debug.Log($"ID:{player.Id} / NAME : {player.Name} / SCORE : {player.Score}\n");//Player�f�[�^�\��
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
