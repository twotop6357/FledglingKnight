using System;
using UnityEngine;
using UnityEngine.UI;

public class TalkWithObject : MonoBehaviour
{
    public int id;
    public bool isNpc;
	public GameObject player;
    public float actionDistance = 1f;
    public TalkManager talkManager;
    public int talkIndex;
    [SerializeField] private Image talkPanel;
    [SerializeField] private Text talkText;

    private void Awake()
    {
        talkIndex = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if(player==null)
            {
                return;
            }
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance <= actionDistance) 
            {
                talkPanel.gameObject.SetActive(true);
                string text;
				try
                {
                    text = talkManager.GetTalk(id, talkIndex++);
                }
                catch(IndexOutOfRangeException)
                {
                    text = null;
                }
                if(text != null)
                {
                    talkText.text = text;
                }
                else
                {
                    talkPanel.gameObject.SetActive(false);
                    talkIndex = 0;
                }
            }
        }
    }
}
