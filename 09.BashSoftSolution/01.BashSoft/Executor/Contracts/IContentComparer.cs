using System;
using System.Collections.Generic;
using System.Text;

public interface IContentComparer
{
    void CompareContent(string userOutputPath, string expectedOutputPath);
}