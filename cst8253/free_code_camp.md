# **<u>2D Arrays</u>**

```c#
namespace _2DArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declaring 2d array variable
            int[,] numberGrid =
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            };

            // priting the first element in the first array
            Console.WriteLine(numberGrid[0,0]);

            // printing the second element in the third array
            Console.WriteLine(numberGrid[2,1]);

            // declaring a variable without knowing yet what to put in there
            int[,] myArray = new int[2,3]; // we're telling C# how many rows and columns we want to have: 2 elements, 3 elements


            Console.ReadKey();

        }
    }
}
```

# **<u>Exception Handling</u>**

```c#
namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter another number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(num1 / num2);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally // optional
            {
                // any code that we put here is going to get executed no matter what
            }


            Console.ReadKey();

        }
    }
}
```

# **<u>Classes and Objects</u>**

```c#
namespace ClassesObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. Create book objects

            Book book1 = new Book();
            book1.title = "Harry Potter";
            book1.author = "JK Rowling";
            book1.pages = 400;

            Book book2 = new Book();
            book2.title = "Lord of the Rings";
            book2.author = "Tolkien";
            book2.pages = 700;

            Console.WriteLine("Book 1: " + book1.title +
                            "\nBook 2: " + book2.title);
            Console.ReadKey();

        }
    }
}
```

```c#
namespace ClassesObjects
{
    internal class Book
    {

        // 1. Create variables/class attributes
        public string title;
        public string author;
        public int pages;

    }
}
```

# **<u>Constructors</u>**

```c#
namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* #2 Creating the book object: specify the class data type
             * #2b similar to `string str1 = "asdf";
             * #2c book1 is storing a book object
             * Book book1 = new Book(); // 2d creating the book object. an instance of a book
             * book1.title = "Harry Potter"; // 2e giving it value
             * book1.author = "JK Rownling"; // 2e
             * book1.pages = 400; // 2e
             * 2e we just created a book object (which is an instance of a book class)
             * 2f we defined all the pieces of information about this book
             * 2g we defined this book data type and created an actual book inside of the class, called an object
             * Book book2 = new Book(); // 2f creating a new instance
             * book1.title = "Lord of the Rings";
             * book1.author = "Tolkien";
             * book1.pages = 700;
             
             * Console.WriteLine(book1.title);
             * Console.WriteLine(book2.author);
             * Console.ReadKey();
              
             */

            Book book1 = new Book("Harry Potter", "JK Rowling", 400); // 3d every time we say `new Book();` we're calling the constructor
            Book book2 = new Book("Lord of the Rings", "Tolkien", 700);


            // note: we can call the specific class attribute like below
            Console.WriteLine("Book 1: " + book1.title); // 2h we can print out a specific class attribute like this because we assigned each parameter (above) to a variable (Book.cs)

            Console.ReadKey();

        }
    }
}
```

```c#
namespace Constructors
{
    internal class Book
    {

        // #1 Create/declare the variables/class attributes
        public string title; // 1a
        public string author; // 1b
        public int pages; // 1c


        /* 
         * #3 To create a constructor
         * Constructor is a special method inside of our class that gets called when we create an object of this class
         * #3 Create a method
         * 
         */
        public Book(string aTitle, string aAuthor, int aPages)
        // 3b notice that we made it public and named the method after the class. This is a constructor. This is the constructor for this class
        // every time we create a book, we need to pass in the title, the author, and the number of pages
        {
            Console.WriteLine("Title: " + aTitle +
                            "\nAuthor: " + aAuthor +
                            "\nPages: " + aPages +
                            "\n\n"); // 3c every time we create a new book, this will get executed

            // note: in order to be able to identify the specific class attributes, we can assign the variables we created above (#1)
            title = aTitle;
            author = aAuthor;
            pages = aPages;

        }

    }
}
```

# <u>**Object Methods**</u>

```c#
namespace ObjectMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. Creating instances of the class Student
            Student student1 = new Student("Jim", "Business" , 2.8);
            Student student2 = new Student("Pam", "Arts", 3.6);


            // 6. Accessing the first class attribute from the first class instance
            Console.WriteLine("Accessing Student 1 Name: " + student1.name);


            // 8. Checking if the student has honors
            Console.WriteLine("\n");
            Console.WriteLine(student1.name + " has honors: " + student1.HasHonors());
            Console.WriteLine(student2.name + " has honors: " + student2.HasHonors());




            Console.ReadKey();
        }
    }
}
```

```c#
namespace ObjectMethods
{
    internal class Student
    {
        // 4. Declaring public variables (public so that we can access them in the main program)
        public string name;
        public string program;
        public double gpa;

