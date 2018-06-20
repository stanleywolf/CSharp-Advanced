using System;
using System.Collections.Generic;
using System.Text;


    public class InputReader:IReader
    {
    private const string endCommand = "quit";

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }
        private IInterpreter interpreter;

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionsData.currentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (input == endCommand)
                {
                    break;
                }
                this.interpreter.InterpretCommand(input);
            }
        }
}

