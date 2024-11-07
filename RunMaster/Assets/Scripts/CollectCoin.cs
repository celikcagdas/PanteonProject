using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public int defeatCount;
    public TextMeshProUGUI DefeatText;

    public PlayerController playercontroller;

    Vector3 PlayerStartPos;

    void Start()
    {
        score = 0;
        defeatCount = 0;
        UpdateCoinText();
        PlayerStartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        UpdateDefeatText();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Congrats!");

            AddCoin();
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Finish"))

        {
            Debug.Log("Congrats!");

            playercontroller.runningSpeed = 0;

        }
        else if (other.CompareTag("obstacle"))
        {
            
            transform.position = PlayerStartPos;
            AddDefeat(); 


        }
    }

    public void AddCoin()
    {
        score++;
        UpdateCoinText(); 
    }
    void UpdateCoinText()
    {
        CoinText.text = "Gold: " + score.ToString();
    }
    public void AddDefeat()
    {
        defeatCount++;
        Debug.Log("Defeat Count:" + defeatCount);

        UpdateDefeatText(); 
    }
    void UpdateDefeatText()
    {
        DefeatText.text = "Defeat:" + defeatCount.ToString();
    }


}


