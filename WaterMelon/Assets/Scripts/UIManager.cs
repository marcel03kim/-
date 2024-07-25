using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI 관련 코드를 사용하기 위한 using문

public class UIManager : MonoBehaviour   //다 되면 말해주세용
{
    public Text pointText;    //이 텍스트 변수에 현재 점수를 저장
    public Text BestScoreText;   //이 텍스트 변수에 최고 점수를 저장

    private void OnEnable()           //Scene에서 활성화 되었을 때 호출되는 함수
    {
        GameManager.OnPointChanged += UpdatePoint;  //이벤트 등록
        GameManager.OnBestScoreChanged += UpdateBestScore;  //이벤트 등록
    }

    private void OnDisable()        //Scene에서 비활성화 되었을 때 호출되는 함수  
    {
        GameManager.OnPointChanged -= UpdatePoint;  //이벤트 삭제
        GameManager.OnBestScoreChanged -= UpdateBestScore;  //이벤트 삭제
    }
    void UpdatePoint(int newPoint)     //현재 점수를 텍스트에 실시간으로 반영하기 위한 메서드
    {
        pointText.text = "Point : " + newPoint; 
    }
    void UpdateBestScore(int newBestScore) //최고 점수를 텍스트에 실시간으로 반영하기 위한 메서드
    {
        BestScoreText.text = "BestScore : " + newBestScore;
    }
}
