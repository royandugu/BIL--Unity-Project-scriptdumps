1. Controllers<br>
Scripts that controlls our GameObjects
<br>

2. SceneManagers<br>
Scripts that controlls scene traversing
<br>

3. Statics <br>
Scripts that are not inherited from MonoBehaviour <br>


## To-Do<br>

1. Dynamically class kina create garne?? 
    It's ok json bata fetch huda as a whole string naii fetch hunxa. No issue in that tara jaba deserialize
    garxau, bhaye bhar ko sabai deserialize huna pugyo. Individually try handa dherai ota if else cases
    So, the only left solution is to create a class dynamically. Agadi bata NPC ko naam, and then tyo naam bata fetch garne.

    A problem once again is that System.Reflection.Emit is not working on Unity. Therefore ExpandoObject ko help linu paryo, jun mah feri Assembly installations ko problems auna sakla. Secondly, we have System.Reflection realated solution.    

    solution:
    tried to use ExpandObject:- Issue:- Assets\Scripts\Statics\FetchClassFormats\ClassCreator.cs(6,9): error CS0656: Missing compiler required member 'Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create'
    
2. Fix response flag as per the npc number (prevention of too many if else cases)

3. How to access properties of the IDictionary