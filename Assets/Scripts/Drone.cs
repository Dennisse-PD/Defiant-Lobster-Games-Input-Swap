using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Game.Scripts.UI;
using UnityEditor.Experimental.GraphView;

namespace Game.Scripts.LiveObjects
{
    public class Drone : MonoBehaviour
    {
        private enum Tilt
        {
            NoTilt, Forward, Back, Left, Right
        }

        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float _speed = 5f;
        private bool _inFlightMode = false;
        [SerializeField]
        private Animator _propAnim;
        [SerializeField]
        private CinemachineVirtualCamera _droneCam;
        [SerializeField]
        private InteractableZone _interactableZone;

        //Input Manager 
        [SerializeField]
        private InputManager _inputManager;

        //Drone Starting Position
        Vector3 startPos;


        public static event Action OnEnterFlightMode;
        public static event Action onExitFlightmode;

        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += EnterFlightMode;
        }

        private void EnterFlightMode(InteractableZone zone)//WILL NEED THIS TO SWAP ACTION WITHIN INTERACTABLE ZONE
        {
            if (_inFlightMode != true && zone.GetZoneID() == 4) // drone Scene
            {
                _propAnim.SetTrigger("StartProps");
                _droneCam.Priority = 11;
                _inFlightMode = true;
                OnEnterFlightMode?.Invoke();
                UIManager.Instance.DroneView(true);
                _interactableZone.CompleteTask(4);
                //enable drone controls
                _inputManager.InitializeDroneInput();
                
               
            }
        }

        private void ExitFlightMode()//NEED TO USE THIS FOR THE EXIT INPUT SWAP(should be a public method)
        {            
            _droneCam.Priority = 9;
            _inFlightMode = false;
            UIManager.Instance.DroneView(false);
            _inputManager.DisableDroneControls();   //disable drone controls
            this.transform.position = startPos; //Return drone to start position
        }

        private void Update()//MOVEMENT
        {
            if (_inFlightMode)//NEED to figure out where to place this validation
            {
                //I can call these two methods from the Player Manager 
               // CalculateTilt(); --> No longer needed here
                CalculateMovementUpdate();

                if (Input.GetKeyDown(KeyCode.Escape))//EXIT KEY. MUST SWAP
                {
                    _inFlightMode = false;
                    onExitFlightmode?.Invoke();
                    ExitFlightMode();
                }
            }
        }

        private void Start()
        {
            startPos = this.transform.position;
        }
        private void FixedUpdate() ////FIXED UPDATE METHOD
        {
            //rigidbody --> moved to calculate method
           _rigidbody.AddForce(transform.up * (9.81f), ForceMode.Acceleration); //Seems to be adding gravity 9.81 as an upward force to keep airborne(?)
         //   if (_inFlightMode)
                //CalculateMovementFixedUpdate(di);
        }

        private void CalculateMovementUpdate() //MOVEMENT METHOD (LEFT AND RIGHT) ARROW KEYS(Should be public)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var tempRot = transform.localRotation.eulerAngles;
                tempRot.y -= _speed / 3;
                transform.localRotation = Quaternion.Euler(tempRot);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                var tempRot = transform.localRotation.eulerAngles;
                tempRot.y += _speed / 3;
                transform.localRotation = Quaternion.Euler(tempRot);
            }
        }

        public void CalculateMovementFixedUpdate(float direction) //FIXED MOVEMENT METHOD (physics/UP AND DOWN)  SPACE AND V(Should be public)
        {
            _rigidbody.AddForce(transform.up * direction * _speed, ForceMode.Acceleration);
            /*    if (Input.GetKey(KeyCode.Space))
            {
           _rigidbody.AddForce(transform.up * direction * _speed, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.V))
            {
            //    _rigidbody.AddForce(-transform.up * direction * _speed, ForceMode.Acceleration);
           */
        }
        public void CalculateTilt(Vector2 tilt) 
        //this method has been reworked in a way that only the movement logic is implement without having to rely on legacy input
            
        {
            float xRotation = 0;
            float zRotation = 0;

            if (tilt.x < 0) // A
                zRotation = 30;
            else if (tilt.x > 0) // D
                zRotation = -30;

            if (tilt.y > 0) // W
                xRotation = 30;
            else if (tilt.y < 0) // S
                xRotation = -30;

            transform.rotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y, zRotation);
        }

        //private void CalculateTilt() //THIS METHOD HAS BEEN REWORKED ^
       
        // {

        /* if (Input.GetKey(KeyCode.A)) //we can use the value in the PlayerManager to handle this
             transform.rotation = Quaternion.Euler(00,transform.localRotation.eulerAngles.y, 30);
           else if (Input.GetKey(KeyCode.D))
             transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, -30);
          else if (Input.GetKey(KeyCode.W))
             transform.rotation = Quaternion.Euler(30, transform.localRotation.eulerAngles.y, 0);
          else if (Input.GetKey(KeyCode.S))
             transform.rotation = Quaternion.Euler(-30, transform.localRotation.eulerAngles.y, 0);
          else 
             transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0);
        */
        // }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= EnterFlightMode;
        }
    }
}
