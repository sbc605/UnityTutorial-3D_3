using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver receiver;
    public SignalAsset signal;

    public void OnTimelineSpeed(float speed)
    {
        // Ÿ�Ӷ����� �ӵ� ����
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    // �ñ׳ο� �̺�Ʈ�� ����ϴ� �Լ�
    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent(); // �̺�Ʈ�� ��� ����

        eventContainer.AddListener(() => OnTimelineSpeed(0.2f)); // �̺�Ʈ ���

        receiver.AddReaction(signal, eventContainer);
    }
}
