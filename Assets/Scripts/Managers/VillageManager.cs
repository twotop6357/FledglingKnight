using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    public TalkManager talkManager;
    [SerializeField] private Image startFrame;
    [SerializeField] private Text realTime;
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private Text talkText;
    [SerializeField] private Text achievementText;
    [SerializeField] private Text reputation;
    [SerializeField] GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public int sceneVisitNum;
    public string name;
    [SerializeField] private int achievement;

    // Start is called before the first frame update
    void Start()
    {
        sceneVisitNum = PlayerPrefs.GetInt("sceneVisitNum");
        achievement = PlayerPrefs.GetInt("achievement");
        name = PlayerPrefs.GetString("name");
        if (sceneVisitNum == 0)
        {
            startFrame.gameObject.SetActive(true);
        }
        sceneVisitNum = 1;
        PlayerPrefs.SetInt("sceneVisitNum", sceneVisitNum);
        PlayerPrefs.SetInt("achievement", achievement);
        PlayerPrefs.SetString("name", name);
        reputation.text = achievement.ToString();
        if(achievement < 10)
        {
            achievementText.text = "견습기사";
            achievementText.color = Color.white;
        }
        else if(achievement >= 10 && achievement < 50)
        {
            achievementText.text = "상급기사";
            achievementText.color = Color.green;
        }
        else if(achievement >= 50 && achievement < 100)
        {
            achievementText.text = "베테랑 기사";
            achievementText.color = Color.yellow;
        }
        else
        {
            achievementText.text = "전설의 기사";
            achievementText.color = Color.red;
        }

    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        realTime.text = currentTime.ToString("HH:mm");
    }
}
