using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace minilisp
{
	public class MyParserListener : lisp_gammarBaseListener
	{
		private bool _FuncExp = false;
		private Dictionary<string, ParserRuleContext> _Symtable = new Dictionary<string, ParserRuleContext>();
        private int FunExpCounter = 0;
        public MyParserListener()
		{
		}
        public override void ExitEveryRule(ParserRuleContext context)
        {
			//DebugAction.tab--;
            //DebugAction.Debug_WriteLine("Exit " + lisp_gammarParser.ruleNames[context.RuleIndex] + ".");
            base.ExitEveryRule(context);
        }
		public override void EnterEveryRule(ParserRuleContext context)
		{
			//DebugAction.Debug_WriteLine("Enter " + lisp_gammarParser.ruleNames[context.RuleIndex] + ".");
            //DebugAction.tab++;
			base.EnterEveryRule(context);
		}
		public override void ExitDef_stmt(lisp_gammarParser.Def_stmtContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    var id = context.GetChild(2).GetText();
                    var val = context.GetChild(3).GetText();
                    DebugAction.Debug_WriteLine(val);
                    _Symtable.Add(id, context.GetChild(3) as ParserRuleContext );
                }
			}
			base.ExitDef_stmt(context);
		}
		public override void ExitPrint_stmt(lisp_gammarParser.Print_stmtContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    var a = context.GetChild(1).GetText();
                    var b = context.GetChild(2).GetText();
                    if (a == "print-num" && b[0] != '#')
                        Console.WriteLine(context.GetChild(2).GetText());
                    else if (a == "print-bool" && b[0] == '#')
                        Console.WriteLine(context.GetChild(2).GetText());
                    else
                        ParsingMessage.ErrorCode(4, context);
                }
			}
			base.ExitPrint_stmt(context);
		}
		public override void ExitFun_call(lisp_gammarParser.Fun_callContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    DebugAction.Debug_WriteLine(Context2String(context));
                    DebugAction.Debug_WriteLine(context.ChildCount);
                    DebugAction.Debug_WriteLine(context.GetChild(1).GetText());
                    DebugAction.Debug_WriteLine(context.GetChild(1).ChildCount);
                    DebugAction.Debug_WriteLine(context.GetChild(1).GetType());
                    ParserRuleContext fun = null;
                    ParserRuleContext IDs = null;
                    ParserRuleContext Body = null;
                    switch (context.GetChild(1).GetType().ToString())
                    {
                        case "lisp_gammarParser+Fun_expContext":
                                fun = context.GetChild(1) as ParserRuleContext;
                                IDs = context.GetChild(1).GetChild(2) as ParserRuleContext;
                                Body = context.GetChild(1).GetChild(3) as ParserRuleContext;
                            break;
                        case "lisp_gammarParser+Fun_nameContext":
                            if (context.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0) != null)
                            {
                                DebugAction.Debug_WriteLine(context.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetType());
                                fun = context.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0) as ParserRuleContext;
                                IDs = context.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2) as ParserRuleContext;
                                Body = context.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(3) as ParserRuleContext;
                            }
                            else
                            {
                                DebugAction.Debug_WriteLine("no");
                                fun = context.GetChild(1).GetChild(0).GetChild(0) as ParserRuleContext;
                                IDs = context.GetChild(1).GetChild(0).GetChild(0).GetChild(2) as ParserRuleContext;
                                Body = context.GetChild(1).GetChild(0).GetChild(0).GetChild(3) as ParserRuleContext;
                            }
                            break;

                    }
                    /*
                    var fun = context.GetChild(1).GetChild(0).GetChild(0);
                    var IDs = context.GetChild(1).GetChild(0).GetChild(0).GetChild(2);
                    var Body = context.GetChild(1).GetChild(0).GetChild(0).GetChild(3);*/

                    
                    DebugAction.Debug_WriteLine(fun.GetText());
                    DebugAction.Debug_WriteLine(IDs.GetText());
                    DebugAction.Debug_WriteLine(Body.GetText());
                    DebugAction.Debug_WriteLine(fun.ChildCount);
                    DebugAction.Debug_WriteLine(IDs.ChildCount);
                    DebugAction.Debug_WriteLine(Body.ChildCount);
                    var exp = Context2String(Body.GetChild(Body.ChildCount - 1));
                    DebugAction.Debug_WriteLine(exp);

                    if (IDs.ChildCount - 2 == context.ChildCount - 3)
                    {
                        for (int i = 1; i < IDs.ChildCount - 1; i++)
                        {
                            if(int.TryParse(Context2String(context.GetChild(i + 1)),out int b))
                            {
                                exp = exp.Replace(" " + IDs.GetChild(i).GetText() + " ", "  " + Context2String(context.GetChild(i + 1)) + "  ");
                            }
                        }
                        for (int i = 1; i < IDs.ChildCount - 1; i++)
                        {
                            if (!int.TryParse(Context2String(context.GetChild(i + 1)), out int b))
                            {
                                exp = exp.Replace(" " + IDs.GetChild(i).GetText() + " ", "  " + Context2String(context.GetChild(i + 1)) + "  ");
                            }
                        }
                    }
                    else
                        ParsingMessage.ErrorCode(5, context);
                    DebugAction.Debug_WriteLine("This is Exp: "+exp);
                    if (Body.ChildCount > 1)
                    {
                        for(int i = 0; i < Body.ChildCount-1; i++)
                        {
                            DebugAction.Debug_WriteLine(Body.GetChild(i).GetChild(2).GetText());
                            DebugAction.Debug_WriteLine(Body.GetChild(i).GetChild(3).GetText());
                            exp = exp.Replace(" " + Body.GetChild(i).GetChild(2).GetText() + " ", Context2String(Body.GetChild(i).GetChild(3)));
                        }
                        DebugAction.Debug_WriteLine(exp);
                    }
                    var stmtctx = ParseExp(exp);
                    var s = stmtctx.GetText();
                    DebugAction.Debug_WriteLine("THis is s:"+s);
                    DebugAction.Debug_WriteLine(stmtctx.GetText());
                    DebugAction.Debug_WriteLine(stmtctx.GetType());
                    if (int.TryParse(s,out int a) || s.StartsWith("#"))
                    {
                        DebugAction.Debug_WriteLine(1111);
                        ClearCtx(context);
                        AddCtx(context, stmtctx.GetText());
                    }
                    else{
                        DebugAction.Debug_WriteLine(2222);
                        ClearCtx(context);
                        context.AddChild(stmtctx as ParserRuleContext);
                    }



                    //DebugAction.Debug_WriteLine(context.GetChild(1).GetChild(0).GetChild(0).ChildCount);
                    /*
                    var funs = fun.Split('.');
                    var Idctx = ParseIDs(funs[0]);
                    if (Idctx.ChildCount - 2 == context.ChildCount - 3)
                        for (int i = 1; i < Idctx.ChildCount - 1; i++)
                        {
                            funs[1] = funs[1].Replace(" " + Idctx.GetChild(i).GetText() + " ", "  " + context.GetChild(i + 1).GetText() + "  ");
                        }
                    else
                        ParsingMessage.ErrorCode(5, context);
                    var stmtctx = ParseExp(funs[1]);
                    ClearCtx(context);
                    AddCtx(context, stmtctx.GetText());*/
                }
			}
			base.ExitFun_call(context);
		}
		public override void ExitFun_name(lisp_gammarParser.Fun_nameContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    string fn = context.GetText();
                    if (_Symtable.ContainsKey(fn))
                    {
                        ClearCtx(context);
                        context.AddChild(_Symtable[fn]);
                        //AddCtx(context, Context2String( _Symtable[fn]) );
                    }
                    else
                        ParsingMessage.ErrorCode(2, context);
                }
			}
			base.EnterFun_name(context);
		}
		public override void EnterFun_exp(lisp_gammarParser.Fun_expContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    _FuncExp = true;
                    base.EnterFun_exp(context);
                }
            }else{
                FunExpCounter++;
            }
		}
		public override void ExitFun_exp(lisp_gammarParser.Fun_expContext context)
		{
            if (!_IfExp)
            {
                if(FunExpCounter<=0)
                    _FuncExp = false;
                else{
                    FunExpCounter--;
                }
                var ids = context.GetChild(2).GetText();
                var funt = context.GetChild(3).GetText();
                //ClearCtx(context);
                //AddCtx(context, ids + "." + funt);
                base.ExitFun_exp(context);
            }
		}
		public override void ExitFun_IDs(lisp_gammarParser.Fun_IDsContext context)
		{/*
                    string a = "";
                    foreach (var i in context.children)
                    {
                        a += " " + i.GetText() +" ";
                    }
                    ClearCtx(context);
                    AddCtx(context, a);*/
			base.ExitFun_IDs(context);
		}
		public override void ExitFun_body(lisp_gammarParser.Fun_bodyContext context)
		{
            if (!_IfExp)
            {/*
                var fun = DealWithCtxTree(context);
                //Console.WriteLine("fun_body :[ "+fun+" ]");
                ClearCtx(context);
                AddCtx(context, fun);
                base.ExitFun_body(context);*/
            }
		}

		private string DealWithCtxTree(ParserRuleContext ctx)
		{
			MyParserVisitor mpv = new MyParserVisitor();
			mpv.Visit(ctx);
			return mpv.s;
		}

		public override void ExitVariable(lisp_gammarParser.VariableContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    string a = context.ID().GetText();
                    if (_Symtable.ContainsKey(a))
                    {
                        ClearCtx(context);
                        AddCtx(context, _Symtable[a].GetText());
                    }
                    else
                    {
                        ParsingMessage.ErrorCode(2, context);
                    }
                }
			}
			base.ExitVariable(context);
		}
		public override void ExitPlus(lisp_gammarParser.PlusContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    int ans = 0, n;
                    for (int i = 2; i < context.ChildCount - 1; i++)
                    {
                        if ( int.TryParse(context.GetChild(i).GetText(), out n) )
                            ans += Convert.ToInt32(context.children[i].GetText());
                        else
                            ParsingMessage.ErrorCode(4, context);
                    }
                    ClearCtx(context);
                    AddCtx(context, ans.ToString());
                }
			}
			base.ExitPlus(context);
		}
		public override void ExitMinus(lisp_gammarParser.MinusContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    int a = 0, b = 0;
                    if ( int.TryParse( context.GetChild(2).GetText(), out a ) )
                        a = Convert.ToInt32(context.GetChild(2).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
                    if (int.TryParse(context.GetChild(3).GetText(), out b) )
                        b = Convert.ToInt32(context.GetChild(3).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
                    
                    ClearCtx(context);
                    AddCtx(context, (a - b).ToString());
                }
			}
			base.ExitMinus(context);
		}
		public override void ExitMultiply(lisp_gammarParser.MultiplyContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    int ans = 1,n;
                    for (int i = 2; i < context.ChildCount - 1; i++)
                    {
                        if (int.TryParse(context.GetChild(i).GetText(), out n))
                            ans *= Convert.ToInt32(context.children[i].GetText());
						else
							ParsingMessage.ErrorCode(4, context);
                    }
                    ClearCtx(context);
                    AddCtx(context, ans.ToString());
                }
			}

			base.ExitMultiply(context);
		}
		public override void ExitDivide(lisp_gammarParser.DivideContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
					int a = 0, b = 0;
					if (int.TryParse(context.GetChild(2).GetText(), out a))
						a = Convert.ToInt32(context.GetChild(2).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
					if (int.TryParse(context.GetChild(3).GetText(), out b))
						b = Convert.ToInt32(context.GetChild(3).GetText());
					else
						ParsingMessage.ErrorCode(4, context);

					ClearCtx(context);
                    AddCtx(context, (a / b).ToString());
                }
			}
			base.ExitDivide(context);
		}
		public override void ExitModulus(lisp_gammarParser.ModulusContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
					int a = 0, b = 0;
					if (int.TryParse(context.GetChild(2).GetText(), out a))
						a = Convert.ToInt32(context.GetChild(2).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
					if (int.TryParse(context.GetChild(3).GetText(), out b))
						b = Convert.ToInt32(context.GetChild(3).GetText());
					else
						ParsingMessage.ErrorCode(4, context);

					ClearCtx(context);
                    AddCtx(context, (a % b).ToString());
                }
			}
			base.ExitModulus(context);
		}

		public override void ExitAnd_op(lisp_gammarParser.And_opContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    bool ans = true;
                    for (int i = 2; i < context.ChildCount - 1; i++)
                    {
						if (context.children[i].GetText()[0] == '#')
							ans &= (context.children[i].GetText() == "#t");
						else
							ParsingMessage.ErrorCode(4, context);
                        
                    }
                    ClearCtx(context);
                    AddCtx(context, ans ? "#t" : "#f");
                }
			}
			base.ExitAnd_op(context);
		}
		public override void ExitOr_op(lisp_gammarParser.Or_opContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    bool ans = false;
                    for (int i = 2; i < context.ChildCount - 1; i++)
                    {
						if (context.children[i].GetText()[0] == '#')
							ans |= (context.children[i].GetText() == "#t");
						else
							ParsingMessage.ErrorCode(4, context);

					}
                    ClearCtx(context);
                    AddCtx(context, ans ? "#t" : "#f");
                }
			}
			base.ExitOr_op(context);
		}
		public override void ExitNot_op(lisp_gammarParser.Not_opContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    bool a = false;
					if (context.GetChild(2).GetText()[0] == '#')
                        a = (context.GetChild(2).GetText()=="#t");
					else
						ParsingMessage.ErrorCode(4, context);
                    ClearCtx(context);
                    AddCtx(context, (!a) ? "#t" : "#f");
                }
			}
			base.ExitNot_op(context);
		}

		public override void ExitGreater(lisp_gammarParser.GreaterContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
					int a = 0, b = 0;
					if (int.TryParse(context.GetChild(2).GetText(), out a))
						a = Convert.ToInt32(context.GetChild(2).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
					if (int.TryParse(context.GetChild(3).GetText(), out b))
						b = Convert.ToInt32(context.GetChild(3).GetText());
					else
						ParsingMessage.ErrorCode(4, context);

					ClearCtx(context);
                    AddCtx(context, (a > b) ? "#t" : "#f");
                }
			}
			base.ExitGreater(context);
		}
		public override void ExitSmaller(lisp_gammarParser.SmallerContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
					int a = 0, b = 0;
					if (int.TryParse(context.GetChild(2).GetText(), out a))
						a = Convert.ToInt32(context.GetChild(2).GetText());
					else
						ParsingMessage.ErrorCode(4, context);
					if (int.TryParse(context.GetChild(3).GetText(), out b))
						b = Convert.ToInt32(context.GetChild(3).GetText());
					else
						ParsingMessage.ErrorCode(4, context);

					ClearCtx(context);
                    AddCtx(context, (a < b) ? "#t" : "#f");
                }
			}
			base.ExitSmaller(context);
		}
		public override void ExitEqual(lisp_gammarParser.EqualContext context)
		{
			if (!_FuncExp)
			{
                if (!_IfExp)
                {
                    if (int.TryParse(context.GetChild(2).GetText(), out int num)) { }
                    else
                        ParsingMessage.ErrorCode(4, context);
                    bool ans = true;
                    for (int i = 2; i < context.ChildCount - 1; i++)
                    {
                        if (int.TryParse(context.GetChild(i).GetText(), out int n))
                            ans &= num == n;
                        else
                            ParsingMessage.ErrorCode(4, context);
                    }
                    ClearCtx(context);
                    AddCtx(context, ans ? "#t" : "#f"); 
                }
			}
			base.ExitEqual(context);
		}

        private bool _IfExp = false;
        public override void EnterIf_exp(lisp_gammarParser.If_expContext context)
        {
            if (!_FuncExp){
                if (!_IfExp)
                {

                }
            }

            base.EnterIf_exp(context);
        }
		public override void ExitIf_exp(lisp_gammarParser.If_expContext context)
		{
			if (!_FuncExp)
			{

                ParserRuleContext c;
                if( context.GetChild(2).GetText()=="#t"){
                    c = ParseExp(context.GetChild(3).GetText());
                }else{
                    c = ParseExp(context.GetChild(4).GetText());
                }
                ClearCtx(context);
                AddCtx(context,c.GetText());
			}
			base.ExitIf_exp(context);
		}
        public override void EnterThan_exp(lisp_gammarParser.Than_expContext context)
        {
			if (!_IfExp)
			{

                _IfExp = true;
            }
            base.EnterThan_exp(context);
        }
        public override void ExitThan_exp(lisp_gammarParser.Than_expContext context)
        {

            _IfExp = false;
			string s = DealWithCtxTree(context);
			ClearCtx(context);
			AddCtx(context, s);
            base.ExitThan_exp(context);
        }
        public override void EnterElse_exp(lisp_gammarParser.Else_expContext context)
        {
            if (!_IfExp)
            {

                _IfExp = true;
            }
            base.EnterElse_exp(context);
        }
        public override void ExitElse_exp(lisp_gammarParser.Else_expContext context)
        {

            _IfExp = false;
            string s = DealWithCtxTree(context);
            ClearCtx(context);
            AddCtx(context,s);
            base.ExitElse_exp(context);
        }
		private void ClearCtx(ParserRuleContext ctx)
		{
			while (ctx.ChildCount != 0)
			{
				ctx.RemoveLastChild();
			}
		}
		private void AddCtx(ParserRuleContext ctx, string s)
		{
			ctx.AddChild(new CommonToken(0, s));
		}
		private ParserRuleContext ParseIDs(string s)
		{
			var l = new lisp_gammarParser(new CommonTokenStream(new lisp_gammarLexer(new AntlrInputStream(s))));
			return l.fun_IDs();
		}
		private ParserRuleContext ParseExp(string s)
		{
			var l = new lisp_gammarParser(new CommonTokenStream(new lisp_gammarLexer(new AntlrInputStream(s))));
			l.AddParseListener(this);
            l.RemoveErrorListeners();
            l.AddErrorListener(new MyParserErrorListener());
			return l.exp();
		}
        private string Context2String(IParseTree t)
        {
            var mpv = new MyParserVisitor();
            mpv.Visit(t);
            return mpv.s;
        }
    }

	public class MyParserErrorListener : BaseErrorListener
	{
		public override void SyntaxError(System.IO.TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
		{
			//Console.WriteLine(String.Format("SyntaxError at line {0}:{1}", line, charPositionInLine));
			//Console.WriteLine(msg);
			//base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            Console.WriteLine("error");
			Environment.Exit(1);
		}
	}
	public static class ParsingMessage
	{
		public static void ErrorCode(int n, ParserRuleContext prc)
		{
            var t = prc.GetText();
			var l = prc.Start.Line;
			var c = prc.Start.Column;
            /*Console.Write(String.Format("ErrorCode({0}): ", n));
			switch (n)
			{
				case 1:
					Console.WriteLine("Something Error");
					break;
				case 2:
					Console.WriteLine("Undefine Variable");
					break;
				case 3:
					Console.WriteLine("Divide By Zero");
					break;
				case 4:
					Console.WriteLine("Type Error");
					break;
				case 5:
					Console.WriteLine("Function Parament Count Not Match");
					break;
				default:
					break;
			}
			Console.WriteLine(String.Format("#\"{0}\" @line {1}:{2}", t, l, c));*/
            Console.WriteLine("error");
			Environment.Exit(1);
		}
		public static void Success()
		{
			//Console.WriteLine("Interpret Successed !!");
		}

	}
}
