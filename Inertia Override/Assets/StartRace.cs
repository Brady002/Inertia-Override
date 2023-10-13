using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartRace : MonoBehaviour
{
    public GameObject barrier;
    public TMP_Text countdown;
    private float time = 10f;
    public List<TimeController> watch = new List<TimeController>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Begin", 1f, 1f);
    }

    private void Begin()
    {
        time -= 1f;
        countdown.text = "Race Begins In: " + time.ToString();
        if(time < 0f)
        {
            barrier.SetActive(false);
            if(time == 0)
            {
                foreach (TimeController watch in watch)
                {
                    watch.timerOn = true;
                }
            }
            
            
        }
    }
}
