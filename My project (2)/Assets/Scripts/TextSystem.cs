using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.ScoreChanged += UpdatePointsText;
    }

    private void UpdatePointsText(int score)
    {
        pointsText.text = "Points: " + score;
    }
}
