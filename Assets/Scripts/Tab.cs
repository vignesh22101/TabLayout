using UnityEngine;
using UnityEngine.UI;

public class Tab : Comp
{
    #region Variables
    [SerializeField] internal GameObject tabArea;
    [SerializeField] internal GridLayoutGroup tabArea_GridLayout;
    [SerializeField] Color enabledColor, disabledColor;

    private Image bgImg;
    #endregion

    //also invoked via buttons
    public void EnableTab()
    {
        Disable_ExistingTabs();

        CompsHandler.instance.activeTab = this;
        gameObject.SetActive(true);
        tabArea.SetActive(true);

        if (bgImg == null) Get_BGImg();
        bgImg.color = enabledColor;
    }

    private static void Disable_ExistingTabs()
    {
        Tab[] existingTabs = GameObject.FindObjectsOfType<Tab>();

        foreach (var existingTab in existingTabs)
        {
            existingTab.DisableTab();
        }
    }

    private void Get_BGImg()
    {
        bgImg = GetComponent<Image>();
    }

    internal void DisableTab()
    {
        tabArea.SetActive(false);

        if (bgImg == null) Get_BGImg();
        bgImg.color = disabledColor;
    }

    internal void Attach_TabArea(GameObject tabArea)
    {
        this.tabArea = tabArea;
        tabArea_GridLayout = tabArea.GetComponent<GridLayoutGroup>();
    }

    #region Overrides
    internal override void Delete()
    {
        Rename(componentType.ToString());
        ResourcesHandler.instance.AddComponent(gameObject);
        tabArea_GridLayout.cellSize = new Vector2(100,100);
        DisableTab();

        print($"Tab delete, childCount:{tabArea.transform.childCount}");
        for (int i = 0; i < tabArea.transform.childCount; i++)
        {
            //Disabling the contents
            ResourcesHandler.instance.AddComponent(tabArea.transform.GetChild(i).gameObject);
        }

        Transform tabsParent = transform.parent;
        //Enabling one of the tabs available
        for (int i = 0; i < tabsParent.childCount; i++)
        {
            GameObject tab = tabsParent.GetChild(i).gameObject;

            if (tab.activeInHierarchy)
            {
                tab.GetComponent<Tab>().EnableTab();
                break;
            }
        }
    }
    #endregion
}
