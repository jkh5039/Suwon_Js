using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JHW_GameManager : MonoBehaviour
{
    public JHW_Car car;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
       if(SceneManager.GetActiveScene().name == "JHW_MiniGame2")
        {
        Time.timeScale = 0f;
        StartCoroutine(Countdown(3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (car.laps == 3 && SceneManager.GetActiveScene().name == "JHW_MiniGame2")
        {
            SceneManager.LoadScene("JHW_ResultCine");
        }    
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("KH_Menu");
    }

    IEnumerator Countdown(int seconds)
    {
        JHW_SoundManager.instance.PlayCountDown();
        int count = seconds;

        while (count > 0)
        {
            // display something...
            text.text = count.ToString();
            yield return new WaitForSecondsRealtime(1);
            count--;
        }
        if(count ==0)
        {
            text.text = "START !";
            yield return new WaitForSecondsRealtime(1f);
            text.gameObject.SetActive(false);
        }

        Time.timeScale = 1f;
    }
}
