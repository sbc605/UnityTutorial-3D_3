using UnityEngine;

public class SingletonEx2 : MonoBehaviour
{
    public static SingletonEx2 Instance
    {
        get; // 접근 가능
        private set; // 수정 불가
    }

    void Awake()
    {
        if (Instance == null) // Instance가 비어있으면 자신(this)을 할당
        {
            Instance = this; 
        }
        else // 이미 SingletonEx2가 존재하면 this 스크립트 삭제 -> 중복 생성 방지
        {
            Destroy(gameObject);
        }
    }
}