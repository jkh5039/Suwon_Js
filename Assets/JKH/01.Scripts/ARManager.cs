using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARManager : MonoBehaviour
    //1
{
    public GameObject indicator; //indicator
    public GameObject carFactory; //�ڵ�������
    ARRaycastManager arRayManager;
    public bool useAR;
    public GameObject ground;
    public CamRotate camRotae;

    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();

        //���� ar�� ����Ѵٸ�
        if (useAR)
        {
            //���� ��Ȱ��ȭ�Ѵ�
            ground.SetActive(false);
            //CamRotate ��ȭ��ȭ�Ѵ�
            camRotae.enabled = false;
        }
    }

    
    void Update()
    {
        //ī�޶���ġ, ī�޶� �չ��⿡�� �߻�Ǵ� ���̸� �����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //���࿡ ray�� �߻��ؼ� �ε��� ���� �ִٸ�

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
            RaycastHit hit; //PC����
            if (Physics.Raycast(ray, out hit))
            {
                SetIndicator(hit.point);
            }
            //�׷��� ������ indacator ��Ȱ��ȭ�Ѵ�
            else
            {
                indicator.SetActive(false);
            }
        }





        //���࿡ ���콺 ����Ŭ���� �Ѵٸ�
        //���࿡ indicator�� Ȱ��ȭ ���¶��
        if (Input.GetButtonDown("Fire1") && indicator.activeSelf)
        {
            //�ڵ��� ���忡�� �ڵ��� ����
            GameObject car = Instantiate(carFactory);
            //������ �ڵ����� indicator��ġ�� ���´�
            car.transform.position = indicator.transform.position;
            //������ �ڵ����� �չ����� indicator�� �չ������� �Ѵ�
            car.transform.forward = indicator.transform.forward;


        }
    }
    void SetIndicator(Vector3 pos)
    {
        //indicator�� Ȱ��ȭ �ϰ� �ε��� ��ġ�� ���´�
        indicator.SetActive(true);
        indicator.transform.position = pos;

        //indicator�� �չ����� ī�޶��� �չ������� �ϰ��Ѵ� (���� �ȹ������ϱ� �߿�)
        Vector3 dir = Camera.main.transform.forward;
        dir.y = 0;
        indicator.transform.forward = dir;
    }

}
