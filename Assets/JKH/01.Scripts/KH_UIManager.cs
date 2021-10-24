using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KH_UIManager : MonoBehaviour
{
    //자동차 스펙 메뉴
    public GameObject carSpec;
    //자동차 세부사항
    public GameObject details;
    // Start is called before the first frame update
    void Start()
    {
        //details.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAudi()
    {
        //인식하고 알림 뜨면 요거 뜨게한다...
        carSpec.SetActive(true);
    }
    
    public void OnClickAudiDetails()
    {
        //버튼 누르면 세부사항 켜진다
        details.SetActive(true);
    }
    public void OnClickParking()
    {
        //버튼누르면 씬 전환
        SceneManager.LoadScene("JHW_MiniGame1");
    }
}
