# Xunit.Repeat
[![Build status](https://ci.appveyor.com/api/projects/status/282evix4706ypdt1?svg=true)](https://ci.appveyor.com/project/MarcolinoPT/xunit-repeat)

Repeat attribute for xUnit.net

Why? Because once upon a time I had the need to do use such an attribute but xUnit did not have it.
After a quick search I found that others had stumbled upon the same [need](https://stackoverflow.com/questions/31873778/xunit-test-fact-multiple-times/55687930#55687930) without success,
so I provided some code to help them out but thoght to myself this could be probably be useful if we had it as package.

Feel free to provide feedback, additional requests or PRs for future improvement.

## Usage

```
[Theory()]
[Repeat(10)]
public void Test(int iterationNumber)
{
...
}
```
Iteration number should be added in order to run the test.
