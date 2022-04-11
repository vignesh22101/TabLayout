using UnityEngine;
using UnityEngine.UI;

public class Content : Comp
{

    [SerializeField] private Color[] colors;
    
    private int colorIndex;
    private Image contentImg;

    //Invoked via button
    public void ChangeColor()
    {
        if (contentImg == null)
            contentImg = GetComponent<Image>();

        colorIndex=GetColorIndex();

        if (++colorIndex > colors.Length - 1)
            colorIndex = 0;

        contentImg.color = colors[colorIndex];
    }

    private int GetColorIndex()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            if (contentImg.color.Equals(colors[i]))
                return i;
        }

        return 0;
    }

    internal void ResetColor()
    {
        if (contentImg == null)
            contentImg = GetComponent<Image>();

        contentImg.color = colors[0];
    }
}