        // 1. Creating a class called 'Student'
        public Student (string aName, string aProgram, double aGPA)
        {
            // 3. Populating the class instances and attributes
            Console.Write("Student: " + aName +
                        "\nProgram: " + aProgram +
                        "\nGPA: " + aGPA +
                        "\n\n");

            // 5. Assigning the variables to the class attributes
            name = aName;
            program = aProgram;
            gpa = aGPA;
        }

        // 7. Creating a method that tells us whether or not the student has honors.
        public bool HasHonors() // boolean because this method is going to return a True value if the student has honors, otherwise False.
        {
            if (gpa >= 3.5)
            {
                return true;
            }
            return false;
        }


    }
}
```

# **<u>Getters and Setters</u>**

```c#
namespace GetterSetter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 4. Creating class instances
            Movie avengers = new Movie("The Avengers", "Joss Whedon", "Dog");
            Movie shrek = new Movie("Shrek", "Adam Adamson", "PG");
            // G, PG, PG-13, R, NR


            // 6. Populating the information
            Console.WriteLine("\nMovie Title: " + avengers.title +
                            "\nDirector: " + avengers.director +
                            "\nRating: " + avengers.Rating +
                            "\n");

            Console.WriteLine("\nMovie Title: " + shrek.title +
                            "\nDirector: " + shrek.director +
                            "\nRating: " + shrek.Rating +
                            "\n");


            Console.ReadKey();

        }
    }
}
```

```c#
namespace GetterSetter
{
    internal class Movie
    {

        // 1. Creating public and private variables
        public string title;
        public string director;
        private string rating; // this is private; we need getter & setter


        // 2. Creating a class constructor
        public Movie (string aTitle, string aDirector, string aRating)
        {
            // 3. Assigning variables to the parameters
            title = aTitle;
            director = aDirector;
            // 6. Calling the Rating setter below
            Rating = aRating; // changed from 'rating = aRating'
        }

        // 5. Creating the properties
        public string Rating
        {
            get { return rating; } // every time we say rating and we want to get it, it's going to return the rating
            set {
                if(value == "G" || value == "PG" || value == "PG-13" || value == "R" || value == "NR")
                {
                    rating = value;
                } else
                {
                    rating = "NR";
                }
            } // setter will allow us to set the rating == modify the rating
        }


    }
}
```

# **<u>Static Class Attributes</u>**

```c#
namespace StaticClassAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. Creating class instances
            Song holiday = new Song("Holiday", "Green Day", 200);
            Song kashmir = new Song("Kashmir", "Led Zeppelin", 150);

            Console.WriteLine(Song.songCount);
            Console.WriteLine(holiday.getSongCount()); // accessing the method (equivalent to "kashmir.songCount")
            Console.WriteLine(kashmir.getSongCount());

            /* Bottomline: STATIC CLASS ATTRIBTUE - tell us information, not about the specific objects themselves,
             *                                      but about the class in general.
             *                                    - In this case, the static class attribute tells us how many instances have been created in the program
             */


            Console.ReadKey();
            }
    }
}
```

```c#
namespace StaticClassAttributes
{
    internal class Song
    {

        // 1. Creating the variables
        public string title;
        public string artist;
        public int duration;
        // 5a. Creating static attribute
        public static int songCount = 0; // tells us how many songs have been created

        // 2. Creating the constructor
        public Song (string aTitle, string aArtist, int aDuration)
        {
            // 3. Assigning variables with the attributes
            title = aTitle;
            artist = aArtist;
            duration = aDuration;

            // 5b. Incrementing songCount. Every time we create a new class, the songCount increases
            songCount++;
        }

        // 6. Creating a method
        public int getSongCount()
        {
            return songCount;
        }


    }
}
```

# **<u>Static Methods and Classes</u>**

```c#
namespace StaticMethodsAndClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Math.Sqrt(144));


            // 2. Calling the SayHi method
            UsefulTools.SayHi("Diana"); // Note that we did not need to create an instance for the class 'UsefulTools'. We just accessed the 'SayHi' method directly

            Console.ReadKey();
        }
    }
}
```

```c#
namespace StaticMethodsAndClasses
{
    static class UsefulTools // static - cannot create class instances
    {
        // 1. Creating static method
        public static void SayHi(string name) // void because it does not need to return anything
        {
            Console.WriteLine("Hello, " + name + "!");
        }
    }
}
```

# **<u>Inheritance</u>**

```c#
namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creating new instance of class Chef
            Chef chef = new Chef();
            chef.MakeSpecialDish();

            ItalianChef italianchef = new ItalianChef();
            italianchef.MakeChicken();
            italianchef.MakePasta();
            italianchef.MakeSpecialDish();


            Console.ReadKey();
        }
    }
}
```

```c#
namespace Inheritance
{
    class Chef
    {
        public void MakeChicken()
        {
            Console.WriteLine("The Chef makes chicken.");
        }


