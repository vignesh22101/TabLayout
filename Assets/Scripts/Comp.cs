using UnityEngine;
using UnityEngine.UI;

enum ComponentType { Tab,Content}

public class Comp : MonoBehaviour
{
    #region Variables
    [SerializeField] internal ComponentType componentType;
    [SerializeField] private Text identifierTxt;
    #endregion

    internal virtual void Delete()
    {
        ResourcesHandler.instance.AddComponent(gameObject);
    }

    internal virtual void Rename(string targetName)
    {
        identifierTxt.text = targetName;
    }

    internal virtual void Duplicate()
    {
        Comp instantiatedComp = Instantiate(gameObject, gameObject.transform.parent).GetComponent<Comp>();
        instantiatedComp.Rename(identifierTxt.text + "(1)");
    }
}
