using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;

    public GameObject dot_1, dot_2, dot_3;
    private void Start()
    {
        StartCoroutine(AnimateDots());
    }
    private IEnumerator AnimateDots()
    {
        Time.timeScale = 0f;

        for (int i = 0; i < 3; i++)
        {
            dot_1.transform.localScale = new Vector2(2f, 2f);
            yield return new WaitForSecondsRealtime(0.1f);
            dot_1.transform.localScale = new Vector2(1f, 1f);

            dot_2.transform.localScale = new Vector2(2f, 2f);
            yield return new WaitForSecondsRealtime(0.1f);
            dot_2.transform.localScale = new Vector2(1f, 1f);

            dot_3.transform.localScale = new Vector2(2f, 2f);
            yield return new WaitForSecondsRealtime(0.1f);
            dot_3.transform.localScale = new Vector2(1f, 1f);
        }
        Time.timeScale = 1f;
        loadingScreen.SetActive(false);
    }
}
