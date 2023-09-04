
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
   private AudioSource _audioSource;
   [SerializeField] private StoveCounter stoveCounter;
   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   private void Start()
   {
      stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
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
}
