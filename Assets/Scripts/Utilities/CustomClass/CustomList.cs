namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    public class CustomList<T> : List<T>
    {
        public static CustomList<T> Create(List<T> list)
        {
            CustomList<T> result = new CustomList<T>();
            foreach (T element in list)
            {
                result.Add(element);
            }

            return result;
        }

        public static CustomList<T> operator + (CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> result = new CustomList<T>();
            foreach (T element in a)
            {
                result.Add(element);
            }
            foreach (T element in b)
            {
                result.Add(element);
            }

            return result;
        }
    }
}
