# Verbose
Toolkit to track numeric calculations  
1. Download `Verbose.cs` and add to your project  
2. Add `using CoreDevelopers.DataTypes;`  

## Before
```
decimal valA = 5;
for (int i = 7; i < 9; i++)
{
 valA = valA + i;
}
valA = valA * 11;
valA = valA / 6;
valA = valA - 10;
Console.WriteLine($"Value: {valA}");
```
### Output  
>Value: 26.666666666666666666666666667

## After
```
Verbose<decimal> valA = 5;
for (int i = 7; i < 9; i++)
{
 valA = valA + i;
}
valA = valA * 11;
valA = valA / 6;
valA = valA - 10;
Console.WriteLine($"Value: {valA}");
Console.WriteLine($"Expression: {valA.Expression}");
```
### Output  
>Value: 26.666666666666666666666666667  
>Expression: (((5 + 7 + 8) * 11) / 6) - 10
