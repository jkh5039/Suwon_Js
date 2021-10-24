using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

//�̹��� �̸�, �ش� �̹����� �νĵǾ����� ��Ÿ���� ������Ʈ
[System.Serializable]
public struct MarkerInfo
{
    public string name;
    public GameObject obj;
}
public class MultiImage : MonoBehaviour
{
    //��Ŀ�� ������
    public MarkerInfo[] markerInfos;
    //ARTrackedImageManager
    ARTrackedImageManager trackedMgr;
    //Notice UI
    public GameObject notice;
    public Text noticeCarName;
    string carName;
    public bool isNotice;

    // Start is called before the first frame update
    void Start()
    {
        trackedMgr = GetComponent<ARTrackedImageManager>();
        //�νĵ� �̹��� �������� ����Ǹ� ȣ�����ִ� �Լ� ���.
        trackedMgr.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        //����� ������ ������ŭ �ݺ�
        for (int i = 0; i < args.updated.Count; i++) //�νĵ� args�� ���� 
        {
            ARTrackedImage trackedImage = args.updated[i]; //Update�� ��Ƶд�.
            for (int j = 0; j < markerInfos.Length; j++)
            {
                //���࿡ Update�� �̹����� �̸��� ������ �̹��� �̸��� ���ٸ�
                if (trackedImage.referenceImage.name == markerInfos[j].name)
                {
                    //���࿡ �̹����� Ʈ��ŷ(�ν�) �ϰ� �ִٸ�,
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        
                        
                        notice.SetActive(true);
                        noticeCarName.text =
                                carName + "���� �νĵǾ����ϴ�." + "\n"
                                + carName + "���� ���� ������ Ȯ�� �Ͻðڽ��ϱ�?";
                        if (markerInfos[j].name == "Audi")
                        {

                            //�ؽ�Ʈ ����
                            carName = "Audi";
                            //���� CarName �������ؼ� ���� �ִ´�
                            
                        }


                    }
                    //�׷����ʰ�(���� ����ٸ�)
                    else
                    {
                        //������ obj��Ȱ��ȭ
                        markerInfos[j].obj.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        //�νĵ� �̹��� �������� ����Ǹ� ȣ�����ִ� �Լ� ����.
        trackedMgr.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Notice ��ư ����
    public void OnClickNotice_O()
    {
        //�� �ش� �ڵ����� UI�� �����ش�
        //����ٰ�?
    }

    public void OnClickNotice_X()
    {
        //Notice UI ����
        notice.SetActive(false);
    }
}
