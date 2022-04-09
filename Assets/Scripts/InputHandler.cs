using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    #region Variables
    [SerializeField] private float longPressDuration;

    private Content selectedContent;
    private bool isTouchCancelled;
    private float touchBeganTime;
    #endregion

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (!isTouchCancelled)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    selectedContent = null;
                    touchBeganTime = Time.realtimeSinceStartup;
                    EventSystem.current.currentSelectedGameObject.TryGetComponent<Content>(out selectedContent);
                }

                if (touch.phase == TouchPhase.Moved)
                    touchBeganTime = Time.realtimeSinceStartup;

                if (Time.realtimeSinceStartup - touchBeganTime > longPressDuration && selectedContent!=null)
                {
                    ContentExtension.instance.EnableExtension(selectedContent,touch.position);
                    isTouchCancelled = true;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                isTouchCancelled = false;
        }
    }
}
