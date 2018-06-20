using System;
using System.Collections.Generic;
using System.Text;

public interface IDatabase : IRequester, IFilteredTaker, IOrderedTaker
{
    void LoadData(string fileName);

    void UnloadData();
}