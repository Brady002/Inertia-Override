using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float currentTime;
    public TMP_Text timer;

    [SerializeField]
    public bool timerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartTimer", 10f);
    }

    private void StartTimer()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            currentTime += Time.deltaTime;
            timer.text = "Time: " + currentTime;
        }
        
    }

}
