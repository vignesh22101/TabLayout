using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is based on the object pooling pattern
/// </summary>
public class ResourcesHandler : MonoBehaviour
{
    #region Variables
    internal static ResourcesHandler instance;

    [SerializeField] private GameObject tab, content,tabArea;
    [SerializeField] private Transform tabParent, contentParent,tabAreaParent;
    [SerializeField] int noOfTabs, noOfContents;

    private Queue<GameObject> tabsQueue=new Queue<GameObject>(), contentsQueue=new Queue<GameObject>();
    #endregion

    private void Awake()
    {
        instance = this;
        InitializeResources();
    }

    private void InitializeResources()
    {
        ExtendTabs();
        ExtendContents();
    }

    private void ExtendContents()
    {
        for (int i = 0; i < noOfContents; i++)
            AddContent();
    }

    private void ExtendTabs()
    {
        for (int i = 0; i < noOfTabs; i++)
            AddTab();
    }

    internal GameObject GetTab()
    {
        if (tabsQueue.Count > 0)
            return tabsQueue.Dequeue();

        ExtendTabs();
        return tabsQueue.Dequeue();
    }

    internal GameObject GetContent()
    {
        if (contentsQueue.Count > 0)
            return contentsQueue.Dequeue();

        ExtendContents();
        return contentsQueue.Dequeue();
    }

    internal void AddTab(GameObject tab=null)
    {
        if (tab == null)
        {
            tab = Instantiate(this.tab, tabParent);
            GameObject tabArea = Instantiate(this.tabArea,tabAreaParent);
            tab.GetComponent<Tab>().Attach_TabArea(tabArea);
        }

        tabsQueue.Enqueue(tab);
        tab.SetActive(false);
    }

    internal void AddContent(GameObject content=null)
    {
        if (content == null)
            content = Instantiate(this.content, contentParent);

        contentsQueue.Enqueue(content);
        content.SetActive(false);
    }

    internal void AddComponent(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Comp>(out Comp comp))
        {
            if (comp.componentType == ComponentType.Tab)
                AddTab(gameObject);
            else
                AddContent(gameObject);
        }
    }
}
