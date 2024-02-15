using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] Button addButton,resetButton;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] DataManager dataManager;
    [SerializeField] GameObject scorePanel;
    [SerializeField] TextMeshProUGUI playersText;
    private void Start()
    {
        addButton.onClick.AddListener(()=>  SendPlayerData() );
        resetButton.onClick.AddListener(() => DeletePlayers());
        nameInputField.characterLimit = 10;
        scorePanel.SetActive(false);
    }

    public void SendPlayerData()
    {
        string inputName = nameInputField.text;
        if(string.IsNullOrEmpty(inputName))
        {
            return;
        }
        int score = Random.Range(1,200); //スコアをランダムで生成
        dataManager.InsertPlayer( new Player { Name = inputName, Score = score });
        ShowAllPlayers();
    }

    public void ShowAllPlayers()
    {
        string playerScores = "";
        foreach(Player player in dataManager.GetAllPlayers())
        {
            playerScores += $"{player.Name} / {player.Score} \n";
        }
        playersText.text = playerScores;
        scorePanel.SetActive(true);
    }

    public void DeletePlayers()
    {
        dataManager.DeletePlayers();
    }

    
}
