// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/m_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @M_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @M_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""m_Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b20c7fe0-2d63-4093-bff2-c6bd14be3e14"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4df7ae41-c01a-4b78-a043-9356a30481e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c4ae10f9-c990-4564-95ca-ecbfd961e5e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ad4d0254-852a-4217-b362-fe2caf47b880"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Defend"",
                    ""type"": ""Button"",
                    ""id"": ""0026b7e6-3d5b-4043-a3f2-ffbdb07e621d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IntoDoor"",
                    ""type"": ""Button"",
                    ""id"": ""34715ae8-481d-444f-aaa0-d5cae1b4cdef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemOne"",
                    ""type"": ""Button"",
                    ""id"": ""b3b1cc22-29d7-44a8-b42f-58b77b141270"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemTwo"",
                    ""type"": ""Button"",
                    ""id"": ""b06efda3-65b8-438a-8fe0-73487e70d867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemThree"",
                    ""type"": ""Button"",
                    ""id"": ""38e09b1d-05d0-4ed9-ae2e-31ca0895a2dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemFour"",
                    ""type"": ""Button"",
                    ""id"": ""9ea5600a-9073-4906-870d-7c43fbd382d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ItemFive"",
                    ""type"": ""Button"",
                    ""id"": ""06ef9f39-5c50-4f65-9280-f0584939fe65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GetItem"",
                    ""type"": ""Button"",
                    ""id"": ""9ad52125-ad9c-4a90-9924-3f75a2970ca0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""cf740c6d-ec08-4516-903b-e6da57834822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9bcd6f4f-5400-46db-baea-22e74a6fd324"",
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
                    ""id"": ""a7ce89eb-953f-4773-80f1-41f16c07aed1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5ba3cac-fb21-4da3-9107-e0df2b1ecaa4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c48e3f05-60e9-4580-81d7-9ff10f43f178"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0f80d028-2f6d-4e7b-afaa-2c4da1234e9b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5b366a1b-9043-44e4-a5de-9d2af64eb6cb"",
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
                    ""id"": ""32e160ad-c94b-464f-b990-50f68c15a417"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e50d232f-577b-4f10-bf91-4414fb39d470"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""530766df-bfd6-4f2b-9c30-21c140f1cd68"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7a11750d-eb49-47be-a4f4-820997daff8e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bda3b617-52fc-489c-b3ca-2b27fe2eefa8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5dfcd5a-7018-412a-afb2-833fe7b5f7d9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4366509-4041-4328-93db-ee1c0c7a7dae"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0540aad0-539d-4704-ba3e-4fbb619a96ed"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""679cd220-31fd-4b29-b5c0-8aec3c340839"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b766f26-eebb-4ab2-96a0-ab5034303b43"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Defend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5618bcc-4d61-4c91-9673-7ac25bdf3dbf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""IntoDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d38e2784-d994-49bb-84f3-b1213635eb06"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""IntoDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cb00dea-247d-4c67-8c95-e526c0b18a53"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ItemOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8df3a10-3003-470c-bcb9-e04acd21441e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ItemTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c095bb86-afdf-4b4f-aeab-71682d980fd0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ItemThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65d07f77-c77f-4345-becf-a4278cf8b67b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ItemFour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""541c04f3-138f-4150-b268-507a7cb52d06"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""ItemFive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c238d40-840f-4629-88bb-c5baf07931f5"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""GetItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""686b332b-3beb-47e9-82f9-25eb8b250e29"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""dd531ddb-94b9-4f19-941a-c1867655a8e9"",
            ""actions"": [
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""63313c0e-a6fb-4a08-9d37-54aa78c5dd05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HighLight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3c253c2b-0611-4ac4-a13a-ea55da65da5b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""893b6217-5e67-49a7-85b2-067fbe092c05"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""c478d627-daca-4ccf-806f-2c9682bae5c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""442ed7a4-58be-4a68-9c25-fc18d92b70b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""86977e86-fa72-4d1d-a24d-1365ba359280"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""904471c5-5979-41b4-9620-d540d1e4f29b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a7b826ea-e1f1-4c3a-82e2-c7afd705abec"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19aa27a9-5133-43c4-b0f8-c42ca06500f5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""HighLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Move"",
                    ""id"": ""f10bff69-7c86-457b-b646-102be42c7d6e"",
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
                    ""id"": ""855a9802-64a9-4a8d-a9f7-f19356322aec"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3646433a-46ca-4140-9ff3-c31bd60043ed"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4714ab11-5120-4ec6-9b10-e39337c1673f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""58ad16aa-351f-4b4b-9562-897aadc0ca4b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7519e151-ce6e-4104-b7bf-bc3b46567c2d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""108f2c2c-c2e4-48f2-af47-24d5cf417230"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c3bfbaa-0656-4d59-be18-9ab1658605d9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19c755c6-1604-437d-8e78-fb24b868619b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoard"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoard"",
            ""bindingGroup"": ""KeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Defend = m_Player.FindAction("Defend", throwIfNotFound: true);
        m_Player_IntoDoor = m_Player.FindAction("IntoDoor", throwIfNotFound: true);
        m_Player_ItemOne = m_Player.FindAction("ItemOne", throwIfNotFound: true);
        m_Player_ItemTwo = m_Player.FindAction("ItemTwo", throwIfNotFound: true);
        m_Player_ItemThree = m_Player.FindAction("ItemThree", throwIfNotFound: true);
        m_Player_ItemFour = m_Player.FindAction("ItemFour", throwIfNotFound: true);
        m_Player_ItemFive = m_Player.FindAction("ItemFive", throwIfNotFound: true);
        m_Player_GetItem = m_Player.FindAction("GetItem", throwIfNotFound: true);
        m_Player_UseItem = m_Player.FindAction("UseItem", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Press = m_UI.FindAction("Press", throwIfNotFound: true);
        m_UI_HighLight = m_UI.FindAction("HighLight", throwIfNotFound: true);
        m_UI_Move = m_UI.FindAction("Move", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Right = m_UI.FindAction("Right", throwIfNotFound: true);
        m_UI_Left = m_UI.FindAction("Left", throwIfNotFound: true);
        m_UI_Exit = m_UI.FindAction("Exit", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Defend;
    private readonly InputAction m_Player_IntoDoor;
    private readonly InputAction m_Player_ItemOne;
    private readonly InputAction m_Player_ItemTwo;
    private readonly InputAction m_Player_ItemThree;
    private readonly InputAction m_Player_ItemFour;
    private readonly InputAction m_Player_ItemFive;
    private readonly InputAction m_Player_GetItem;
    private readonly InputAction m_Player_UseItem;
    public struct PlayerActions
    {
        private @M_Input m_Wrapper;
        public PlayerActions(@M_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Defend => m_Wrapper.m_Player_Defend;
        public InputAction @IntoDoor => m_Wrapper.m_Player_IntoDoor;
        public InputAction @ItemOne => m_Wrapper.m_Player_ItemOne;
        public InputAction @ItemTwo => m_Wrapper.m_Player_ItemTwo;
        public InputAction @ItemThree => m_Wrapper.m_Player_ItemThree;
        public InputAction @ItemFour => m_Wrapper.m_Player_ItemFour;
        public InputAction @ItemFive => m_Wrapper.m_Player_ItemFive;
        public InputAction @GetItem => m_Wrapper.m_Player_GetItem;
        public InputAction @UseItem => m_Wrapper.m_Player_UseItem;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Defend.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefend;
                @Defend.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefend;
                @Defend.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefend;
                @IntoDoor.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIntoDoor;
                @IntoDoor.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIntoDoor;
                @IntoDoor.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnIntoDoor;
                @ItemOne.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemOne;
                @ItemOne.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemOne;
                @ItemOne.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemOne;
                @ItemTwo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemTwo;
                @ItemTwo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemTwo;
                @ItemTwo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemTwo;
                @ItemThree.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemThree;
                @ItemThree.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemThree;
                @ItemThree.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemThree;
                @ItemFour.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFour;
                @ItemFour.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFour;
                @ItemFour.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFour;
                @ItemFive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFive;
                @ItemFive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFive;
                @ItemFive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemFive;
                @GetItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetItem;
                @GetItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetItem;
                @GetItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGetItem;
                @UseItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Defend.started += instance.OnDefend;
                @Defend.performed += instance.OnDefend;
                @Defend.canceled += instance.OnDefend;
                @IntoDoor.started += instance.OnIntoDoor;
                @IntoDoor.performed += instance.OnIntoDoor;
                @IntoDoor.canceled += instance.OnIntoDoor;
                @ItemOne.started += instance.OnItemOne;
                @ItemOne.performed += instance.OnItemOne;
                @ItemOne.canceled += instance.OnItemOne;
                @ItemTwo.started += instance.OnItemTwo;
                @ItemTwo.performed += instance.OnItemTwo;
                @ItemTwo.canceled += instance.OnItemTwo;
                @ItemThree.started += instance.OnItemThree;
                @ItemThree.performed += instance.OnItemThree;
                @ItemThree.canceled += instance.OnItemThree;
                @ItemFour.started += instance.OnItemFour;
                @ItemFour.performed += instance.OnItemFour;
                @ItemFour.canceled += instance.OnItemFour;
                @ItemFive.started += instance.OnItemFive;
                @ItemFive.performed += instance.OnItemFive;
                @ItemFive.canceled += instance.OnItemFive;
                @GetItem.started += instance.OnGetItem;
                @GetItem.performed += instance.OnGetItem;
                @GetItem.canceled += instance.OnGetItem;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Press;
    private readonly InputAction m_UI_HighLight;
    private readonly InputAction m_UI_Move;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Right;
    private readonly InputAction m_UI_Left;
    private readonly InputAction m_UI_Exit;
    public struct UIActions
    {
        private @M_Input m_Wrapper;
        public UIActions(@M_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Press => m_Wrapper.m_UI_Press;
        public InputAction @HighLight => m_Wrapper.m_UI_HighLight;
        public InputAction @Move => m_Wrapper.m_UI_Move;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Right => m_Wrapper.m_UI_Right;
        public InputAction @Left => m_Wrapper.m_UI_Left;
        public InputAction @Exit => m_Wrapper.m_UI_Exit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Press.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPress;
                @HighLight.started -= m_Wrapper.m_UIActionsCallbackInterface.OnHighLight;
                @HighLight.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnHighLight;
                @HighLight.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnHighLight;
                @Move.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMove;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Right.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Exit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @HighLight.started += instance.OnHighLight;
                @HighLight.performed += instance.OnHighLight;
                @HighLight.canceled += instance.OnHighLight;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyBoardSchemeIndex = -1;
    public InputControlScheme KeyBoardScheme
    {
        get
        {
            if (m_KeyBoardSchemeIndex == -1) m_KeyBoardSchemeIndex = asset.FindControlSchemeIndex("KeyBoard");
            return asset.controlSchemes[m_KeyBoardSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDefend(InputAction.CallbackContext context);
        void OnIntoDoor(InputAction.CallbackContext context);
        void OnItemOne(InputAction.CallbackContext context);
        void OnItemTwo(InputAction.CallbackContext context);
        void OnItemThree(InputAction.CallbackContext context);
        void OnItemFour(InputAction.CallbackContext context);
        void OnItemFive(InputAction.CallbackContext context);
        void OnGetItem(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPress(InputAction.CallbackContext context);
        void OnHighLight(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
