using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JHW_GameManager : MonoBehaviour
{
    public JHW_Car car;

    // Start is called before the first frame update
    void Start()
    {

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
}
