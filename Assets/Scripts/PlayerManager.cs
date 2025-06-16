using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player _player; //Reference to the player object
    private PlayerInputActions _input; //Reference to input actions generated class

    //This script handles the input. i.e Performed actions and such.
    // Start is called before the first frame update
    void Start()
    {
        InitializeInput();
    }

    // Update is called once per frame
    void Update()
    {
        //Using the context value from our vector2 input, we can register direction
        var move = _input.Player.Move.ReadValue<Vector2>();
        _player.CalcutateMovement(move); //uses the parameter variable which is of type vector 2
    }
    private void InitializeInput()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        //generate peform callback here
        
    }

   
}
