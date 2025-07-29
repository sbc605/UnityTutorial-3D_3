using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line; // 생성된 라인 렌더러
    private int lineCount = 0;
    private int lineObjectCount = 1;

    public Color color; // 라인 색상
    public float lineWidth = 0.05f; // 라인 굵기
    public float minDistance = 0.03f; // 최소 거리 (이 거리 이상 벗어나야 새로운 점 추가)

    public List<GameObject> lineObjs = new List<GameObject>(); // 생성한 Line이 담길 List

    private void Start()
    {
        color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        // 마우스를 처음 누르는 순간 = start 위치 -> 선 그리기 시작
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineObject = new GameObject("Line Object"); // 빈게임오브젝트 생성(괄호안은 이름)
            lineObjectCount++;

            line = lineObject.AddComponent<LineRenderer>(); // 빈게임오브젝트에 LineRenderer 추가, 현재 조작할 Line 설정
            line.useWorldSpace = false;
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;

            line.startColor = color;
            line.endColor = color;

            line.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

            lineObjs.Add(line.gameObject);
        }

        // 마우스를 드래그하면 선이 따라옴 -> 선 그리는 중
        if (Input.GetMouseButton(0))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 10f; // nearPlane이라는 카메라 최소거리값이 0.01f라 카메라에 보여주기 위해 z축을 앞으로 밈
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // 월드 상에 마우스 위치

            Vector3 lastPosition = line.GetPosition(lineCount - 1); // 마지막 점의 위치
            float distance = Vector3.Distance(lastPosition, worldPos);

            if (distance > minDistance)
            {
                line.positionCount = ++lineCount; // 1을 더해서 넣음
                line.SetPosition(lineCount - 1, worldPos); // 인덱서 값이라 -1 
            }
        }

        // 마우스를 떼면 작성 중인 선이 끝
        if (Input.GetMouseButtonUp(0))
        {
            // Destroy(line); // 이거 추가해서 떼면 지워짐
            lineCount = 0; // 마우스 뗐다 다시 누르면 새로운 거 만들기 위한 변수
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 누르면 현재 오브젝트 다 지움
        {
            foreach (var line in lineObjs)
            {
                Destroy(line);
            }

            lineObjs.Clear();
        }
    }
}
