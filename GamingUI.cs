using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamingUI : MonoBehaviour
{


    public Text Money;
    public Text TargetMoney;
    public Text LevelTime;
    public Text Level;

    public int money;
    public int targetMoney;
    public float levelTime;
    public int level;

    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        Money.text = money.ToString();
        TargetMoney.text = targetMoney.ToString();
        LevelTime.text = levelTime.ToString();
        Level.text = level.ToString();



    }

    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        LevelTime.text = levelTime.ToString();
        if (levelTime <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void OnMoney(int value)
    {
        money = money + value;
        Money.text = money.ToString();
        if (money > targetMoney)
        {
            OnStartGame(level);
        }
    }

    private void OnStartGame(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }


}
