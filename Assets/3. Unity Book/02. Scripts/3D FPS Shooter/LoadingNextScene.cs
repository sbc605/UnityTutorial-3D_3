using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num); // ������ ���� �񵿱� �ε��Ѵ�.

        // �ε� �Ϸ� �� �ٷ� �Ѿ�� �ʰ� ��� ������
        ao.allowSceneActivation = false; // ���ϴ� ������ �ε��ϱ� ���� ��� ����

        while (!ao.isDone)
        {
            loadingSlider.value = ao.progress;
            loadingText.text = $"{ao.progress * 100f}%"; // 0~1�� ���ͼ� 100����
            
            if (ao.progress >= 0.9f)
                ao.allowSceneActivation = true;

            yield return null;
        }
    }    
}
