using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    float CourseScore;
    public string CourseName;

    //the completed factor variables are assigned to this list for ease of calculation.
    List<float> CompletedFactors = new List<float>();

    [Space(10)]
    //The completed factor variables. They determine the completed amount of modules, readings, quizzes, and assignments within the course.
    public float CompletedModules;
    public float CompletedReadings;
    public float CompletedQuizzes;
    public float CompletedAssignments;

    //Determines if the instructor has taught the course before or not.
    public bool TaughtBefore;

    //the total factor variables are assigned to this list for ease of calculation.
    List<float> TotalFactors = new List<float>();

    [Space(10)]
    //The total factor variables. They determine the total amount of modules, readings, quizzes, and assignments within the course.
    public float TotalModules;
    public float TotalReadings;
    public float TotalQuizzes;
    public float TotalAssignments;

    //A list of percentages for each corresponding factor.
    List<float> Percentages = new List<float>();

    //The maximum and minimum score the student can receive for the course.
    float MaxScore = 10;
    float MinScore = 1;

    void Start()
    {
        //Assigns the completed factor variables to their respective list.
        CompletedFactors.Add(CompletedModules);
        CompletedFactors.Add(CompletedReadings);
        CompletedFactors.Add(CompletedReadings);
        CompletedFactors.Add(CompletedAssignments);

        //Assigns the total factor variables to their respective list.
        TotalFactors.Add(TotalModules);
        TotalFactors.Add(TotalReadings);
        TotalFactors.Add(TotalQuizzes);
        TotalFactors.Add(TotalAssignments);

        //Assigns percentages to each corresponding factor.
        Percentages.Add(0.15f); //Modules are 15% of the total score.
        Percentages.Add(0.30f); //Readings are 30% of the total score.
        Percentages.Add(0.15f); //Quizzes are 15% of the total score.
        Percentages.Add(0.30f); //Assignments are 30% of the total score.
        Percentages.Add(0.10f); //If the instructor has NOT taught the class before, the student does receive the final 10% of their score.
        Percentages.Add(0f); //If the instructor has taught the class before, the student does NOT receive the final 10% of their score.

        //All factors are converted before the final score is calculated.
        ConvertAllFactors();

        //Determines if the instructor has taught the course before. The score is calculated with this answer in mind.
        if(TaughtBefore == true)
        {
            //Instructor has taught the course before. The student does NOT receive the final 10%.
            DetermineCourseScore(5);
        }
        else
        {
            //Instructor has NOT taught the course before. The student receives the final 10%.
            DetermineCourseScore(4);
        }

        //Outputs the final score and course name in the console.
        Debug.Log("Course Name: " + CourseName);
        Debug.Log("Final Course Score: " + CourseScore);

        //DebugIndividualFactors(3);
    }

    void DetermineCourseScore(int TaughtCondition)
    {
        //Averages out both the completed and total factors and compares them to determine the final course score.
        CourseScore = (CompletedFactors[0] + CompletedFactors[1] + CompletedFactors[2] + CompletedFactors[3] + (Percentages[TaughtCondition] * MaxScore))*(MaxScore/ (TotalFactors[0] + TotalFactors[1] + TotalFactors[2] + TotalFactors[3] + (Percentages[4] * MaxScore)));

        //Limits the final course score to not surpass the minimum or maximum score.
        if(CourseScore < MinScore)
        {
            CourseScore = MinScore;
        } 
        else if(CourseScore > MaxScore)
        {
            CourseScore = MaxScore;
        }
    }

    //Converts all factors, aside from TaughtBefore, to prepare them for being averaged out.
    void ConvertAllFactors()
    {
        ConvertIndividualFactors(0);
        ConvertIndividualFactors(1);
        ConvertIndividualFactors(2);
        ConvertIndividualFactors(3);
    }

    //Converts a factor to make it a portion of the maximum score according to its respective percentage.
    void ConvertIndividualFactors(int Number)
    {
        CompletedFactors[Number] = (CompletedFactors[Number] * Percentages[Number]) * MaxScore;
        TotalFactors[Number] = (TotalFactors[Number] * Percentages[Number]) * MaxScore;
    }

    /*void DebugIndividualFactors(int FactorNumber)
    {
        Debug.Log("Completed Factor[" + FactorNumber + "]: " + CompletedFactors[FactorNumber]);
        Debug.Log("Total Factor[" + FactorNumber + "]: " + TotalFactors[FactorNumber]);
    }*/
}