        public void MakeSalad()
        {
            Console.WriteLine("The Chef makes salad.");
        }


        public virtual void MakeSpecialDish() // virtual - can be overridden in a any subclass
        {
            Console.WriteLine("The Chef makes barbeque ribs.");
        }


    }
}
```

```c#
namespace Inheritance
{
    // Creating a class that can perform all tasks that class Chef can do
    class ItalianChef : Chef
    {
        public void MakePasta()
        {
            Console.WriteLine("The Chef makes pasta.");
        }

        public override void MakeSpecialDish() // override - overriding the MakeSpecialDish from the superclass
        {
            Console.WriteLine("The Chef makes chicken parm.");
        }
    }
}
```

# **<u>Example 1 Code</u>**

```c#
namespace FreeCodeCamp
{
    internal class Tutorial
    {

        static void Main(string[] args)
        {
            /*******************************************************************************************************************************************************************/

            /** A. ARRAYS - can hold multiple values
             *         - a container that can hold a bunch of pieces of information
             *         - a set of objects, which any object should be initialized
             *        
             *      1. Specify the type of information or the type of data that the array is going to hold: string, double, boolean, etc.
             *      2. Whenever we're creatin gan array, we always need to let C# know that by using [square brackets]
             *              Example: int [] myArray = { element 1, element 2, element 3 }
             *      3. We can access each individual array element by indexing.
             *      4. If we're creating an empty array, we need to tell C# how big we want to make the array
             */

                                // A ---------- start of arrays ----------
            Console.WriteLine("ARRAYS");

            // specifying and initializing the type of info 
            int[] luckyNumbers = { 4, 8, 15, 16, 23, 42 };

            // accessing the element 16 by using index value
            Console.WriteLine("The fourth number in the luckyNumbers array is " + luckyNumbers[4] + ".");

            // changing the value of the 4th index
            luckyNumbers[4] = 900;
            Console.WriteLine("We are changing the value of the fourth number to " + luckyNumbers[4] + ".");

            // creating an empty array and declaring that there will be 5 elements inside that array
            string[] friends = new string[5];

            // adding elements to the array
            friends[0] = "Jim";
            friends[1] = "Kelly";

                                // A ---------- end of arrays ----------
                                // B ---------- start of methods ----------

            Console.WriteLine("\nMETHODS");

            // calling the SayHi method from below
            SayHi("Mike", 10);
            
            // calling the cube method from below
            Console.WriteLine("5 cubed is " + cube(5) + ".");


                                // B ---------- end of methods ----------
                                // C ---------- start of if statements ----------

            Console.WriteLine("\nIF STATEMENTS");

            // calling the IfStatements method from below
            IfStatements();
            Console.WriteLine("The max number is " + GetMax(98, 99, 97) + ".");

            // calling the Calculator method from below
            Calculator();

            // calling the SwitchStatements method
            Console.WriteLine("Today is a " + GetDay(0) + ".");

                                // C ---------- end of if statements ----------
                                // D ---------- start of do while statements ----------

            // calling the WhileLoop method
            WhileLoop();

            // calling the GuessingGame method
            Console.WriteLine("I am a tall animal. What am I?");
            GuessingGame();

                                // D ---------- end of do while statements ----------
                                // E ---------- start of classes and objects ----------

            // calling the Bookclass() method
            Console.WriteLine("\nCLASSES AND OBJECTS");
            Bookclass();



            Console.ReadKey();
        }

        /*******************************************************************************************************************************************************************/

        /** B. METHODS - a short block of code that can perform a specific task (akin to functions in Python)
         *          - it needs to be called for it to be executed
         *          - the 'Main' in 'static void Main(string[] args) is a method inside of our program
         *          - the 'Main' method is very special because it gets executed when we run the program
         *          - we are encapsulating a bunch of codes inside of its own little container
         *          - Methods begin with a capital letter
         * 
         *      1. To create a new method, we need to go outside of the Main method.
         *      2. Add the keyword 'static'.
         *      3. Specify the return type.
         *      4. Add the keyword 'void'. Void means that this method isn't going to return any information.
         *      5. Generally, we use a capital letter for the name.
         *      6. Add an open and close parenthesis,
         *      7. followed by an open and close curly brackets, where the code block will be stored.
         *      
         *          - Methods can also take in values called Parameters or Arguments.
         *          - A parameter is passed into the method so we can use the value to execute the code block inside the method.
         *          - We can call methods again and again.
         *
         *
         /*******************************************************************************************************************************************************************/

