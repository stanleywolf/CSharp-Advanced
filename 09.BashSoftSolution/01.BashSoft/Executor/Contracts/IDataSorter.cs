using System;
using System.Collections.Generic;
using System.Text;

public interface IDataSorter
{
    void OrderAndTake(Dictionary<string, double> studentsWithMark, string comparison, int studentsToTake);

    void PrintStudents(Dictionary<string, double> studentsSorted);
}