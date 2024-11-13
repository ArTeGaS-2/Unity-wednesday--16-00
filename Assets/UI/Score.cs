using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int score = 0;
    public TextMeshProUGUI text;
    private void Start()
    {
        Instance = this;
    }
    public void AddScore()
    {
        score++;
        text.text = $"Зібрано:{score}";
    }
}
