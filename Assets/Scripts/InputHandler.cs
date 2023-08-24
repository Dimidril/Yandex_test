using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !Game.Instance.isStarted)
            Game.Instance.StartGame();
    }

    private void FixedUpdate()
    {
        if(!Game.Instance.isStarted) return;
        player.Fly(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space));
    }
}