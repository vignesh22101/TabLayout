using UnityEngine;
using UnityEngine.UI;

public class Content : Comp
{
    [SerializeField] private Color[] colors;
    
    private Image contentImg;
    private int colorIndex;

    private void OnEnable()
    {
        colorIndex = -1;
        ChangeColor();
    }

    //Invoked via button
    public void ChangeColor()
    {
        if (contentImg == null)
            contentImg = GetComponent<Image>();

        if (++colorIndex > colors.Length - 1)
            colorIndex = 0;

        contentImg.color = colors[colorIndex];
    }
}
