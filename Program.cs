/*
using System;

namespace BinarySearchProject{
     class Program
     {
        static void Main(string[] args)
        {
            int[] nums = {2,4,6,8,10,12,14,22,24,35,56,67,87,333,678,900,3333,44444,55555,62000};
            int target = 44444;
            int index = BinarySearch(nums,target);

            if(index != -1)
            {
                Console.WriteLine("Your value " + target + " was found at index " + index);
            }
            else{
                Console.WriteLine("Error, target value is not in list");
            }

        }
        public static int BinarySearch(int[]array , int target)
        {
            int left = 0;
            int right = array.Length-1;

            while(left <= right)
            {
                int mid = (left + right)/2;

                if(array[mid] == target)
                {
                    return mid;
                }
                else if(array[mid]< target)
                {
                    left = mid + 1;
                }
                else{
                    right = mid-1;
                }
            }
            return -1;
        }
     }

}

*/

/*


using System;

namespace BinarySearchProject{
     class Program
     {
        static void Main(string[] args)
        {
            int[] nums = {233333,424,621,8,133330,1212,13334,22,24255,355555,5664252,67777,837,333,67844,900,3333,44444,55555,62000};
            int target = 837;
            int index = LinearSearch(nums,target);

            if(index != -1)
            {
                Console.WriteLine("Your value " + target + " was found at index " + index);
            }
            else{
                Console.WriteLine("Error, target value is not in list");
            }

        }
        public static int LinearSearch(int[]array , int target)
        {
            for(int i = 0; i<array.Length - 1; i++)
            {
                if(array[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
     }

}



*/
















