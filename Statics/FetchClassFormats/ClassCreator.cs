//using System.Dynamic;
using System.Collections.Generic;
public static class ClassCreator{
    public static IDictionary<string,object> GetClass(string name){
        IDictionary<string,object> container= new Dictionary<string,object>();
        IDictionary<string,object> individual=new Dictionary<string,object>();
        individual.Add("dialogs",typeof(NpcInfo));
        container.Add(name,individual);
        return container;
    }
}