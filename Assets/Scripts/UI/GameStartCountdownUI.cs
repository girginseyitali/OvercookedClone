using System;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
   private const string NUMBER_POPUP = "NumberPopUp";
   [SerializeField] private TextMeshProUGUI countdownText;
   private Animator _animator;
   private int previousCountdownNumber;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   private void Start()
   {
      GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
      Hide();
   }

   private void GameManager_OnStateChanged(object sender, EventArgs e)
   {
      if (GameManager.Instance.IsCountdownToStartActive())
      {
         Show();
      }
      else
      {
         Hide();
      }
   }

   private void Update()
   {
      int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
      
      countdownText.text = countdownNumber.ToString();

      if (previousCountdownNumber != countdownNumber)
      {
         previousCountdownNumber = countdownNumber;
         _animator.SetTrigger(NUMBER_POPUP);
         SoundManager.Instance.PlayCountdownSound();
      }
   }

   private void Show()
   {
      gameObject.SetActive(true);
   }

   private void Hide()
   {
      gameObject.SetActive(false);
   }

   
}
