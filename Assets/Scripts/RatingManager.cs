using UnityEngine;
using UnityEngine.SceneManagement;

public class RatingManager : MonoBehaviour
{

    public Cell[] cells;

    private int userRating;

    public int _userRating => userRating;
    
    public void setRatingVisual(Cell cell)
    {
        userRating = cell.rateValue;
        var rateValue = userRating;
        resetButtons();
        cells[rateValue-1].ButtonAddedToRate();
    }

    public void resetButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            cells[i].ButtonClear();
        }
    }

    public void ReadAgain()
    {
        SceneManager.LoadScene(0);
    }
}
