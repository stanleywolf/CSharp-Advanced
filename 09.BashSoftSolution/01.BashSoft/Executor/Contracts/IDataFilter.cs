using System;
using System.Collections.Generic;
using System.Text;

public interface IDataFilter
{

    void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilters, int studentsToTake);
}