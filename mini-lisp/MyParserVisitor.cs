using System;
using Antlr4.Runtime;
namespace minilisp
{
    public class MyParserVisitor : lisp_gammarBaseVisitor<string>
    {
        public MyParserVisitor()
        {
        }
        public string s = "";
        public override string VisitTerminal(Antlr4.Runtime.Tree.ITerminalNode node)
        {
            s += " " + node.GetText() + " ";
            return base.VisitTerminal(node);
        }

        public class MyErrorStrategy : DefaultErrorStrategy
        {

        }

    }
}
