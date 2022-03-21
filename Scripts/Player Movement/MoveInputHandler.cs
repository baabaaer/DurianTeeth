using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputHandler : MonoBehaviour
{
    // Can we apply events here to PlayerMoveMouseNavMesh?

    public Vector3 MousePosition { get; private set; }
    public bool LeftClick { get; private set; }
    public bool RightClick { get; private set; }
    public bool MiddleButton { get; private set; }
    public Touch touching { get; private set; }

    public delegate void InputLeftClick();
    public event InputLeftClick inputLeftClick;
    public delegate void InputRightClick();
    public event InputRightClick inputRightClick;

    void Update()
    {
        MousePosition = Input.mousePosition;
        LeftClick = Input.GetMouseButtonDown(0);
        RightClick = Input.GetMouseButtonDown(1);
        MiddleButton = Input.GetMouseButton(2);

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touching = Input.GetTouch(i);
            }
        }

        if (LeftClick)
        {
            inputLeftClick?.Invoke();
        }

        if (RightClick)
        {
            inputRightClick?.Invoke();
        }
    }
}
