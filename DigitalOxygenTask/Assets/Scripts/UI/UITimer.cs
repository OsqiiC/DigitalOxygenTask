using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    private Text text;
    private float time;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    public void ShowTime()
    {
        text.text = $"{time - time % 1} seconds";
    }
}
