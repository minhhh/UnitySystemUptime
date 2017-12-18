using UnityEngine;
using System.Runtime.InteropServices;

public class SystemUptime
{
#if UNITY_ANDROID && !UNITY_EDITOR
    private static AndroidJavaClass _androidJavaClass;

    private static AndroidJavaClass androidJavaClass
    {
        get
        {
            if (_androidJavaClass == null) {
                _androidJavaClass = new AndroidJavaClass("android.os.SystemClock");
            }
            return _androidJavaClass;
        }
    }
#elif UNITY_IOS && !UNITY_EDITOR
    [DllImport ("__Internal")]
    private static extern float GetSystemUptime ();
#endif

    public static float GetDeviceUptime()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (androidJavaClass == null) {
            return 0;
        }
        long milliSeconds = androidJavaClass.CallStatic<long>("elapsedRealtime");
        return milliSeconds * 0.001f;
#elif UNITY_IOS && !UNITY_EDITOR
        return GetSystemUptime ();
#else
        return Time.realtimeSinceStartup;
#endif
    }
}
