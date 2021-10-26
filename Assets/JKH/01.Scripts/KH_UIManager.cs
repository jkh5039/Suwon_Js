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
        carSpec.SetActive(false);
        //bool �ȵǴ��͵� true ��Ų��.

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
        SceneManager.LoadScene("JHW_MiniGame1");
    }
}
