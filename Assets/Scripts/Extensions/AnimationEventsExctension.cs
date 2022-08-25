using UnityEngine;

public static class AnimationEventsExtension{
  public static void AddAnimationEvent(this AnimationClip clip, float time, string functionName) {
    float clipDuration = clip.length;

    if(time < 0f){
      Debug.LogError("Event time must be greater >= than 0.0f seconds");
      return;
    }else if(time > clipDuration){
      Debug.LogError("Event time must be less <= than the clip's duration: " + clipDuration + "f seconds");
      return;
    }

    AnimationEvent animationEvent = new AnimationEvent{
      time = time,
      functionName = functionName
    };

    clip.AddEvent(animationEvent);
  }
}