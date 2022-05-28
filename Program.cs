using System;
using System.Diagnostics;
using System.Threading;

var time = new Stopwatch();
// BIG O
int arraySize = 1000;
var array = new int[arraySize];
var target = 800;

for(int i=1;i<arraySize;i++)
  array[i] = i;

// Constant: O(1)
void Constant(int[] array)
{
  time.Start();
  Console.WriteLine("Constant");
  Console.WriteLine(array[target]);
  time.Stop();
  Console.WriteLine(time.Elapsed.ToString());
  time.Reset();
}

Constant(array);

// Linear: O(n)
void Linear(int[] array)
{
  // WHY IS THIS SO FAST?????
  time.Start();
  Console.WriteLine("Linear");
  for(int i = 0; i < array.Length; i++)
  {
    if(array[i] == target) Console.WriteLine(array[i]);
  }
  time.Stop();
  Console.WriteLine(time.Elapsed.ToString());
  time.Reset();
}

Linear(array);

// Quadratic: O(n^2)
void Quadratic(int[] array)
{
  time.Start();
  Console.WriteLine("Quadratic");
  for(int i = 0; i < array.Length; i++)
  {
    //Console.WriteLine(array[i]);
    for(int j = 0; j < array.Length; j++)
    {
    if(array[i] == target && array[j] == target) Console.WriteLine(array[i].ToString() + " - " + array[j].ToString());
    }
  }
  time.Stop();
  Console.WriteLine(time.Elapsed.ToString());
  time.Reset();
}

Quadratic(array);

// Logarithmic: O(log n)
Console.WriteLine("Logarithmic");
time.Start();
var start = 0;
var end = array.Length - 1;
bool Logarithmic(int[] array, int start, int end)
{
  if(start>end) return false;

  var midIndex = (start + end) / 2;
  if(array[midIndex]==target)
  {
    Console.WriteLine(array[midIndex]);
    return true;
  }
  if(array[midIndex] > target)
  {
    return Logarithmic(array, start, midIndex-1);
  }
  else
  {
    return Logarithmic(array, midIndex+1, end);
  }
}
Console.WriteLine(Logarithmic(array, start, end));

time.Stop();
Console.WriteLine(time.Elapsed.ToString());
time.Reset();

