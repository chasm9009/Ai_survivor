using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using FMODUnity;
using System.Collections;

namespace DialougeSystem
{
    public class IntroText : MonoBehaviour
    {
        private TMP_Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private TMP_FontAsset tmp_Font;

        private void Start()
        {
            textHolder = GetComponent<TMP_Text>(); // Get the TMP_Text component

            StartCoroutine(eightBitBaseClass.WriteText(input, textHolder, tmp_Font)); // Start the coroutine to write text
               
            PlayIntro();
        }

        void PlayIntro()
        {
            StartCoroutine(ElonIntroCoroutine());
        }

        IEnumerator ElonIntroCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            SfxManager.Instance.PlayElonIntro();
    }
    }
}


