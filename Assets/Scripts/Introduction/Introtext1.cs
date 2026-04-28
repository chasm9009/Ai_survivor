using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

namespace DialougeSystem
{
    public class IntroText : MonoBehaviour
    {
        private TMP_Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private TMP_FontAsset tmp_Font;

        private void Awake()
        {
            textHolder = GetComponent<TMP_Text>(); // Get the TMP_Text component

            StartCoroutine(eightBitBaseClass.WriteText(input, textHolder, tmp_Font)); // Start the coroutine to write text
        }
    }
}


