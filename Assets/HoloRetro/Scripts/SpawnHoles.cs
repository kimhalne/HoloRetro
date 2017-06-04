using HoloToolkit.Sharing;
using UnityEngine;
using UnityEngine.VR.WSA.Input;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

//床に視線を向けてタップすると地面に穴用のGameObjectを作成する
[RequireComponent(typeof(GazeManager))]
public class SpawnHoles : MonoBehaviour
{
    GestureRecognizer recognizer;

    public GameObject effect;
    public float DistanceFromCollision = 0.01f;

    void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();
    }

    void OnDestroy()
    {
        recognizer.TappedEvent -= Recognizer_TappedEvent;
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        OnTap();
    }

    void LateUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(1))
        {
            OnTap();
        }
#endif
    }
    private void OnTap()
    {
        var prefab = GameObject.Instantiate(effect);
        Debug.Log(":"+ GazeManager.Instance.HitPosition);
        prefab.transform.position = GazeManager.Instance.HitPosition + GazeManager.Instance.GazeNormal * DistanceFromCollision;
    }
}