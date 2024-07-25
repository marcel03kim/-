using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI ���� �ڵ带 ����ϱ� ���� using��

public class UIManager : MonoBehaviour   //�� �Ǹ� �����ּ���
{
    public Text pointText;    //�� �ؽ�Ʈ ������ ���� ������ ����
    public Text BestScoreText;   //�� �ؽ�Ʈ ������ �ְ� ������ ����

    private void OnEnable()           //Scene���� Ȱ��ȭ �Ǿ��� �� ȣ��Ǵ� �Լ�
    {
        GameManager.OnPointChanged += UpdatePoint;  //�̺�Ʈ ���
        GameManager.OnBestScoreChanged += UpdateBestScore;  //�̺�Ʈ ���
    }

    private void OnDisable()        //Scene���� ��Ȱ��ȭ �Ǿ��� �� ȣ��Ǵ� �Լ�  
    {
        GameManager.OnPointChanged -= UpdatePoint;  //�̺�Ʈ ����
        GameManager.OnBestScoreChanged -= UpdateBestScore;  //�̺�Ʈ ����
    }
    void UpdatePoint(int newPoint)     //���� ������ �ؽ�Ʈ�� �ǽð����� �ݿ��ϱ� ���� �޼���
    {
        pointText.text = "Point : " + newPoint; 
    }
    void UpdateBestScore(int newBestScore) //�ְ� ������ �ؽ�Ʈ�� �ǽð����� �ݿ��ϱ� ���� �޼���
    {
        BestScoreText.text = "BestScore : " + newBestScore;
    }
}
