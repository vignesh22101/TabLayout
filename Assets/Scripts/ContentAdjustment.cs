using UnityEngine;
using UnityEngine.UI;

public class ContentAdjustment : MonoBehaviour
{
    #region Variables
    [SerializeField] private Slider rowColumn_Slider, heightSlider, widthSlider;
    [SerializeField] private Button rowColumn_Button;

    private GridLayoutGroup active_GridLayout;
    private bool adjustColumn, adjustWidth;
    #endregion

    #region Invoked functions via Buttons
    public void Clicked_RowColumn_Btn()
    {
        adjustColumn = !adjustColumn;
        rowColumn_Button.GetComponentInChildren<Text>().text = adjustColumn ? "Column" : "Row";
    }

    public void OnValueChanged_RowColumn_Slider()
    {
        float sliderValue = rowColumn_Slider.value;
        UpdateGridLayoutGroup();

        if (adjustColumn)
        {
            active_GridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            active_GridLayout.constraintCount = (int)sliderValue;
        }
        else
        {
            active_GridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            active_GridLayout.constraintCount = (int)sliderValue;
        }
    }

    public void OnValueChanged_HeightSlider()
    {
        float sliderValue = heightSlider.value;
        UpdateGridLayoutGroup();

        Vector2 cellSize = active_GridLayout.cellSize;
        active_GridLayout.cellSize = new Vector2(cellSize.x, sliderValue);
    }

    public void OnValueChanged_WidthSlider()
    {
        float sliderValue = widthSlider.value;
        UpdateGridLayoutGroup();

        Vector2 cellSize = active_GridLayout.cellSize;
        active_GridLayout.cellSize = new Vector2(sliderValue, cellSize.y);
    }
    #endregion

    private void UpdateGridLayoutGroup()
    {
        active_GridLayout = CompsHandler.instance.activeTab.tabArea_GridLayout;
    }
}
