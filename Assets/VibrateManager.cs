


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateManager : MonoBehaviour
{


    private float vibrateTime;
    private bool isVibrating = false;
    private float timer = 0.5f;
    private float currTime = 0f;
    void update()
    {
        if (!isVibrating) return;
        if (currTime > vibrateTime)
        {
            currTime = 0f;
            isVibrating = false;
            return;
        }
        currTime += Time.deltaTime;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.5f;
            Handheld.Vibrate();
        }
    }
    public void Vibrate()
    {
        Debug.Log("成功调用");
        Handheld.Vibrate();
    }
    //public void Vibrate(float vibrateTime) {
    //    Debug.Log("vibrating!");

    //    isVibrating = true;
    //    this.vibrateTime = vibrateTime;
    //}




    //#if UNITY_ANDROID && !UNITY_EDITOR
    //    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    //    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    //    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
    //#else
    //    public static AndroidJavaClass unityPlayer;
    //    public static AndroidJavaObject currentActivity;
    //    public static AndroidJavaObject vibrator;
    //#endif


    //    public void Vibrate(int milliseconds) {
    //        Vibrate((long)milliseconds);
    //    }


    //    private static void Vibrate()
    //    {
    //        if (isAndroid())
    //            vibrator.Call("vibrate");
    //        else
    //            Handheld.Vibrate();
    //    }


    //    private static void Vibrate(long milliseconds)
    //    {
    //        if (isAndroid())
    //        {

    //            Debug.Log("PC成功调用");
    //            vibrator.Call("vibrate", milliseconds);
    //        }
    //        else {
    //            Debug.Log("PC成功调用");
    //            Handheld.Vibrate();
    //        }
    //    }

    //    private static void Vibrate(long[] pattern, int repeat)
    //    {
    //        if (isAndroid())
    //            vibrator.Call("vibrate", pattern, repeat);
    //        else
    //            Handheld.Vibrate();
    //    }

    //    public static bool HasVibrator()
    //    {
    //        return isAndroid();
    //    }

    //    public static void Cancel()
    //    {
    //        if (isAndroid())
    //            vibrator.Call("cancel");
    //    }

    //    private static bool isAndroid()
    //    {
    //#if UNITY_ANDROID && !UNITY_EDITOR
    //	return true;
    //#else
    //        return false;
    //#endif
    //    }

}

