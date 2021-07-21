using System;

namespace ConsoleApp1
{
    class Program
    {

        enum XOperator
        {
            Plus,
            Minus,
            PlusAndMinus,
            MinusAndPlus
        }

        class XMatrix
        {

            public int[] Arr1 { get; set; }

            public int[] Arr2 { get; set; }

            public int[] Arr3 { get; set; }

            public XOperator Oper { get; set; }

            public XMatrix()
            {

            }

            public XMatrix(int[] arr1, int[] arr2, int[] arr3)
            {
                Arr1 = arr1;
                Arr2 = arr2;
                Arr3 = arr3;
            }

            public int VSum1 { get; set; }

            public int HSum1 { get; set; }

            public int VSum2 { get; set; }

            public int HSum2 { get; set; }

            public int VSum3 { get; set; }

            public int HSum3 { get; set; }

            public void ComputeSum()
            {

                switch (Oper)
                {
                    case XOperator.Plus:
                        {
                            HSum1 = Arr1[0] + Arr1[1] + Arr1[2];
                            VSum1 = Arr1[0] + Arr2[0] + Arr3[0];

                            HSum2 = Arr2[0] + Arr2[1] + Arr2[2];
                            VSum2 = Arr1[1] + Arr2[1] + Arr3[1];

                            HSum3 = Arr3[0] + Arr3[1] + Arr3[2];
                            VSum3 = Arr1[2] + Arr2[2] + Arr3[2];
                        }
                        break;
                    case XOperator.Minus:
                        {
                            HSum1 = Arr1[0] - Arr1[1] - Arr1[2];
                            VSum1 = Arr1[0] - Arr2[0] - Arr3[0];

                            HSum2 = Arr2[0] - Arr2[1] - Arr2[2];
                            VSum2 = Arr1[1] - Arr2[1] - Arr3[1];

                            HSum3 = Arr3[0] - Arr3[1] - Arr3[2];
                            VSum3 = Arr1[2] - Arr2[2] - Arr3[2];
                        }
                        break;
                    case XOperator.PlusAndMinus:
                        {
                            HSum1 = Arr1[0] + Arr1[1] - Arr1[2];
                            VSum1 = Arr1[0] + Arr2[0] - Arr3[0];

                            HSum2 = Arr2[0] + Arr2[1] - Arr2[2];
                            VSum2 = Arr1[1] + Arr2[1] - Arr3[1];

                            HSum3 = Arr3[0] + Arr3[1] - Arr3[2];
                            VSum3 = Arr1[2] + Arr2[2] - Arr3[2];
                        }
                        break;
                    case XOperator.MinusAndPlus:
                        {
                            HSum1 = Arr1[0] - Arr1[1] + Arr1[2];
                            VSum1 = Arr1[0] - Arr2[0] + Arr3[0];

                            HSum2 = Arr2[0] - Arr2[1] + Arr2[2];
                            VSum2 = Arr1[1] - Arr2[1] + Arr3[1];

                            HSum3 = Arr3[0] - Arr3[1] + Arr3[2];
                            VSum3 = Arr1[2] - Arr2[2] + Arr3[2];
                        }
                        break;
                }

            }

            public bool IsValid => HSum1 >= 0 & HSum2 >= 0 & HSum3 >= 0 & VSum1 >= 0 & VSum2 >= 0 & VSum3 >= 0;

        }

        static int[] GenerateArray(int count)
        {
            var random = new Random();
            var values = new int[count];

            for (var i = 0; i < count; i++)
                values[i] = random.Next(0, 10);

            return values;
        }

        static XOperator GetOperator()
        {
            var opers = new[] { XOperator.Minus, XOperator.Plus, XOperator.MinusAndPlus, XOperator.PlusAndMinus };
            var random = new Random();
            var index = random.Next(0, 4);

            return opers[index];
        }

