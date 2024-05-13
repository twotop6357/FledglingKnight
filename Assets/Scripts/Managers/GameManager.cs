using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject skeleton;
    public GameObject archer;
    [SerializeField] private string playerTag;
    public ObjectPool ObjectPool {  get; private set; }
    public Transform Player { get; private set; }

    public Text timeText;
    float totalTime = 60.0f;
    bool canLose = true;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image VicFrame;
    [SerializeField] private Image DefFrame;
    public int sceneVisitNum;
    public int achievement;

    private void Awake()
    {
        sceneVisitNum = PlayerPrefs.GetInt("sceneVisitNum");
        achievement = PlayerPrefs.GetInt("achievement");
        if(Instance != null) Destroy(gameObject);
        {
            Instance = this;
        }
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        InvokeRepeating("MakeEnemy", 1f, 1.0f);
    }
    private void Update()
    {
        totalTime -= Time.deltaTime;
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0f;
            totalTime = 0f;
            VicFrame.gameObject.SetActive(true);
            canLose = false;
        }
        timeText.text = totalTime.ToString("N2");
        if (canLose && hpBar.fillAmount <= 0)
        {
            Time.timeScale = 0f;
            DefFrame.gameObject.SetActive(true);
        }
    }
    private void MakeEnemy()
    {
        int rand = Random.Range(0, 10);
        float randPosX = Random.Range(3f, 6.5f);
        float randPosY = Random.Range(-2f, 2f);
        Vector2 pos = new Vector2(randPosX, randPosY);
        
        if (rand < 3)
        {
            archer.transform.position = pos;
            Instantiate(archer, transform);
        }
        else
        {
            skeleton.transform.position = pos;
            Instantiate(skeleton, transform);
        }
    }

    public void LoseReturn()
    {
        PlayerPrefs.SetInt("sceneVisitNum",sceneVisitNum);
        PlayerPrefs.SetInt("achievement", achievement - 10);
        SceneManager.LoadScene("VillageScene");
    }
    public void WinReturn()
    {
        PlayerPrefs.SetInt("sceneVisitNum", sceneVisitNum);
        PlayerPrefs.SetInt("achievement", achievement + 10);
        SceneManager.LoadScene("VillageScene");
    }
}