         /** C. RETURN STATEMENTS - methods that can return values back to the callers
         *      
         *      1. We will not be using void, instead we will use the data type that we will return
         *
         */

        // creating a method that will say hi to whoever is using the program
        static void SayHi(string name, int age)
        {
            Console.WriteLine("Hello " + name + ". You are " + age + " years old.");
        }

        // creating a method that will return an integer
        static int cube(int num)
        {
            int result = (int)Math.Pow(num, 3);
            return result;
        }

        /*******************************************************************************************************************************************************************/

        /** D. IF STATEMENTS
         * 
         *      1. We put the conditions inside the parenthesis.
         *      2. && - both conditions have to be true.
         *      3. || - only one of theme has to be true.
         *      4. ! - a negation operator. It negates the statement/s
         *      
         */


        // IF STATEMENTS
        static void IfStatements()
        {
            bool isFemale = true;
            bool isTall = false;

            if (isFemale && isTall)
            {
                Console.WriteLine("You are a tall female.");
            } else if (isFemale && !isTall)
            {
                Console.WriteLine("You are a short female.");
            } else 
            {
                Console.WriteLine("You are a male.");
            }
        }

        static int GetMax(int num1, int num2, int num3)
        {
            int result;
            if (num1 >= num2 && num1 >= num3)
            {
                result = num1;
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                result = num2;
            }
            else
            {
                result = num3;
            }

            return result;
        }


        /*******************************************************************************************************************************************************************/

        /** E. NUMBERS AND OPERATORS: BUILDING A CALCULATOR
         * 
         */


        static void Calculator()
        {
            // declaring calculateAgain as a string
            // needs to be outside the do while loop
            string calculateAgain = "y";

            do
            {

                Console.WriteLine("\nBUILDING A CALCULATOR");
                Console.Write("Please enter a number: ");
                // Console.ReadLine returns a string. We need to use Convert.ToDouble to convert the string to a double.
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the operator: ");
                string op = Console.ReadLine();

                Console.Write("Please enter a number: ");
                // Console.ReadLine returns a string. We need to use Convert.ToDouble to convert the string to a double.
                double num2 = Convert.ToDouble(Console.ReadLine());

                if (op == "+")
                {
                    Console.WriteLine("The sum of " + num1 + " + " + num2 + " is " + (num1 + num2) + ".");
                }
                else if (op == "-")
                {
                    Console.WriteLine("The difference of " + num1 + " - " + num2 + " is " + (num1 - num2) + ".");
                }
                else if (op == "*")
                {
                    Console.WriteLine("The product of " + num1 + " x " + num2 + " is " + (num1 * num2) + ".");
                }
                else if (op == "/")
                {
                    Console.WriteLine("The quotient of " + num1 + " / " + num2 + " is " + (num1 / num2) + ".");
                }
                else
                {
                    Console.WriteLine("Invalid operator.");
                }

                // ask user if they want to calculate again
                Console.Write("Would you like to calculate again [y/n]? ");
                calculateAgain = Console.ReadLine();

                if (calculateAgain != "y")
                {
                    break;
                }

            } while (calculateAgain == "y");
        }


        /*******************************************************************************************************************************************************************/

        /** F. SWITCH STATEMENTS - a special type of if statement where we can check a bunch of different conditions easily.
         *                    - allows a variable to be tested for equality against a list of values
         *                    - Each value is called a CASE, and the variable being switched on is checked for each switch case
         *                    - Everything you can do with Switch Statements, you can also do in If Statements.
         *                    - Switch statements make it a lot easier to manage and less messier to do multiple things.
         *                    - Switch statements allow values to get mapped to what code block.
         *                    
         *     BREAK - breaking out of the structre we're currently in. In the case below, breaking out of the switch statement
         *           - If we don't put the break statement, C# is going to keep checking
         *           - If you have a scenario where you want to be able to keep checking the other cases, even after one of them was true, then you can get rid of the break statement.
         * 
         *          1. The switch statement needs a value (paremeter) inside the parenthesis.
         *          2. We're going to pass it a value and then we're going to check if that value is equal to a bunch of different stuff.
         *          3. Depending on what it's equal to, we're going to do different things.
         *          4. Switch statements can only handle values in the switch cases.
         *          5. To account for scenarios that are outside of the switch cases, we can use 'default'.
         *          
         */

