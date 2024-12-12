// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;

Console.WriteLine("NLUA ARM");

NLua.Lua lua = new NLua.Lua();
object result = null;
result = lua.DoString("print(\"Hello from Lua!  Next object is empty and the one after that is 200.\");");
Console.WriteLine(JsonConvert.SerializeObject(result));
result = lua.DoString("return 100 + 100;");
Console.WriteLine(JsonConvert.SerializeObject(result));

Console.WriteLine("press any key to exit...");
Console.ReadKey();
