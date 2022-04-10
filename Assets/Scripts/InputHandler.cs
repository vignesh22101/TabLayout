using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] private float longPressDuration;

    private Comp selectedContent;
    private bool isTouchCancelled;
    private float touchBeganTime;
    #endregion

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            print($"touch,{touch.deltaPosition.magnitude}");

            if (!isTouchCancelled)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    selectedContent = null;
                    touchBeganTime = Time.realtimeSinceStartup;
                    EventSystem.current.currentSelectedGameObject.TryGetComponent<Comp>(out selectedContent);
                }

                if (touch.deltaPosition.magnitude > 3f)
                    touchBeganTime = Time.realtimeSinceStartup;

                if (Time.realtimeSinceStartup - touchBeganTime > longPressDuration && selectedContent != null)
                {
                    ContentExtension.instance.EnableExtension(selectedContent);
                    isTouchCancelled = true;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                isTouchCancelled = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            EventSystem.current.currentSelectedGameObject.TryGetComponent<Comp>(out selectedContent);

            if (selectedContent != null)
            {
                ContentExtension.instance.EnableExtension(selectedContent);
                isTouchCancelled = true;
            }
        }
    }
}
