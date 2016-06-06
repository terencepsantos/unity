using System.Collections.Generic;

public static class Shuffle
{
    public static int[] ShuffleArray(int[] array)
    {
        System.Random r = new System.Random();

        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            int k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }

        return array;
    }


    public static List<int> ShuffleListOfInts(List<int> listOfInts)
    {
        System.Random r = new System.Random();

        for (int i = listOfInts.Count; i > 0; i--)
        {
            int j = r.Next(i);
            int k = listOfInts[j];
            listOfInts[j] = listOfInts[i - 1];
            listOfInts[i - 1] = k;
        }

        return listOfInts;
    }
}
