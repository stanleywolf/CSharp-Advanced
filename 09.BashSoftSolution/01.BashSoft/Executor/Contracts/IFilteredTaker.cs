using System;
using System.Collections.Generic;
using System.Text;

public interface IFilteredTaker
{
    void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null);
}