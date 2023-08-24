using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        Game.Instance.onCoin.AddListener(score => scoreText.text = score.ToString());
    }
}