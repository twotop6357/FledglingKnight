﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkWithPillar : MonoBehaviour
{
    [SerializeField] private Text nickName;
    public GameObject player;
    public float actionDistance = 1f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player == null)
            {
                return;
            }
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= actionDistance)
            {
                PlayerPrefs.SetString("name", nickName.text);
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}