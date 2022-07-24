//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Main/Input System/InputControl.inputactions
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

public partial class @InputControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControl"",
    ""maps"": [
        {
            ""name"": ""Dice"",
            ""id"": ""3ff93b23-4b87-4809-87b4-4224b542ecf7"",
            ""actions"": [
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""445159a1-9d01-4793-b53b-81f0999c0152"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""4fb91722-345a-4727-9781-3c4bd2df930a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""bbd75d7e-e152-444b-b99f-12d138febba5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""b39ea07a-7f45-4fe5-bb63-0fde767a4421"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1c0b7f8-4364-4fcc-a67f-64d57d1da05b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fcec0c6-b6bc-408b-a591-4a91351fa30d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97910000-5feb-4dfe-bebb-1d7fa1b35382"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""084a6da3-36f8-4e79-ad3c-508dcab178ca"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bb021bb-435d-4b32-8ec3-0f27cc64f375"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bb772cd-6414-4012-a672-a4a549b9cb1c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d6b7d9d-78f7-4696-a86b-f385d89a0cbd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b71016f7-35f1-453b-b291-265e88a6653e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GemeControl"",
            ""id"": ""3fc60547-e9af-463a-aca4-8ff83bb1212f"",
            ""actions"": [
                {
                    ""name"": ""NextLevel"",
                    ""type"": ""Button"",
                    ""id"": ""95fe8a2d-1fd1-4fea-9cb5-189022476bb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PreviousLevel"",
                    ""type"": ""Button"",
                    ""id"": ""0e79eaca-e49e-4929-abb4-48f6ef3416a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""885f8cf8-55ee-495b-9baf-965d6d636e86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f96855be-25c8-406c-a2d3-73ead376c083"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89eb17b5-d618-449b-bb5a-351e0282dce1"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0080fac-e36a-40c2-9518-dd6914c43e36"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81bdef3f-c6e2-4821-955f-7c8252306703"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Dice
        m_Dice = asset.FindActionMap("Dice", throwIfNotFound: true);
        m_Dice_Right = m_Dice.FindAction("Right", throwIfNotFound: true);
        m_Dice_Left = m_Dice.FindAction("Left", throwIfNotFound: true);
        m_Dice_Forward = m_Dice.FindAction("Forward", throwIfNotFound: true);
        m_Dice_Backward = m_Dice.FindAction("Backward", throwIfNotFound: true);
        // GemeControl
        m_GemeControl = asset.FindActionMap("GemeControl", throwIfNotFound: true);
        m_GemeControl_NextLevel = m_GemeControl.FindAction("NextLevel", throwIfNotFound: true);
        m_GemeControl_PreviousLevel = m_GemeControl.FindAction("PreviousLevel", throwIfNotFound: true);
        m_GemeControl_Restart = m_GemeControl.FindAction("Restart", throwIfNotFound: true);
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

    // Dice
    private readonly InputActionMap m_Dice;
    private IDiceActions m_DiceActionsCallbackInterface;
    private readonly InputAction m_Dice_Right;
    private readonly InputAction m_Dice_Left;
    private readonly InputAction m_Dice_Forward;
    private readonly InputAction m_Dice_Backward;
    public struct DiceActions
    {
        private @InputControl m_Wrapper;
        public DiceActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right => m_Wrapper.m_Dice_Right;
        public InputAction @Left => m_Wrapper.m_Dice_Left;
        public InputAction @Forward => m_Wrapper.m_Dice_Forward;
        public InputAction @Backward => m_Wrapper.m_Dice_Backward;
        public InputActionMap Get() { return m_Wrapper.m_Dice; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DiceActions set) { return set.Get(); }
        public void SetCallbacks(IDiceActions instance)
        {
            if (m_Wrapper.m_DiceActionsCallbackInterface != null)
            {
                @Right.started -= m_Wrapper.m_DiceActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_DiceActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_DiceActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_DiceActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_DiceActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_DiceActionsCallbackInterface.OnLeft;
                @Forward.started -= m_Wrapper.m_DiceActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_DiceActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_DiceActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_DiceActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_DiceActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_DiceActionsCallbackInterface.OnBackward;
            }
            m_Wrapper.m_DiceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
            }
        }
    }
    public DiceActions @Dice => new DiceActions(this);

    // GemeControl
    private readonly InputActionMap m_GemeControl;
    private IGemeControlActions m_GemeControlActionsCallbackInterface;
    private readonly InputAction m_GemeControl_NextLevel;
    private readonly InputAction m_GemeControl_PreviousLevel;
    private readonly InputAction m_GemeControl_Restart;
    public struct GemeControlActions
    {
        private @InputControl m_Wrapper;
        public GemeControlActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextLevel => m_Wrapper.m_GemeControl_NextLevel;
        public InputAction @PreviousLevel => m_Wrapper.m_GemeControl_PreviousLevel;
        public InputAction @Restart => m_Wrapper.m_GemeControl_Restart;
        public InputActionMap Get() { return m_Wrapper.m_GemeControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GemeControlActions set) { return set.Get(); }
        public void SetCallbacks(IGemeControlActions instance)
        {
            if (m_Wrapper.m_GemeControlActionsCallbackInterface != null)
            {
                @NextLevel.started -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnNextLevel;
                @NextLevel.performed -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnNextLevel;
                @NextLevel.canceled -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnNextLevel;
                @PreviousLevel.started -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnPreviousLevel;
                @PreviousLevel.performed -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnPreviousLevel;
                @PreviousLevel.canceled -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnPreviousLevel;
                @Restart.started -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GemeControlActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_GemeControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextLevel.started += instance.OnNextLevel;
                @NextLevel.performed += instance.OnNextLevel;
                @NextLevel.canceled += instance.OnNextLevel;
                @PreviousLevel.started += instance.OnPreviousLevel;
                @PreviousLevel.performed += instance.OnPreviousLevel;
                @PreviousLevel.canceled += instance.OnPreviousLevel;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public GemeControlActions @GemeControl => new GemeControlActions(this);
    public interface IDiceActions
    {
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
    }
    public interface IGemeControlActions
    {
        void OnNextLevel(InputAction.CallbackContext context);
        void OnPreviousLevel(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
