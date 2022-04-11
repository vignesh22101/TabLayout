using UnityEngine;

public class CompsHandler : MonoBehaviour
{
    #region Variables
    internal static CompsHandler instance;
    internal Tab activeTab;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Clicked_AddTabBtn();
    }

    #region Invoked functions
    public void Clicked_AddTabBtn()
    {
        ResourcesHandler.instance.GetTab().TryGetComponent<Tab>(out Tab tab);

        if (tab!=null)
        {
            tab.EnableTab();
            activeTab = tab;
            tab.transform.SetAsLastSibling();
        }
    }

    public void Clicked_AddContentBtn()
    {
        GameObject content = ResourcesHandler.instance.GetContent();
        content.transform.SetParent(activeTab.tabArea.transform);
        content.SetActive(true);
        content.transform.SetAsLastSibling();
        content.GetComponent<Content>().ResetColor();
    }
    #endregion
}
