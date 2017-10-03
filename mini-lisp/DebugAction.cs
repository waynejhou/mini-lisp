using System;
namespace minilisp
{
	public static class DebugAction
	{
		static public bool debugmode = false;
        static public int tab = 0;
		static public void Debug_action<T>(Action<T> a, T t)
		{
			if (debugmode)
			{
				a.Invoke(t);
			}
		}
		static public void Debug_action<T1, T2>(Action<T1, T2> a, T1 t1, T2 t2)
		{
			if (debugmode)
			{
				a.Invoke(t1, t2);
			}
		}
		static public void Debug_Write<T>(T t)
		{
			if (debugmode)
			{
				Console.Write(t);
			}
		}
		static public void Debug_WriteLine<T>(T t)
		{
			if (debugmode)
			{
                for (int i = 0; i < tab; i ++){
                    Console.Write(" ");
                }
				Console.WriteLine(t);
			}
		}
	}
}
