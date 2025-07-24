using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L, C, R

    public TextMeshProUGUI countTextUI;
    public Button answerButton;

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;

    void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }
    
    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--) // 반복문으로 Level만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // 도넛 생성
            donut.transform.position = new Vector3(-5f, 5f, 0); // 도넛 생성 위치 : 왼쪽 막대기 + 위쪽

            bars[0].PushDonut(donut); // 방금 생성한 도넛을 해당 Bar의 Stack Push
            
            yield return new WaitForSeconds(1f); // 순차적으로 생성
        }

        moveCount = 0;
        countTextUI.text = moveCount.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);
            
            isSelected = false;
            selectedDonut = null;
        }
        
        countTextUI.text = moveCount.ToString();
    }
    
    public void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2);
    }
    
    private void HanoiRoutine(int n, int from, int temp, int to)
    {
        if (n == 1)
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
        else
        {
            HanoiRoutine(n - 1, from, to, temp);
            Debug.Log($"{n}번 도넛을 {from}에서 {to}로 이동");
            
            HanoiRoutine(n - 1, temp, from, to);
        }
    }
}