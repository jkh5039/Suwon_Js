using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KH_UIManager : MonoBehaviour
{
    public GameObject AudiSpec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAudi()
    {
        AudiSpec.SetActive(true);
    }
    
    public void OnClickAudiDetails()
    {
        //¾Æ¿ìµð Detail.SetActive(True)
    }
    public void OnClickParking()
    {
        SceneManager.LoadScene("JHW_MiniGame1");
    }
}
