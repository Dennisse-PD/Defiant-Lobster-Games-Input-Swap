using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script can alternatively be an Input Manager rather than the Player manager but will keep things as they are for now
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player _player; //Reference to the player object
    private PlayerInputActions _input; //Reference to input actions generated class

    //This script handles the input. i.e Performed actions and such.
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        //Using the context value from our vector2 input, we can register direction
        var move = _input.Player.Move.ReadValue<Vector2>();
        _player.CalcutateMovement(move); //uses the parameter variable which is of type vector 2
    }
    private void InitializePlayerInput()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        //generate peform callback here
        
    }
    //create method to initialize drone input
    private void InitializeDroneInput()
    {
        //this method will be called when the ENTER DRONE key is pressed withint he interactable zone
        _input.Player.Disable(); //This will be re-enabled when the key to exit the drone is pressed 
        _input.Drone.Enable();
    }

   
}
