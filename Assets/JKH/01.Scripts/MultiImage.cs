using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

//이미지 이름, 해당 이미지가 인식되었을떄 나타나는 오브젝트
[System.Serializable]
public struct MarkerInfo
{
    public string name;
    public GameObject obj;
}
public class MultiImage : MonoBehaviour
{
    //마커의 정보들
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
        //인식된 이미지 정보들이 변경되면 호출해주는 함수 등록.
        trackedMgr.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        //변경된 내용의 갯수만큼 반복
        for (int i = 0; i < args.updated.Count; i++) //인식된 args의 갯수 
        {
            ARTrackedImage trackedImage = args.updated[i]; //Update를 담아둔다.
            for (int j = 0; j < markerInfos.Length; j++)
            {
                //만약에 Update된 이미지의 이름과 정의한 이미지 이름과 같다면
                if (trackedImage.referenceImage.name == markerInfos[j].name)
                {
                    //만약에 이미지를 트래킹(인식) 하고 있다면,
                    if (trackedImage.trackingState == TrackingState.Tracking)
                    {
                        
                        
                        notice.SetActive(true);
                        noticeCarName.text =
                                carName + "차가 인식되었습니다." + "\n"
                                + carName + "차에 대한 정보를 확인 하시겠습니까?";
                        if (markerInfos[j].name == "Audi")
                        {

                            //텍스트 변경
                            carName = "Audi";
                            //만약 CarName 여러개해서 변수 넣는다
                            
                        }


                    }
                    //그렇지않고(만약 벗어났다면)
                    else
                    {
                        //정의한 obj비활성화
                        markerInfos[j].obj.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        //인식된 이미지 정보들이 변경되면 호출해주는 함수 해제.
        trackedMgr.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Notice 버튼 구현
    public void OnClickNotice_O()
    {
        //그 해당 자동차의 UI를 보여준다
        //여기다가?
    }

    public void OnClickNotice_X()
    {
        //Notice UI 끈다
        notice.SetActive(false);
    }
}
