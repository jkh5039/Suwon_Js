using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARManager : MonoBehaviour
    //1
{
    public GameObject indicator; //indicator
    public GameObject carFactory; //자동차공장
    ARRaycastManager arRayManager;
    public bool useAR;
    public GameObject ground;
    public CamRotate camRotae;

    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();

        //만약 ar을 사용한다면
        if (useAR)
        {
            //땅을 비활성화한다
            ground.SetActive(false);
            //CamRotate 비화성화한다
            camRotae.enabled = false;
        }
    }

    
    void Update()
    {
        //카메라위치, 카메라 앞방향에서 발사되는 레이를 만든다
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //만약에 ray를 발사해서 부딪힌 곳이 있다면

        if (useAR)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRayManager.Raycast(ray, hits))
            {
                SetIndicator(hits[0].pose.position);
            }
            else
            {
                indicator.SetActive(false);
            }
        }

        else
        {
            RaycastHit hit; //PC전용
            if (Physics.Raycast(ray, out hit))
            {
                SetIndicator(hit.point);
            }
            //그렇지 않으면 indacator 비활성화한다
            else
            {
                indicator.SetActive(false);
            }
        }





        //만약에 마우스 왼쪽클릭을 한다면
        //만약에 indicator가 활성화 상태라면
        if (Input.GetButtonDown("Fire1") && indicator.activeSelf)
        {
            //자동차 공장에서 자동차 생성
            GameObject car = Instantiate(carFactory);
            //생성된 자동차를 indicator위치에 놓는다
            car.transform.position = indicator.transform.position;
            //생성된 자동차의 앞방향을 indicator의 앞방향으로 한다
            car.transform.forward = indicator.transform.forward;


        }
    }
    void SetIndicator(Vector3 pos)
    {
        //indicator를 활성화 하고 부딪힌 위치에 놓는다
        indicator.SetActive(true);
        indicator.transform.position = pos;

        //indicator의 앞방향을 카메라의 앞방향으로 하게한다 (땅에 안박히게하기 중요)
        Vector3 dir = Camera.main.transform.forward;
        dir.y = 0;
        indicator.transform.forward = dir;
    }

}
