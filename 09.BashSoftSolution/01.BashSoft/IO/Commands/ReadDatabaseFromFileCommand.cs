using System;
using System.Collections.Generic;
using System.Text;

public class ReadDatabaseFromFileCommand:Command
    {
        public ReadDatabaseFromFileCommand(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
        if (this.Data.Length == 2)
        {
            string fileName = this.Data[1];
            this.Repository.LoadData(fileName);
        }
        else
        {
            throw new InvalidCommandException(this.Input);
        }
    }
    }
   