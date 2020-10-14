# FizzBuzz w/ Model 

FizzBuzz is a very simple programming task, used in software developer job interviews, to determine whether the job candidate can actually write code. 

  - It was invented by Imran Ghory, and popularized by Jeff Atwood.
  - Write a program that prints the numbers from 1 to 100
  - For multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz”.

# Code - HomeController 
 - Code shown is for the code used to add the "solve" View
 - The 2nd solve is for the program to run it / give solution
```sh
[HttpGet]
        public IActionResult Solve()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Solve(string userInput1, string userInput2)
        {
            var fizzBuzzModel = new FizzBuzzModel(); //fizzBuzzModel is Object of FizzBuzzModel Class
            fizzBuzzModel.FizzNum = Convert.ToInt32(userInput1);//FizzBuzzModel's FizzNum Prop
            fizzBuzzModel.BuzzNum = Convert.ToInt32(userInput2);//FizzBuzzModel's BuzzNum Prop
            fizzBuzzModel.Output = $"You gave me FizzNum: {userInput1} and BuzzNum: {userInput2}";//
            fizzBuzzModel.ReturnValue = "";


            for (var i = 1; i <= 100; i++)
            {
                if (i % fizzBuzzModel.FizzNum == 0 && i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "FizzBuzz ";
                }
                else if (i % fizzBuzzModel.FizzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "Fizz ";
                }
                else if (i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.ReturnValue += "Buzz ";
                }
                else
                {
                    fizzBuzzModel.ReturnValue += $"{i} ";
                }

            }
                return RedirectToAction("Result",fizzBuzzModel);// diverting to resultAction; making "New" instance 

        }

        public IActionResult Result(FizzBuzzModel model)
        {
            return View(model);
        }
```
1. Make the model and equal it to a "new" instance of the moodel
2. Then you set the two user inputs to equal the Fizz/BuzzNum properties of the model
3. Tell them wwhat numbers that they have put in
4. Make a ReturnValue property in the Model and code
5. Code formula for FizzBuzz
6. The last line in the return statment has the code "Redirect" to the "Result" Action w/ the new instance of the FizzBuzz Model
----------------------------------------------------------------------------------------------------------
