using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] fruit;
    public Transform genTransform;
    public float timeCheck;
    public bool isGen;

    public int Point;
    public int BestScore;

    public static event Action<int> OnPointChanged;
    public static event Action<int> OnBestScoreChanged;

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen ==  false)
        {
            timeCheck -= Time.deltaTime;
            if(timeCheck <= 0.0f)
            {
                int RandNum = UnityEngine.Random.Range(0, 3);
                GameObject Temp = Instantiate(fruit[RandNum]);
                Temp.transform.position = genTransform.position;
                isGen = true;
            }
        }
    }

    public void GenObject()
    {
        isGen = false;
        timeCheck = 1.0f;
    }

    public void MergeObject(int index, Vector3 position)
    {
        GameObject Temp = Instantiate(fruit[index + 1]);
        Temp.transform.position = position;
        Temp.GetComponent<circleObject>().Used();

        Point += (int)MathF.Pow(index, 2) * 10;
        OnPointChanged?.Invoke(Point);
    }

    public void EndGame()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");
        if(Point > BestScore)
        {
            BestScore = Point;
            PlayerPrefs.SetInt("BestScore", BestScore);
            OnBestScoreChanged?.Invoke(BestScore);
        }
    }
}
