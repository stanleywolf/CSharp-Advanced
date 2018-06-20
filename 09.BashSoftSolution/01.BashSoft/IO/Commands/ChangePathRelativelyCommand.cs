using System;
using System.Collections.Generic;
using System.Text;

public class ChangePathRelativelyCommand : Command
{
    public ChangePathRelativelyCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 2)
        {
            string relPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
        else
        {
            throw new InvalidCommandException(this.Input);
        }
    }
}


  