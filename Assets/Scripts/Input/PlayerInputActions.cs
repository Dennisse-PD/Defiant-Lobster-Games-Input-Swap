//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""aa9a4b1a-93c4-49b8-90b5-cd8d0a7e6246"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c83feabc-62f0-4a14-b1c0-2159179c38e8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact _PressKey"",
                    ""type"": ""Button"",
                    ""id"": ""5b44bfca-4939-4c89-86ac-429d67aa37d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact_HoldKey"",
                    ""type"": ""Button"",
                    ""id"": ""401d3482-a20d-409e-9f2a-de073ca7ba33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f69e4898-4d69-4f7e-8b8b-fb4351f94ab6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6b3960df-c72e-4cf4-a3e7-a5f96edbd636"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4eb65706-accf-460f-9b63-adb259f77e35"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75995eea-907c-4287-94f3-c93b49fa799a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a670de82-c8d8-4f53-a07c-a8d484f0df18"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""945db559-2ed6-4da1-9991-27851383c15e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact _PressKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67a9a521-a21e-4c28-bb71-76b5322f9a17"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact_HoldKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Drone"",
            ""id"": ""b62fd153-44ea-4f3f-a455-10871bdf8acd"",
            ""actions"": [
                {
                    ""name"": ""Tilt"",
                    ""type"": ""Value"",
                    ""id"": ""34246c3f-6d8b-4906-b294-22e61dccc2b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Button"",
                    ""id"": ""32977728-1c11-4306-a21e-4224584f66e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""9faca463-7f22-4eec-bfa8-17bab19c60c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""99907729-bd57-45ac-ad37-27c5c69620bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""99fc3d96-a763-4cb8-83e8-0d724512ff36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vector 2"",
                    ""id"": ""445567e6-6a92-40ba-9076-cb5b11c34cde"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3e0a8539-2093-4c24-87f0-6f11c7240577"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""99da1076-3378-4df7-9d16-c7e804123025"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f6af7c59-c3dc-47d4-bfff-f4a23f8fe230"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8c35c2e3-763c-441c-b08a-608c216d07ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""77aac004-89db-4105-a837-f23fd067b8c2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b2942c83-5ab5-41ec-af8c-976c6d878cc7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3024e36f-1be4-43e1-88a8-b08e66807a32"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ce71d980-9a3e-4176-9233-5a4f20fd5b37"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""id"": ""5f6c8c79-9893-4dd5-9f03-87f1c21c7031"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""989cae54-3528-4ae7-9aa3-a0b6b086e2da"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e82a70f5-2a45-4892-97ea-660d6a55b454"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bbf61e75-ee66-4fce-8279-692d1aa064fc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Interact_PressKey = m_Player.FindAction("Interact _PressKey", throwIfNotFound: true);
        m_Player_Interact_HoldKey = m_Player.FindAction("Interact_HoldKey", throwIfNotFound: true);
        // Drone
        m_Drone = asset.FindActionMap("Drone", throwIfNotFound: true);
        m_Drone_Tilt = m_Drone.FindAction("Tilt", throwIfNotFound: true);
        m_Drone_Thrust = m_Drone.FindAction("Thrust", throwIfNotFound: true);
        m_Drone_Vertical = m_Drone.FindAction("Vertical", throwIfNotFound: true);
        m_Drone_Rotate = m_Drone.FindAction("Rotate", throwIfNotFound: true);
        m_Drone_Exit = m_Drone.FindAction("Exit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Interact_PressKey;
    private readonly InputAction m_Player_Interact_HoldKey;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Interact_PressKey => m_Wrapper.m_Player_Interact_PressKey;
        public InputAction @Interact_HoldKey => m_Wrapper.m_Player_Interact_HoldKey;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact_PressKey.started += instance.OnInteract_PressKey;
            @Interact_PressKey.performed += instance.OnInteract_PressKey;
            @Interact_PressKey.canceled += instance.OnInteract_PressKey;
            @Interact_HoldKey.started += instance.OnInteract_HoldKey;
            @Interact_HoldKey.performed += instance.OnInteract_HoldKey;
            @Interact_HoldKey.canceled += instance.OnInteract_HoldKey;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact_PressKey.started -= instance.OnInteract_PressKey;
            @Interact_PressKey.performed -= instance.OnInteract_PressKey;
            @Interact_PressKey.canceled -= instance.OnInteract_PressKey;
            @Interact_HoldKey.started -= instance.OnInteract_HoldKey;
            @Interact_HoldKey.performed -= instance.OnInteract_HoldKey;
            @Interact_HoldKey.canceled -= instance.OnInteract_HoldKey;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Drone
    private readonly InputActionMap m_Drone;
    private List<IDroneActions> m_DroneActionsCallbackInterfaces = new List<IDroneActions>();
    private readonly InputAction m_Drone_Tilt;
    private readonly InputAction m_Drone_Thrust;
    private readonly InputAction m_Drone_Vertical;
    private readonly InputAction m_Drone_Rotate;
    private readonly InputAction m_Drone_Exit;
    public struct DroneActions
    {
        private @PlayerInputActions m_Wrapper;
        public DroneActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tilt => m_Wrapper.m_Drone_Tilt;
        public InputAction @Thrust => m_Wrapper.m_Drone_Thrust;
        public InputAction @Vertical => m_Wrapper.m_Drone_Vertical;
        public InputAction @Rotate => m_Wrapper.m_Drone_Rotate;
        public InputAction @Exit => m_Wrapper.m_Drone_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Drone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
        public void AddCallbacks(IDroneActions instance)
        {
            if (instance == null || m_Wrapper.m_DroneActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DroneActionsCallbackInterfaces.Add(instance);
            @Tilt.started += instance.OnTilt;
            @Tilt.performed += instance.OnTilt;
            @Tilt.canceled += instance.OnTilt;
            @Thrust.started += instance.OnThrust;
            @Thrust.performed += instance.OnThrust;
            @Thrust.canceled += instance.OnThrust;
            @Vertical.started += instance.OnVertical;
            @Vertical.performed += instance.OnVertical;
            @Vertical.canceled += instance.OnVertical;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @Exit.started += instance.OnExit;
            @Exit.performed += instance.OnExit;
            @Exit.canceled += instance.OnExit;
        }

        private void UnregisterCallbacks(IDroneActions instance)
        {
            @Tilt.started -= instance.OnTilt;
            @Tilt.performed -= instance.OnTilt;
            @Tilt.canceled -= instance.OnTilt;
            @Thrust.started -= instance.OnThrust;
            @Thrust.performed -= instance.OnThrust;
            @Thrust.canceled -= instance.OnThrust;
            @Vertical.started -= instance.OnVertical;
            @Vertical.performed -= instance.OnVertical;
            @Vertical.canceled -= instance.OnVertical;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @Exit.started -= instance.OnExit;
            @Exit.performed -= instance.OnExit;
            @Exit.canceled -= instance.OnExit;
        }

        public void RemoveCallbacks(IDroneActions instance)
        {
            if (m_Wrapper.m_DroneActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDroneActions instance)
        {
            foreach (var item in m_Wrapper.m_DroneActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DroneActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DroneActions @Drone => new DroneActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract_PressKey(InputAction.CallbackContext context);
        void OnInteract_HoldKey(InputAction.CallbackContext context);
    }
    public interface IDroneActions
    {
        void OnTilt(InputAction.CallbackContext context);
        void OnThrust(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
