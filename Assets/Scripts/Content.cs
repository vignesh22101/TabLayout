using UnityEngine;
using UnityEngine.UI;

public class Content : Comp
{
    [SerializeField] private Color[] colors;
    
    private Image contentImg;

    //Invoked via button
    public void ChangeColor()
    {
        if (contentImg == null) contentImg = GetComponent<Image>();
        contentImg.color = colors[Random.Range(0, colors.Length)];
    }
}