        // the switch statement below aims to populate the dayName variable with the value that corresponds to the dayNum
        static string GetDay(int dayNum)
        {
            Console.WriteLine("\nSWITCH STATEMENTS");
            string dayName;

            switch( dayNum )
            {
                // if dayNum = 0, this is the block of code that we want to execute:
                case 0:
                    dayName = "Sunday";
                    break;
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                // if none of the above cases are not true
                default:
                    dayName = "Invalid Day Number";
                    break;

            }

            return dayName;
        }


        /*******************************************************************************************************************************************************************/

        /** G. WHILE LOOPS - a programming structure that allows us to loop over a specific block of code, while a certain condition is true.
         *                    - We're able to keep doing somethin repeatedly while a condition is true.
         * 
         * 
         * 
         */

        static void WhileLoop()
        {
            Console.WriteLine("\nWHILE LOOP");

            int index = 1;

            // as long as the index remains less/equal to 5, the program will keep executing the code block below
            while( index <= 5 )
            {
                Console.WriteLine("Loop " + index + ".");

                // increment the value of index by 1
                index++;
            }

        }


        // Guessing Game: this game loops until the user guesses the word correctly
        static void GuessingGame()
        {
            // declaring string variable
            string secretWord = "giraffe";
            string guess = "";
            int trials = 0;

            while( guess != secretWord && trials < 5)
            {
                Console.Write("\nEnter guess: ");
                guess = Console.ReadLine();

                if ( guess != "giraffe")
                {
                    trials++;
                    Console.WriteLine("Incorrect. You have " + (5 - trials) + " tries left.");
                }
            }

            if (guess == secretWord)
            {
                Console.WriteLine("Congratulations! You guessed it!");
            }

            if (trials >= 5)
            {
                Console.WriteLine("\nSorry! You lucked out. The correct answer is 'giraffe'. ");
            }


            /** H. FOR LOOPS
             * 
             */

            // initializing variable outside the while loop
            int i = 1;
            while ( i <= 5 )
            {
                Console.WriteLine("\nWhile Loop #" + i);
                i++;
            }

                        // for (variable initialization; loop condition; variable increment)
            for(int x = 1; x <= 5; x++)
            {
                Console.WriteLine("\nFor Loop #" + x);
            }


            int[] luckyNumbers = { 4, 8, 15, 16, 23, 42 };
            for (int index = 0; index < luckyNumbers.Length; index++)
            {
                Console.WriteLine("\nLucky Number #" + luckyNumbers[index]);
                
            }

        }


        /** I. CLASSES AND OBJECTS
                     *              OBJECTS - allow you to create your own custom data types
                     *                      - an instance of a class
                     *              CLASS   - specification for a new data type
                     *                      - used to model real world entities inside of our program 
                     *                      - like a new blueprint for a new data type
                     * 
                     *          1. Open solution explorer.
                     *          2. Right click on ProgramName (for ex: FreeCodeCamp).
                     *          3. Hover on 'Add' and click 'New Item...'
                     *          4. Select 'Class'.
                     *          5. Give class a name. In C#, classes begin with a capital letter.
                     *          6. Another solution will pop up.
                     *          7. Declare class attributes and save file.
                     *          8.
                     * 
                     */

        static void Bookclass()
        {
            // creating book object
            // classname.classattribute
            Book book1 = new Book("Harry Potter", "JK Rowling", 400);
            Book book2 = new Book("Lord of the Rings", "Tolkien", 700);

            // modify value
            book2.title = "The Hobbit";

            Console.WriteLine(book2.title);


            /*book1.title = "Harry Potter";
            book1.author = "JK Rowling";
            book1.pages = 400;
            book2.title = "Lord of the Rings";
            book2.author = "Tolkein";
            book2.pages = 700;
            Console.WriteLine("Title: " + book1.title
                            + "\nAuthor: " + book1.author
                            + "\nNumber of Pages: " + book1.pages
                            );
            Console.WriteLine("\n\nTitle: " + book2.title
                + "\nAuthor: " + book2.author
                + "\nNumber of Pages: " + book2.pages
                );
            */

        }

        /** CONSTRUCTORS - a special method that we can put inside of a C# class, which is going to get called whenever we create an object of that class.
         *               - any time we create an object of a specific class, the constructor method will get called and we can do different things
         *  
         *  */




    }
}
```

```c#
namespace FreeCodeCamp
{
    internal class Book
    {
        // declaring class attributes
        public string title;
        public string author;
        public int pages;


        // public <name of class>() - constructor
        public Book(string aTitle, string aAuthor, int aPages)
        {
            // pass the class attributes to the parameters
            title = aTitle;
            author = aAuthor;
            pages = aPages;
        }
    }
}
```

































