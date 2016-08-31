using System.Reflection;
using System;

namespace AAuLibrary  
{ 
    public class AArdioTable  
    { 
    	private object tObject;
    	public AArdioTable(object obj) 
		{
    		tObject = obj;
    	}
    	public object GetProperty(string k) 
		{
    		return tObject.GetType().InvokeMember(k, BindingFlags.GetProperty, null, tObject, null);
    	}
    	public void SetProperty(string k,object v) 
		{
    		tObject.GetType().InvokeMember(k, BindingFlags.SetProperty, null, tObject, new object[] { v });
    	}
    	public object InvokeMember(string k,params/*不定个数参数*/ object[] arg ) 
		{ 
    		return tObject.GetType().InvokeMember(k, BindingFlags.InvokeMethod, null, tObject, arg );
    	}
    } 
    
    public class CSharpObject
    { 
        public object Hello(object comObject) //将object塞给AArdioTable和aauto通讯
		{   
            AArdioTable tab = new AArdioTable(comObject); //和获得参数值有关
        	tab.SetProperty("retval",456);
            tab.InvokeMember("callAArdio","console.log('在C#中执行aardio代码')");
			Console.WriteLine("Hello world");
            return tab.GetProperty("retval");
        }
    }   
}

namespace MainSpace
{
	class Program
	{
		static public void Main() //默认入口函数
		{
			Console.WriteLine("Hello world");
		}
	}
}