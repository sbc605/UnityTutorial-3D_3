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
        // 타임라인의 속도 제어
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    // 시그널에 이벤트를 등록하는 함수
    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent(); // 이벤트를 담는 변수

        eventContainer.AddListener(() => OnTimelineSpeed(0.2f)); // 이벤트 등록

        receiver.AddReaction(signal, eventContainer);
    }
}
