using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ContentExtension : MonoBehaviour
{
    #region Variables
    internal static ContentExtension instance;

    private Content targetContent;
    private Camera mainCamera;
    private InputField inputField;
    private CanvasGroup canvasGroup;
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

    internal void EnableExtension(Content targetContent,Vector2 screenPos)
    {
        this.targetContent = targetContent;
        Vector3 modifiedScreenPos = new Vector3(screenPos.x,screenPos.y,0);
        transform.localPosition = mainCamera.ScreenToWorldPoint(modifiedScreenPos);
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
