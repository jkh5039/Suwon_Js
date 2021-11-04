using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KH_UIManager : MonoBehaviour
{
    public static KH_UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //자동차 스펙 메뉴
    public GameObject carSpec;
    //자동차 세부사항
    public GameObject detailsAudi;
    public GameObject detailsBenz;
    public GameObject detailsGenesis;
    //진짜 나가게?
    public GameObject confirm;
    //ParkingMode 일때만 실행
    public GameObject parkUI;
    public GameObject parkExitNotice;

    //파킹모드ui
    public GameObject parkingMode;

    // Start is called before the first frame update
    void Start()
    {
        //details.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCarSpec()
    {
        //인식하고 알림 뜨면 요거 뜨게한다...
        carSpec.SetActive(true);
    }
    public void onClickExit()
    {
        confirm.SetActive(true);

        //컨펌으로 가져감@

    }

    

    //2개 나머지도 이렇게 반복
    public void OnClickDetails()
    {
        //상황 3가지에 따른 
        if (MultiImage.instance.isAudi)
        {
            //버튼 누르면 세부사항 켜진다
            detailsAudi.SetActive(true);
        }
        else if (MultiImage.instance.isBenz)
        {
            detailsBenz.SetActive(true);
        }
        else if (MultiImage.instance.isGenesis)
        {
            detailsGenesis.SetActive(true);
        }


    }
    public void onClickDetailsBack()
    {
        //상황 3가지에 따른 
        if (MultiImage.instance.isAudi)
        {
            //버튼 누르면 세부사항 켜진다
            detailsAudi.SetActive(false);
        }
        else if (MultiImage.instance.isBenz)
        {
            detailsBenz.SetActive(false);
        }
        else if (MultiImage.instance.isGenesis)
        {
            detailsGenesis.SetActive(false);
        }
    }
    
    

    public void onClickConfirmO()
    {
        //-----정보 확인하고 끌때 생겨나는 창
        confirm.SetActive(false);
        carSpec.SetActive(false);
        MultiImage.instance.isNotice = true;

        //겹칠 수도 있으니까 is(차이름) off
        MultiImage.instance.isAudi = false;
        MultiImage.instance.isBenz = false;
        MultiImage.instance.isGenesis = false;

        SceneManager.LoadScene("KH_Menu");

        //ARManager.instance.isIndicator = true;

        //bool 안되던것들 true 시킨다. 임시방편으로 한번만 되게함! //고침---- 여기까지
    }
    public void onClickConfirmX()
    {
        confirm.SetActive(false);
    }

    //NEW Btn@@@@
    public void onClickDrive()
    {
        JHW_SoundManager.instance.PlayButtonClick();
        SceneManager.LoadScene("JHW_MiniGame2");
    }

    public void onClickParkAndRecognition()
    {
        SceneManager.LoadScene("KH_ARDetect");
        MultiImage.instance.isNotice = true;
        //indicator 지금은 비활성화, parking 누를떄 활성화 한다.
        ARManager.instance.isIndicator = false;
    }
    public void onClickParking()
    {
        
        //화면 꺼지고 AR 상태로 간다
        carSpec.SetActive(false);
        parkUI.SetActive(true);
        //누를때 isPark 실행시킨다
        ARManager.instance.isPark = true;
        //isNotice 안켜지게하고
        MultiImage.instance.isNotice = false;
        //indicator 활성화
        ARManager.instance.isIndicator = true;

        //parkingModeUI 표시한다
        
    }

    public void onClickParkingX()
    {
        parkExitNotice.SetActive(true);
        ARManager.instance.isIndicator = false;
    }
    
    public void onClickParkingNoticeO()
    {
        parkUI.SetActive(false);
        //누를때 isPark 실행시킨다 (일단 무지성으로 적음)
        ARManager.instance.isPark = true;
        //isNotice 안켜지게하고
        MultiImage.instance.isNotice = false;
        //indicator 활성화
        ARManager.instance.isIndicator = false;
        parkingMode.SetActive(true); //파킹모드킨다

        //메인화면으로
        SceneManager.LoadScene("KH_Menu");
    }
    public void onClickParkingNoticeX()
    {
        parkExitNotice.SetActive(false);
        ARManager.instance.isIndicator = true;
    }
}
