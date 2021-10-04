using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;

namespace HomeWork1._2
{
     public class Algorithm
    {
        public static void Sort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }
                

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }


        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 

            if (l < n && arr[l] > arr[largest])
            {
                largest = l;
            }

            if (r < n && arr[r] > arr[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }

        public static void Factorial(int n, int count)
        {
            int result = 1;
            for (int i = 0; i < count; i++)
            {
                result *= n;
            }
        }

        static void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        static int GetNextStep(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public static void CombSort(int[] array, int count)
        {
            var arrayLength = count;
            var currentStep = count - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            for (var i = 1; i < arrayLength; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    { 
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
        }

        public static void GnomeSort(int[] inArray, int count)
        {
            int i = 1;
            int j = 2;
            while (i < count)
            {
                if (inArray[i - 1] < inArray[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    GnomeSwap(inArray, i - 1, i);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
        }
        static void GnomeSwap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

}
