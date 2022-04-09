using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject component;
    [SerializeField] private Text identifierTxt;
    #endregion

    internal virtual void Delete()
    {
        Destroy(gameObject);
    }

    internal virtual void Rename(string targetName)
    {
        identifierTxt.text = targetName;
    }

    internal virtual void Duplicate()
    {
        Content instantiatedComp = Instantiate(gameObject, parent).GetComponent<Content>();
        instantiatedComp.Rename(identifierTxt.text + "(1)");
    }
}
