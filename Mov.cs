using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Mov : MonoBehaviour
{
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    private const uint WM_USER = 0x0400;
    private const uint WM_HITMARKERMOVE = WM_USER + 1;

    private IntPtr targetWindow;

    void Start()
    {
        
        targetWindow = FindWindow(null, "TargetApplicationWindowName");

        if (targetWindow == IntPtr.Zero)
        {
            Debug.LogError("Target window not found");
        }
    }

    void Update()
    {
        
        Vector3 position = transform.position;

        
        int x = Mathf.FloorToInt(position.x * 100);
        int y = Mathf.FloorToInt(position.y * 100);
        int z = Mathf.FloorToInt(position.z * 100);

        
        int packedPosition = (x & 0xFFFF) | ((y & 0xFFFF) << 16);

        
        if (targetWindow != IntPtr.Zero)
        {
            PostMessage(targetWindow, WM_HITMARKERMOVE, (IntPtr)packedPosition, (IntPtr)z);
        }
    }
}




