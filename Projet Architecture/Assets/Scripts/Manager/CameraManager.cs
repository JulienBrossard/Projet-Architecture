using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraManager : MonoBehaviour
{
    private Vignette vignette;
    public static CameraManager instance;
    [SerializeField] private PostProcessVolume volume;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        volume.profile.TryGetSettings(out vignette);
    }


    public void CameraVignetteEffectOnHurt()
    {
        if (vignette.active == false)
        {
            vignette.active = true;
            DOTween.To(() => vignette.intensity.value, x => vignette.intensity.value = x, 0.3f, 0.5f).SetInverted().OnComplete(() => vignette.active = false);
        }
    }
    
    private void ResetVignette()
    {
        vignette.intensity.value = 0;
        vignette.active = false;
    }
}
