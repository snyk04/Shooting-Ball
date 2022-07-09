//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/Input/Controls.inputactions
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

namespace ShootingBall.Input
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""93c1e3de-bdb8-4b34-b55b-79adabb2317a"",
            ""actions"": [
                {
                    ""name"": ""StartAccumulating"",
                    ""type"": ""Button"",
                    ""id"": ""3d8fdf42-445c-4ac2-a0ea-680131f6f50f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcbad274-2222-436d-a938-7042d89a7cd6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""SlowTap(duration=0.01)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartAccumulating"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""085bf205-fc0e-4857-b9d0-be87858a0045"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""SlowTap(duration=0.01)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartAccumulating"",
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
            m_Player_StartAccumulating = m_Player.FindAction("StartAccumulating", throwIfNotFound: true);
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
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_StartAccumulating;
        public struct PlayerActions
        {
            private @Controls m_Wrapper;
            public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @StartAccumulating => m_Wrapper.m_Player_StartAccumulating;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @StartAccumulating.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartAccumulating;
                    @StartAccumulating.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartAccumulating;
                    @StartAccumulating.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStartAccumulating;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @StartAccumulating.started += instance.OnStartAccumulating;
                    @StartAccumulating.performed += instance.OnStartAccumulating;
                    @StartAccumulating.canceled += instance.OnStartAccumulating;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnStartAccumulating(InputAction.CallbackContext context);
        }
    }
}
