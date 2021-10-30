using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


//�̹��� �̸�, �ش� �̹����� �νĵǾ����� ��Ÿ���� ������Ʈ
//structure
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
    //public Image brandLogo2;

    public static MultiImage instance;

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
                                carName + " was recognized." + "\n"
                                + carName + "Do you want to confirm?";
                        notice.SetActive(true);
                        //notice�� �߸� indicator �ȶ߰� �Ѵ�
                        ARManager.instance.isIndicator = false;
                        

                        if (markerInfos[j].name == "Audi")
                        {
                            //OX�� �� ���̸�
                            carName = "Audi";
                            //�ΰ� ���� ����
                            brandLogo1.sprite = markerInfos[j].LogoImg;
                            
                            

                            //�ڵ����� ���� �� ����
                            brandName.text = "2021 Audi A6"; //2021 Audi A6
                            Price.text = "74,000$"; //74,000$
                            GasMileage.text = "11.8km/��"; //11.8km/��
                            maxSpeed.text = "210km/h"; //210km/h
                            Fuel.text = "gasoline, diesel"; //gasoline, diesel
                            Appearance.text = "sedan"; //sedan



                            //�󼼳����� �׳� ���� �����....�ϳ��ϳ� ������


                        }
                        else if (markerInfos[j].name == "Benz") //�����Ѵ�
                        {
                            //OX�� �� ���̸�
                            carName = "Benz";
                            //�ΰ� ���� ����
                            brandLogo1.sprite = markerInfos[j].LogoImg;
                            


                            //�ڵ����� ���� �� ����
                            brandName.text = "Mercedes-Benz S-350d"; //2021 Audi A6
                            Price.text = "120,000$"; //74,000$
                            GasMileage.text = "12.0 km/��"; //11.8km/��
                            maxSpeed.text = "250km/h"; //210km/h
                            Fuel.text = "diesel"; //gasoline, diesel
                            Appearance.text = "sedan"; //sedan
                        }

                        else if (markerInfos[j].name == "Genesis") //�����Ѵ�
                        {
                            //OX�� �� ���̸�
                            carName = "Genesis";
                            //�ΰ� ���� ����
                            brandLogo1.sprite = markerInfos[j].LogoImg;



                            //�ڵ����� ���� �� ����
                            brandName.text = "Genesis G70"; //2021 Audi A6
                            Price.text = "34,000$"; //74,000$
                            GasMileage.text = "10.7 km/��"; //11.8km/��
                            maxSpeed.text = "200km/h"; //210km/h
                            Fuel.text = "gasoline"; //gasoline, diesel
                            Appearance.text = "sedan"; //sedan
                        }

                        //�󼼳����� ��obj �߰�

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
