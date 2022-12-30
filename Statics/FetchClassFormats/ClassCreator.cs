using System.Dynamic;
public static class ClassCreator{
    public static dynamic GetClass(string name){
        dynamic container=new ExpandoObject(); //{} outside curly braces
        dynamic nested=new ExpandoObject(); //{} inside class name
        container.Add(name,nested);//nesting
        return container;
    }
}