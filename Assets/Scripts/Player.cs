﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Scripts.LiveObjects;
using Cinemachine;
using System.Runtime.InteropServices;

namespace Game.Scripts.Player
{
    //This script will hold the movement logic that will be executed in our Player Manager as the input registers
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        private CharacterController _controller;
        private Animator _anim;
        [SerializeField]
        private float _speed = 5.0f;
        private bool _playerGrounded;
        [SerializeField]
        private Detonator _detonator;
        private bool _canMove = true; //MOVEMENT
        [SerializeField]
        private CinemachineVirtualCamera _followCam;
        [SerializeField]
        private GameObject _model;


        private void OnEnable()
        {
            InteractableZone.onZoneInteractionComplete += InteractableZone_onZoneInteractionComplete;
            Laptop.onHackComplete += ReleasePlayerControl;
            Laptop.onHackEnded += ReturnPlayerControl;
            Forklift.onDriveModeEntered += ReleasePlayerControl;
            Forklift.onDriveModeExited += ReturnPlayerControl;
            Forklift.onDriveModeEntered += HidePlayer;
            Drone.OnEnterFlightMode += ReleasePlayerControl;
            Drone.onExitFlightmode += ReturnPlayerControl;
            Drone.OnEnterFlightMode += HidePlayer;//This was missing for the flight so the character was not hiding, might remove
            Drone.onExitFlightmode -= HidePlayer ;
        } 

        private void Start()
        {
            _controller = GetComponent<CharacterController>();

            if (_controller == null)
                Debug.LogError("No Character Controller Present");

            _anim = GetComponentInChildren<Animator>();

            if (_anim == null)
                Debug.Log("Failed to connect the Animator");
        }

        private void Update() //MOVEMENT
        {
           // if (_canMove == true) --> This is moved to the CalculateMovement Method
              //  CalcutateMovement();

        }

      //  private void CalcutateMovement() --> This should be made public so we can access it in the PlayerManager
         public void CalcutateMovement(Vector2 move) //Pareamter added so we can manipulate the move variable in the PlayerIinput
        {
            if (_canMove == true) //Moved here so we can still validate movement without having to overhaul unnecessarily  
            {
                _playerGrounded = _controller.isGrounded;
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");

                transform.Rotate(transform.up, h * 3f);//If you want the character to rotate faster, you can add a multiplier

                var direction = transform.forward * v;
                var velocity = direction * _speed;


                _anim.SetFloat("Speed", Mathf.Abs(velocity.magnitude));


                if (_playerGrounded)
                    velocity.y = 0f;
                if (!_playerGrounded)
                {
                    velocity.y += -20f * Time.deltaTime;
                }

                _controller.Move(velocity * Time.deltaTime);
            }
                                   
        }

        private void InteractableZone_onZoneInteractionComplete(InteractableZone zone)
        {
            switch(zone.GetZoneID())
            {
                case 1: //place c4
                    _detonator.Show();
                    break;
                case 2: //Trigger Explosion
                    TriggerExplosive();
                    break;
             //is there not drone zone case? Could this be the issue??
                    
            }
        }

        private void ReleasePlayerControl()// MOVEMENT
        {
            _canMove = false;
            _followCam.Priority = 9;
        }

        private void ReturnPlayerControl() //MOVEMENT
        {
            _model.SetActive(true);
            _canMove = true;
            _followCam.Priority = 10;
        }

        private void HidePlayer()
        {
            _model.SetActive(false); // hides the player when they enter the drone zone to switch controls
        }
               
        private void TriggerExplosive()
        {
            _detonator.TriggerExplosion();
        }

        private void OnDisable()
        {
            InteractableZone.onZoneInteractionComplete -= InteractableZone_onZoneInteractionComplete;
            Laptop.onHackComplete -= ReleasePlayerControl;
            Laptop.onHackEnded -= ReturnPlayerControl;
            Forklift.onDriveModeEntered -= ReleasePlayerControl;
            Forklift.onDriveModeExited -= ReturnPlayerControl;
            Forklift.onDriveModeEntered -= HidePlayer;
            Drone.OnEnterFlightMode -= ReleasePlayerControl;
            Drone.onExitFlightmode -= ReturnPlayerControl;
        }

    }
}

