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
    public GameObject details;
    //��¥ ������?
    public GameObject confirm;
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
        //�ν��ϰ� �˸� �߸� ��� �߰��Ѵ�...
        carSpec.SetActive(true);
    }
    public void onClickExit()
    {
        confirm.SetActive(true);

        //�������� ������@

    }
    public void OnClickAudiDetails()
    {
        //��ư ������ ���λ��� ������
        details.SetActive(true);
    }
    public void onClickAudiDetailsBack()
    {
        details.SetActive(false);
    }
    public void OnClickParking()
    {
        //��ư������ �� ��ȯ
        //SceneManager.LoadScene("JHW_MiniGame1");
    }
    

    public void onClickConfirmO()
    {
        //-----���� Ȯ���ϰ� ���� ���ܳ��� â
        confirm.SetActive(false);
        carSpec.SetActive(false);
        MultiImage.instance.isNotice = true;
        ARManager.instance.isIndicator = true;
        
        //bool �ȵǴ��͵� true ��Ų��. �ӽù������� �ѹ��� �ǰ���! //��ħ---- �������
    }
    public void onClickConfirmX()
    {
        confirm.SetActive(false);
    }

    //NEW Btn@@@@
    public void onClickDrive()
    {
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
        //isNotice ���������ϰ�
        MultiImage.instance.isNotice = false;
        //indicator Ȱ��ȭ
        ARManager.instance.isIndicator = true;
    }
}
