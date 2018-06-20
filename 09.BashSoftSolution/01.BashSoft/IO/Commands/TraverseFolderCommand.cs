using System;
using System.Collections.Generic;
using System.Text;

public class TraverseFolderCommand:Command
    {
        public TraverseFolderCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
        if (this.Data.Length == 1)
        {
            this.InputOutputManager.TraverseDirectory(0);
        }
        else if (this.Data.Length == 2)
        {
            int depth;
            bool hasParsed = int.TryParse(this.Data[1], out depth);
            if (hasParsed)
            {
                this.InputOutputManager.TraverseDirectory(depth);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
            }
        }
        else
        {
            throw new InvalidCommandException(this.Input);
        }
    }
    }

