namespace developer0223.Library.UI
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class PlayerEventCountHolder : MonoBehaviour
    {
        [SerializeField] private int count = 0;

        public int GetCount()
        {
            return count;
        }

        public int IncreaseCoune()
        {
            count += 1;
            return count;
        }
    }
}