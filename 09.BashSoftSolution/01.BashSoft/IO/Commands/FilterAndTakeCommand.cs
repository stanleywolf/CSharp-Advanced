using System;
using System.Collections.Generic;
using System.Text;

public class FilterAndTakeCommand:Command
    {
        public FilterAndTakeCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
   
