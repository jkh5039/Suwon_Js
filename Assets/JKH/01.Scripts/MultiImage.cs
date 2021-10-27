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
    public Sprite LogoImg;
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

    //canvasInfo's informations
    public Text brandName;
    public Text Price;
    public Text GasMileage;
    public Text maxSpeed;
    public Text Fuel;
    public Text Appearance;
    public Image brandLogo1;
    public Image brandLogo2;

    

    // Start is called before the first frame update
    void Start()
    {
        isNotice = true;
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
                    if (trackedImage.trackingState == TrackingState.Tracking&& isNotice==true)
                    {

                        noticeCarName.text =
                                carName + "���� �νĵǾ����ϴ�." + "\n"
                                + carName + "���� ���� ������ Ȯ�� �Ͻðڽ��ϱ�?";
                        notice.SetActive(true);
                        //notice�� �߸� indicator �ȶ߰� �Ѵ�
                        ARManager.instance.isIndicator = false;
                        

                        if (markerInfos[j].name == "Audi")
                        {
                            carName = "Audi";
                            brandLogo1.sprite = markerInfos[j].LogoImg;
                            brandLogo2.sprite = markerInfos[j].LogoImg;
                            //�ؽ�Ʈ ����


                            //�ڵ����� ���� �� ����
                            brandName.text = "�� �̸�";
                            Price.text = "����";
                            GasMileage.text = "����";
                            maxSpeed.text = "�ְ�ӷ�";
                            Fuel.text = "����";
                            Appearance.text = "�� ����";



                            //�󼼳����� �׳� ���� �����....


                        }
                        else if (markerInfos[j].name == "  ")
                        {
                            carName = "  "; // carName ���� �Է�
                            //
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
        KH_UIManager.instance.OnAudi();
        notice.SetActive(false);
        isNotice = false;
        //����ٰ�?
    }

    public void OnClickNotice_X()
    {
        //Notice UI ����
        notice.SetActive(false);
    }
}
