//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from lisp_gammar.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="lisp_gammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface Ilisp_gammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProg([NotNull] lisp_gammarParser.ProgContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStmt([NotNull] lisp_gammarParser.StmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.print_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrint_stmt([NotNull] lisp_gammarParser.Print_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExp([NotNull] lisp_gammarParser.ExpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] lisp_gammarParser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.num"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNum([NotNull] lisp_gammarParser.NumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.num_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNum_op([NotNull] lisp_gammarParser.Num_opContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.plus"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlus([NotNull] lisp_gammarParser.PlusContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.minus"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinus([NotNull] lisp_gammarParser.MinusContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.multiply"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiply([NotNull] lisp_gammarParser.MultiplyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.divide"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivide([NotNull] lisp_gammarParser.DivideContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.modulus"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModulus([NotNull] lisp_gammarParser.ModulusContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.greater"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreater([NotNull] lisp_gammarParser.GreaterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.smaller"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSmaller([NotNull] lisp_gammarParser.SmallerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.equal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqual([NotNull] lisp_gammarParser.EqualContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.logical_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogical_op([NotNull] lisp_gammarParser.Logical_opContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.and_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnd_op([NotNull] lisp_gammarParser.And_opContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.or_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOr_op([NotNull] lisp_gammarParser.Or_opContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.not_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNot_op([NotNull] lisp_gammarParser.Not_opContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.def_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDef_stmt([NotNull] lisp_gammarParser.Def_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable([NotNull] lisp_gammarParser.VariableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.fun_exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_exp([NotNull] lisp_gammarParser.Fun_expContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.fun_IDs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_IDs([NotNull] lisp_gammarParser.Fun_IDsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.fun_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_body([NotNull] lisp_gammarParser.Fun_bodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.fun_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_call([NotNull] lisp_gammarParser.Fun_callContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] lisp_gammarParser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.fun_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_name([NotNull] lisp_gammarParser.Fun_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.if_exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_exp([NotNull] lisp_gammarParser.If_expContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.test_exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTest_exp([NotNull] lisp_gammarParser.Test_expContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.than_exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitThan_exp([NotNull] lisp_gammarParser.Than_expContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="lisp_gammarParser.else_exp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElse_exp([NotNull] lisp_gammarParser.Else_expContext context);
}
