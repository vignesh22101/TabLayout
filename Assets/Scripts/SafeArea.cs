using UnityEngine;


public class SafeArea : MonoBehaviour
{
    public static SafeArea instance;

    RectTransform Panel;
    Rect LastSafeArea = new Rect(0, 0, 0, 0);

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Panel = GetComponent<RectTransform>();
        Refresh();
    }

    private void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        Rect safeArea = GetSafeArea();

        if (safeArea != LastSafeArea)
            ApplySafeArea(safeArea);
    }

    Rect GetSafeArea()
    {
        Debug.Log($"safeArea:{Screen.safeArea}");
        return Screen.safeArea;
    }

    void ApplySafeArea(Rect r)
    {
        LastSafeArea = r;

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;
    }
}
