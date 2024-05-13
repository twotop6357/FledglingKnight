using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject skeleton;
    public GameObject archer;
    [SerializeField] private string playerTag;
    public ObjectPool ObjectPool {  get; private set; }
    public Transform Player { get; private set; }

    private void Awake()
    {
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
}
