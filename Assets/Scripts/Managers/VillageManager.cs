using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    [SerializeField] private Image startFrame;
    [SerializeField] private Text realTime;

    // Start is called before the first frame update
    void Start()
    {
        startFrame.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        realTime.text = currentTime.ToString("HH:mm");
    }
}