        static XMatrix RandomMatrix()
        {
            XMatrix mat;

            while (true)
            {
                var arr1 = GenerateArray(3);
                var arr2 = GenerateArray(3);
                var arr3 = GenerateArray(3);
                var oper = GetOperator();

                mat = new XMatrix(arr1, arr2, arr3)
                {
                    Oper = oper
                };
                mat.ComputeSum();

                if (mat.IsValid)
                {
                    break;
                }
            }

            return mat;
        }

        static void PrintMatrix(XMatrix mat)
        {
            switch (mat.Oper)
            {
                case XOperator.Plus:
                    {
                        Console.Write(mat.Arr1[0] + "+" + mat.Arr1[1] + "+" + mat.Arr1[2] + "=" + mat.HSum1 + "\n");
                        Console.Write("+ + + \n");
                        Console.Write(mat.Arr2[0] + "+" + mat.Arr2[1] + "+" + mat.Arr2[2] + "=" + mat.HSum2 + "\n");
                        Console.Write("+ + + \n");
                        Console.Write(mat.Arr3[0] + "+" + mat.Arr3[1] + "+" + mat.Arr3[2] + "=" + mat.HSum3 + "\n");
                        Console.Write("= = = \n");
                        Console.Write(mat.VSum1 + " " + mat.VSum2 + " " + mat.HSum3 + "\n");
                    }
                    break;
                case XOperator.Minus:
                    {
                        Console.Write(mat.Arr1[0] + "-" + mat.Arr1[1] + "-" + mat.Arr1[2] + "=" + mat.HSum1 + "\n");
                        Console.Write("- - - \n");
                        Console.Write(mat.Arr2[0] + "-" + mat.Arr2[1] + "-" + mat.Arr2[2] + "=" + mat.HSum2 + "\n");
                        Console.Write("- - - \n");
                        Console.Write(mat.Arr3[0] + "-" + mat.Arr3[1] + "-" + mat.Arr3[2] + "=" + mat.HSum3 + "\n");
                        Console.Write("= = = \n");
                        Console.Write(mat.VSum1 + " " + mat.VSum2 + " " + mat.HSum3 + "\n");
                    }
                    break;
                case XOperator.PlusAndMinus:
                    {
                        Console.Write(mat.Arr1[0] + "+" + mat.Arr1[1] + "-" + mat.Arr1[2] + "=" + mat.HSum1 + "\n");
                        Console.Write("+ + + \n");
                        Console.Write(mat.Arr2[0] + "+" + mat.Arr2[1] + "-" + mat.Arr2[2] + "=" + mat.HSum2 + "\n");
                        Console.Write("- - - \n");
                        Console.Write(mat.Arr3[0] + "+" + mat.Arr3[1] + "-" + mat.Arr3[2] + "=" + mat.HSum3 + "\n");
                        Console.Write("= = = \n");
                        Console.Write(mat.VSum1 + " " + mat.VSum2 + " " + mat.HSum3 + "\n");
                    }
                    break;
                case XOperator.MinusAndPlus:
                    {
                        Console.Write(mat.Arr1[0] + "-" + mat.Arr1[1] + "+" + mat.Arr1[2] + "=" + mat.HSum1 + "\n");
                        Console.Write("- - - \n");
                        Console.Write(mat.Arr2[0] + "-" + mat.Arr2[1] + "+" + mat.Arr2[2] + "=" + mat.HSum2 + "\n");
                        Console.Write("+ + + \n");
                        Console.Write(mat.Arr3[0] + "-" + mat.Arr3[1] + "+" + mat.Arr3[2] + "=" + mat.HSum3 + "\n");
                        Console.Write("= = = \n");
                        Console.Write(mat.VSum1 + " " + mat.VSum2 + " " + mat.HSum3 + "\n");
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            for (var i = 0; i < 3; i++)
            {
                var mat = RandomMatrix();

                Console.WriteLine("Test case#" + (i + 1) + " => " + mat.Oper);
                PrintMatrix(mat);

                Console.WriteLine();
            }

            Console.WriteLine("\nDone!\n");
        }
    }
}
