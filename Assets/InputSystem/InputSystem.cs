//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/InputSystem/InputSystem.inputactions
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

public partial class @InputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""MainInput"",
            ""id"": ""6873e778-8563-4084-8e0c-cb650aafe38e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d4d30fd6-1dca-448a-bc2f-4fd1f7fc87df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cbd7c8b6-5a58-4e4c-b529-2683251f23fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NumberKeys"",
                    ""type"": ""Button"",
                    ""id"": ""fba4ebd8-e0ae-4c12-9fa5-76fa0338b534"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ScrollUp"",
                    ""type"": ""Value"",
                    ""id"": ""5ef9c626-41fe-4f37-9045-01edc92e6974"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ScrollDown"",
                    ""type"": ""Value"",
                    ""id"": ""f5a90a75-aef2-4539-ba3d-4df0d9153edf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""536e03bd-4ad5-4205-8b34-3ced545d8513"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6f321534-411e-4b59-b14e-b8385ef67356"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e9b03d0c-80a3-4b0f-863a-2295aeafe221"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c3c26c0-ff12-4c19-9cd9-ca8691faf833"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5847924f-c593-43dd-9f8f-24c7f243827f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""50a5d23e-104f-4e8b-b475-379234992f30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cb08efe5-fb7d-495d-868e-9fd665f10832"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad482cb2-65b8-4c0b-9bfe-5117e5fc05ee"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c34b0d4-0e9f-4aa3-adf2-039f6d9c0676"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b964ed79-83ae-49e8-b3b9-69ce518658c2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9c0117a-3904-4b6c-b4e3-98087c6d03b7"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34ce466d-3d5c-4265-8885-7c150b8abae9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb8a5b81-4d2b-4240-b344-0bfa9ee973a9"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""734c742a-5391-42f0-9da5-3659c8e5a811"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24608357-eeb1-42c4-8c0b-e1b2c988c092"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12fe3cce-fe79-4fc8-88e5-141c84abd8d7"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=6)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f545cdfb-cf50-4ffe-a1fa-3c46cb6e99b3"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=7)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c696092-ab3a-45b5-ae96-e6414301ae84"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=8)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16956c35-fefe-4aab-aa04-98523fb75190"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=9)"",
                    ""groups"": """",
                    ""action"": ""NumberKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bde66a9-e8cf-4b6b-9b8a-38890efd39c9"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a3f523a-cd3c-4f17-a97a-188b12540cdb"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScrollDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c151275f-9441-490b-92a8-34bd17ff051c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainInput
        m_MainInput = asset.FindActionMap("MainInput", throwIfNotFound: true);
        m_MainInput_Movement = m_MainInput.FindAction("Movement", throwIfNotFound: true);
        m_MainInput_Interact = m_MainInput.FindAction("Interact", throwIfNotFound: true);
        m_MainInput_NumberKeys = m_MainInput.FindAction("NumberKeys", throwIfNotFound: true);
        m_MainInput_ScrollUp = m_MainInput.FindAction("ScrollUp", throwIfNotFound: true);
        m_MainInput_ScrollDown = m_MainInput.FindAction("ScrollDown", throwIfNotFound: true);
        m_MainInput_MousePosition = m_MainInput.FindAction("MousePosition", throwIfNotFound: true);
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

    // MainInput
    private readonly InputActionMap m_MainInput;
    private IMainInputActions m_MainInputActionsCallbackInterface;
    private readonly InputAction m_MainInput_Movement;
    private readonly InputAction m_MainInput_Interact;
    private readonly InputAction m_MainInput_NumberKeys;
    private readonly InputAction m_MainInput_ScrollUp;
    private readonly InputAction m_MainInput_ScrollDown;
    private readonly InputAction m_MainInput_MousePosition;
    public struct MainInputActions
    {
        private @InputSystem m_Wrapper;
        public MainInputActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MainInput_Movement;
        public InputAction @Interact => m_Wrapper.m_MainInput_Interact;
        public InputAction @NumberKeys => m_Wrapper.m_MainInput_NumberKeys;
        public InputAction @ScrollUp => m_Wrapper.m_MainInput_ScrollUp;
        public InputAction @ScrollDown => m_Wrapper.m_MainInput_ScrollDown;
        public InputAction @MousePosition => m_Wrapper.m_MainInput_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_MainInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainInputActions set) { return set.Get(); }
        public void SetCallbacks(IMainInputActions instance)
        {
            if (m_Wrapper.m_MainInputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnInteract;
                @NumberKeys.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnNumberKeys;
                @NumberKeys.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnNumberKeys;
                @NumberKeys.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnNumberKeys;
                @ScrollUp.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollUp;
                @ScrollUp.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollUp;
                @ScrollUp.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollUp;
                @ScrollDown.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollDown;
                @ScrollDown.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollDown;
                @ScrollDown.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnScrollDown;
                @MousePosition.started -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MainInputActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_MainInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @NumberKeys.started += instance.OnNumberKeys;
                @NumberKeys.performed += instance.OnNumberKeys;
                @NumberKeys.canceled += instance.OnNumberKeys;
                @ScrollUp.started += instance.OnScrollUp;
                @ScrollUp.performed += instance.OnScrollUp;
                @ScrollUp.canceled += instance.OnScrollUp;
                @ScrollDown.started += instance.OnScrollDown;
                @ScrollDown.performed += instance.OnScrollDown;
                @ScrollDown.canceled += instance.OnScrollDown;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public MainInputActions @MainInput => new MainInputActions(this);
    public interface IMainInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnNumberKeys(InputAction.CallbackContext context);
        void OnScrollUp(InputAction.CallbackContext context);
        void OnScrollDown(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
