using System.Reflection; 

namespace AAuLibrary  
{ 
    public class AardioTable  
    { 
    	private object tObject;
    	public AardioTable(object obj) 
		{
    		tObject = obj;
    	}
    	public object GetProperty(string k) 
		{
    		return tObject.GetType().InvokeMember("属性名", BindingFlags.GetProperty, null, tObject, null);
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
        public object Hello(object comObject) //通过object和aauto通讯
		{   
            AardioTable tab = new AardioTable(comObject);
         
        	tab.SetProperty("属性名",456); 
            tab.InvokeMember("执行aardio","console.log('在C#中执行aardio代码')");
            return tab.GetProperty("属性名"); 
        }
    }   
} 