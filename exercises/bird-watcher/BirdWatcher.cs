using System;
class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1] += 1;
    } 

    public bool HasDayWithoutBirds()
    {
        if (Array.IndexOf(birdsPerDay, 0) >= 0)
        {
            return true;
        }
        else
        {
            {
                return false;
            }
        }
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            count += birdsPerDay[i];
        }
        return count;
    }

    public int BusyDays()
    {
        int count = 0;
        foreach (int day in birdsPerDay)
        {
            if (day >= 5)
            {
                count += 1;
            }
        }
        return count;
    }
}
