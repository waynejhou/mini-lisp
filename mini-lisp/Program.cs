using System;
using System.Text;
using Antlr4.Runtime;
using System.Windows;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace minilisp
{
    /// <summary>
    /// Main class.
    /// </summary>
	class MainClass
	{
		public static void Main(string[] args)
		{
            bool showinput = false;
            foreach (var i in args)
            {
                DebugAction.debugmode |= (i == "--Debug" || i == "-d");
                showinput |= (i == "--ShowInput" || i == "-s");
            }
			string input = "";
			StringBuilder text = new StringBuilder();
            while ((input = Console.ReadLine()) != null) 
			{
				text.AppendLine(input);
			}
            if(showinput){
                Console.WriteLine("Input:");
				Console.WriteLine(text.ToString());
				Console.WriteLine("=======================");
            }
			var inputStream = new AntlrInputStream(text.ToString());
			var lgl = new lisp_gammarLexer(inputStream);
			var cts = new CommonTokenStream(lgl);
			var lgp = new lisp_gammarParser(cts);
            //var mes = new MyErrorStrategy();
            //lgp.ErrorHandler = mes;

            var mpel = new MyParserErrorListener();
            var lgbl = new lisp_gammarBaseListener();
            var mpl = new MyParserListener();
            lgp.RemoveErrorListeners();
            lgp.AddErrorListener(mpel);
			lgp.AddParseListener(mpl);
            lgp.prog();
		}

	}

    /// <summary>
    /// My parser error listener.
    /// </summary>


}
