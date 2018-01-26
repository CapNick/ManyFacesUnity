//Note: Inspired by and uses some code found here: http://forum.unity3d.com/threads/windows-api-calls.127719/
//Note: Modified the code from this thread here: 
// https://forum.unity.com/threads/solved-windows-transparent-window-with-opaque-contents-lwa_colorkey.323057/

using System.Runtime.InteropServices;
using UnityEngine;

// Pro and Free!!!

//WARNING!! Running this code inside Unity when not in a build will make the entire development environment transparent
//Restarting Unity would however resolve

public class TransparentWindow2 : MonoBehaviour {
    [DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
    private static extern int SetWindowLong(int hwnd, int nIndex, long dwNewLong);

    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
    private static extern int SetLayeredWindowAttributes(int hwnd, int crKey, byte bAlpha, int dwFlags);

    [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
    private static extern int GetActiveWindow();

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    private static extern long GetWindowLong(int hwnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    private static extern int SetWindowPos(int hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, int uFlags);

    private void Start() {
#if !UNITY_EDITOR

//        var handle = GetActiveWindow();
//        var fWidth = Screen.width;
//        var fHeight = Screen.height;
//
//        SetWindowLong(hwnd, GWL_STYLE, WS_POPUP | WS_VISIBLE);
//        SetWindowLong (hwnd, -20, (uint)524288 | (uint)32);//GWL_EXSTYLE=-20; WS_EX_LAYERED=524288=&h80000, WS_EX_TRANSPARENT=32=0x00000020L
//        SetLayeredWindowAttributes (hwnd, 0, 255, 2);// Transparency=51=20%, LWA_ALPHA=2
//        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, fWidth, fHeight, 32 | 64); //SWP_FRAMECHANGED = 0x0020 (32); //SWP_SHOWWINDOW = 0x0040 (64)
//
//        Application.runInBackground = true;
    
#endif
    }
} // end of file