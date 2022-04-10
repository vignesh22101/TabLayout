using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ContentExtension : MonoBehaviour
{
    #region Variables
    internal static ContentExtension instance;

    [SerializeField] private InputField inputField;

    private Comp targetContent;
    private Camera mainCamera;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    #endregion

    //Singleton pattern
    private void Awake()
    {
        mainCamera = Camera.main;

        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(this);
        }

        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void EnableExtension()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    private void DisableExtension()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    internal void EnableExtension(Comp targetContent)
    {
        this.targetContent = targetContent;
        EnableExtension();
    }

    #region Invoked Functions via Buttons

    public void Clicked_DeleteBtn()
    {
        DisableExtension();
        targetContent?.Delete();
    }

    public void Clicked_DuplicateBtn()
    {
        DisableExtension();
        targetContent?.Duplicate();
    }

    public void OnEndEdit_InputField()
    {
        DisableExtension();
        targetContent?.Rename(inputField.text);
    }
    #endregion
}
