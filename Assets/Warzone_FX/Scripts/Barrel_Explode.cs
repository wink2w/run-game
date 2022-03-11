using UnityEngine;
using System.Collections;

public class Barrel_Explode : MonoBehaviour {
	
public GameObject BarrelExplode;
public AnimationClip BarrelExplodeAnim;
public ParticleSystem ExplodeVideoParticles;
public ParticleSystem SmokeParticles;
public ParticleSystem SparkParticles;
public Light ExplodeLight;
public AudioSource ExplodeAudio;
public GameObject ScorchMark;

 private float fadeStart = 4;
 private float fadeEnd = 0;
 private float fadeTime = 1;
 private float t = 0.0f;

void Update (){
   
   if (Input.GetButtonDown("Fire1")) //check to see if the left mouse was pushed.
  
    {
			
       BarrelExplode.GetComponent<Animation>().Play("BarrelExplodeAnim");
       ExplodeVideoParticles.Play();
       SmokeParticles.Play();
       SparkParticles.Play();
       ExplodeAudio.Play();
       ScorchMark.SetActive(true);
	   StartCoroutine("FadeLight");
      
     }
       
   
}


IEnumerator FadeLight (){
   
  
    while (t < fadeTime)          
	{
			
        t += Time.deltaTime;           
        ExplodeLight.intensity = Mathf.Lerp(fadeStart, fadeEnd, t / fadeTime);
        yield return 0;
               
    }              
            
t = 0;
   
   
}


}