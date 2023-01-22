//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/PlayerActions.inputactions
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

namespace Input
{
    public partial class @PlayerActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Ground"",
            ""id"": ""56f99f8a-6bd8-4532-96fe-52199898fc6b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""914843fc-04c5-4077-ba95-a45f9b5af952"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4c918ec1-ce96-4cf3-87af-6403a1e01ffa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b4afac3a-f375-4fe6-aeed-21a5bc06e327"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2668eafa-de40-4ae4-866d-9ffb7cfb7bbd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""49bc96e5-3c79-40a7-9f21-ee2fb3681c6b"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a73cbdbb-e0bc-4fe9-9e35-c66c6c00a717"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""44585c67-1fd0-43f1-aac1-64f68ede034b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e5bf54f0-d522-42f8-b3b4-0c657ca9ab5d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""54585a7b-6d83-458f-aaec-681bfe84d94b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8265e0bb-6802-42a8-a3d8-ec22212fc56d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""53295e52-5c7a-4f21-a670-f681674447f2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""56bab04a-1faf-4e33-a481-75605658af1d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cddf3ed-80db-47d8-aa7d-b3bbb20a5d27"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee9a8cea-dcfa-4255-a30a-895a19784cd1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f458abd3-637c-4098-9c89-c9ab10de9eb3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c82d03b-2c10-453d-ac30-99ea29025644"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""240ef47f-f87b-4e7c-9620-b898e772cda2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Default"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Genesis"",
            ""bindingGroup"": ""Genesis"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Default"",
            ""bindingGroup"": ""Default"",
            ""devices"": []
        }
    ]
}");
            // Ground
            m_Ground = asset.FindActionMap("Ground", throwIfNotFound: true);
            m_Ground_Move = m_Ground.FindAction("Move", throwIfNotFound: true);
            m_Ground_Jump = m_Ground.FindAction("Jump", throwIfNotFound: true);
            m_Ground_Shoot = m_Ground.FindAction("Shoot", throwIfNotFound: true);
            m_Ground_Attack = m_Ground.FindAction("Attack", throwIfNotFound: true);
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

        // Ground
        private readonly InputActionMap m_Ground;
        private IGroundActions m_GroundActionsCallbackInterface;
        private readonly InputAction m_Ground_Move;
        private readonly InputAction m_Ground_Jump;
        private readonly InputAction m_Ground_Shoot;
        private readonly InputAction m_Ground_Attack;
        public struct GroundActions
        {
            private @PlayerActions m_Wrapper;
            public GroundActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Ground_Move;
            public InputAction @Jump => m_Wrapper.m_Ground_Jump;
            public InputAction @Shoot => m_Wrapper.m_Ground_Shoot;
            public InputAction @Attack => m_Wrapper.m_Ground_Attack;
            public InputActionMap Get() { return m_Wrapper.m_Ground; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GroundActions set) { return set.Get(); }
            public void SetCallbacks(IGroundActions instance)
            {
                if (m_Wrapper.m_GroundActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnJump;
                    @Shoot.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnShoot;
                    @Attack.started -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_GroundActionsCallbackInterface.OnAttack;
                }
                m_Wrapper.m_GroundActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                }
            }
        }
        public GroundActions @Ground => new GroundActions(this);
        private int m_GenesisSchemeIndex = -1;
        public InputControlScheme GenesisScheme
        {
            get
            {
                if (m_GenesisSchemeIndex == -1) m_GenesisSchemeIndex = asset.FindControlSchemeIndex("Genesis");
                return asset.controlSchemes[m_GenesisSchemeIndex];
            }
        }
        private int m_DefaultSchemeIndex = -1;
        public InputControlScheme DefaultScheme
        {
            get
            {
                if (m_DefaultSchemeIndex == -1) m_DefaultSchemeIndex = asset.FindControlSchemeIndex("Default");
                return asset.controlSchemes[m_DefaultSchemeIndex];
            }
        }
        public interface IGroundActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
        }
    }
}
