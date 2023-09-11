
using System;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
   private AudioSource _audioSource;
   private float warningSoundTimer;
   private bool playWarningSound;
   [SerializeField] private StoveCounter stoveCounter;
   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   private void Start()
   {
      stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
      stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
   }

   private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
   {
      float burnShowProgressAmount = .5f;
      playWarningSound = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
   }

   private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
   {
      bool playSound = e.state is StoveCounter.State.Frying or StoveCounter.State.Fried;
      if (playSound)
      {
         _audioSource.Play();
      }
      else
      {
         _audioSource.Pause();
      }
   }

   private void Update()
   {
      if (playWarningSound)
      {
         warningSoundTimer -= Time.deltaTime;
         if (warningSoundTimer <= 0f)
         {
            float warningSoundTimerMax = .2f;
            warningSoundTimer = warningSoundTimerMax;
            
            SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
         }
      }
   }
}
