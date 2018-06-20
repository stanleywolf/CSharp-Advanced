using System;
using System.Collections.Generic;
using System.Text;

public class CompareFileCommand : Command
{
    public CompareFileCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 3)
        {
            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.Judge.CompareContent(firstPath, secondPath);
        }
        else
        {
            throw new InvalidCommandException(this.Input);
        }
    }
}
  