using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer line; // ������ ���� ������
    private int lineCount = 0;
    private int lineObjectCount = 1;

    public Color color; // ���� ����
    public float lineWidth = 0.05f; // ���� ����
    public float minDistance = 0.03f; // �ּ� �Ÿ� (�� �Ÿ� �̻� ����� ���ο� �� �߰�)

    public List<GameObject> lineObjs = new List<GameObject>(); // ������ Line�� ��� List

    private void Start()
    {
        color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        // ���콺�� ó�� ������ ���� = start ��ġ -> �� �׸��� ����
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineObject = new GameObject("Line Object"); // ����ӿ�����Ʈ ����(��ȣ���� �̸�)
            lineObjectCount++;

            line = lineObject.AddComponent<LineRenderer>(); // ����ӿ�����Ʈ�� LineRenderer �߰�, ���� ������ Line ����
            line.useWorldSpace = false;
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;

            line.startColor = color;
            line.endColor = color;

            line.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));

            lineObjs.Add(line.gameObject);
        }

        // ���콺�� �巡���ϸ� ���� ����� -> �� �׸��� ��
        if (Input.GetMouseButton(0))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 10f; // nearPlane�̶�� ī�޶� �ּҰŸ����� 0.01f�� ī�޶� �����ֱ� ���� z���� ������ ��
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // ���� �� ���콺 ��ġ

            Vector3 lastPosition = line.GetPosition(lineCount - 1); // ������ ���� ��ġ
            float distance = Vector3.Distance(lastPosition, worldPos);

            if (distance > minDistance)
            {
                line.positionCount = ++lineCount; // 1�� ���ؼ� ����
                line.SetPosition(lineCount - 1, worldPos); // �ε��� ���̶� -1 
            }
        }

        // ���콺�� ���� �ۼ� ���� ���� ��
        if (Input.GetMouseButtonUp(0))
        {
            // Destroy(line); // �̰� �߰��ؼ� ���� ������
            lineCount = 0; // ���콺 �ô� �ٽ� ������ ���ο� �� ����� ���� ����
        }

        if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� ������ ���� ������Ʈ �� ����
        {
            foreach (var line in lineObjs)
            {
                Destroy(line);
            }

            lineObjs.Clear();
        }
    }
}
