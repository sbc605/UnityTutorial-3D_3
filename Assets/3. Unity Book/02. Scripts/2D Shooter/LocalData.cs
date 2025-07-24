using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            
            
            // 로컬 데이터 저장
            PlayerPrefs.SetInt("Score", score);

            int loadScore = PlayerPrefs.GetInt("Score");
            
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.SetString("UserName", "John");

            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Volume");
            PlayerPrefs.DeleteKey("UserName");
            
            PlayerPrefs.DeleteAll();

            PlayerPrefs.Save(); // 종료될 때 자동 실행
        }
    }
}