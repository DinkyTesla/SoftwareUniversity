
namespace ClubParty2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public class Program
    {
        public static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());

            var hallsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            for (int i = 0; i < hallsInput.Length; i++)
            {

            }
        }
    }
}

//for (int i = 0; i<hallsInput.Length; i++)
//          {
//              var currentInput = hallsInput[i];

//              if (char.TryParse(currentInput, out char inputIsChar))
//              {
//                  workDict.Add(inputIsChar, new List<int>());
//              }
//          }

//          for (int i = 0; i<hallsInput.Length; i++)
//          {
//              var currentInput = hallsInput[i];

//              if (int.TryParse(currentInput, out _))
//              {
//                  int workInt = int.Parse(currentInput);

//                  if (workDict[chars])
//                  {

//                  }
//                  workDict[]
//              }


//          }

//          //currentInput = input.Pop();
//          if (int.TryParse(currentInput, out int inputIsDigit))
//          {
//              //inputIsDigit = int.Parse(input.Pop());
//              //companyOfHeroes.Enqueue(inputIsDigit);

//              if ((counter + inputIsDigit) >= capacity)
//              {
//                  Console.WriteLine($"{workDict.Keys} -> ");
//                  counter = 0;
//                  break;
//              }
//              counter += inputIsDigit;
//              workDict[inputIsChar].Add(inputIsDigit);
//          }

//                    if (sum<capacity)
//                    {

//                        workDict[inputIsChar].Add(inputIsDigit);

//                        if (sum > capacity)
//                        {
//                            workDict[inputIsChar].Remove(inputIsDigit);

//                            foreach (var kvp in workDict)
//                            {
//                                var values = string.Join(", ", kvp.Value);
//Console.WriteLine($"{kvp.Key} -> {values}");
//                                workDict.Remove(kvp.Key);
//                            }
//                        }
//                        else if (sum == capacity)
//                        {
//                            foreach (var kvp in workDict)
//                            {
//                                var values = string.Join(", ", kvp.Value);
//Console.WriteLine($"{kvp.Key} -> {values}");
//                                workDict.Remove(kvp.Key);
//                            }

//                            input.Pop();
//                        }
//                    }



