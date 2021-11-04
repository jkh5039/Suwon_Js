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


    //�ڵ��� ���� �޴�
    public GameObject carSpec;
    //�ڵ��� ���λ���
    public GameObject detailsAudi;
    public GameObject detailsBenz;
    public GameObject detailsGenesis;
    //��¥ ������?
    public GameObject confirm;
    //ParkingMode �϶��� ����
    public GameObject parkUI;
    public GameObject parkExitNotice;

    //��ŷ���ui
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
        //�ν��ϰ� �˸� �߸� ��� �߰��Ѵ�...
        carSpec.SetActive(true);
    }
    public void onClickExit()
    {
        confirm.SetActive(true);

        //�������� ������@

    }

    

    //2�� �������� �̷��� �ݺ�
    public void OnClickDetails()
    {
        //��Ȳ 3������ ���� 
        if (MultiImage.instance.isAudi)
        {
            //��ư ������ ���λ��� ������
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
        //��Ȳ 3������ ���� 
        if (MultiImage.instance.isAudi)
        {
            //��ư ������ ���λ��� ������
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
        //-----���� Ȯ���ϰ� ���� ���ܳ��� â
        confirm.SetActive(false);
        carSpec.SetActive(false);
        MultiImage.instance.isNotice = true;

        //��ĥ ���� �����ϱ� is(���̸�) off
        MultiImage.instance.isAudi = false;
        MultiImage.instance.isBenz = false;
        MultiImage.instance.isGenesis = false;

        SceneManager.LoadScene("KH_Menu");

        //ARManager.instance.isIndicator = true;

        //bool �ȵǴ��͵� true ��Ų��. �ӽù������� �ѹ��� �ǰ���! //��ħ---- �������
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
        //indicator ������ ��Ȱ��ȭ, parking ������ Ȱ��ȭ �Ѵ�.
        ARManager.instance.isIndicator = false;
    }
    public void onClickParking()
    {
        
        //ȭ�� ������ AR ���·� ����
        carSpec.SetActive(false);
        parkUI.SetActive(true);
        //������ isPark �����Ų��
        ARManager.instance.isPark = true;
        //isNotice ���������ϰ�
        MultiImage.instance.isNotice = false;
        //indicator Ȱ��ȭ
        ARManager.instance.isIndicator = true;

        //parkingModeUI ǥ���Ѵ�
        
    }

    public void onClickParkingX()
    {
        parkExitNotice.SetActive(true);
        ARManager.instance.isIndicator = false;
    }
    
    public void onClickParkingNoticeO()
    {
        parkUI.SetActive(false);
        //������ isPark �����Ų�� (�ϴ� ���������� ����)
        ARManager.instance.isPark = true;
        //isNotice ���������ϰ�
        MultiImage.instance.isNotice = false;
        //indicator Ȱ��ȭ
        ARManager.instance.isIndicator = false;
        parkingMode.SetActive(true); //��ŷ���Ų��

        //����ȭ������
        SceneManager.LoadScene("KH_Menu");
    }
    public void onClickParkingNoticeX()
    {
        parkExitNotice.SetActive(false);
        ARManager.instance.isIndicator = true;
    }
}
